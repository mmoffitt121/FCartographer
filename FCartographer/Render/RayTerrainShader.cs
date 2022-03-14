using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;
using ILGPU.Runtime.Cuda;
using ILGPU.Runtime.OpenCL;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class RayTerrainShader : Renderer
    {
        /// <summary>
        /// Intensity of light source
        /// </summary>
        public float intensity;
        /// <summary>
        /// Intensity of ambient light source, range = 0 - 255
        /// </summary>
        public int ambient;
        /// <summary>
        /// Angle of light source
        /// </summary>
        public float direction;
        /// <summary>
        /// Vertical angle of light source from horizon.
        /// 
        /// Corresponding values assume direction = 0
        /// 0 = sunset in the west
        /// 45 = afternoon
        /// 90 = noon, sun directly overhead
        /// 135 = morning
        /// 180 = sunrise in the east
        /// </summary>
        public float angle;

        /// <summary>
        /// How much the light drops off around corners;
        /// </summary>
        public float dropoff;
        /// <summary>
        /// Amount of pixels above to account shadows for
        /// </summary>
        public int bias;

        /// <summary>
        /// Color of the light
        /// </summary>
        public Color lightcolor;

        private Context context;
        private Accelerator accelerator;
        private System.Action<Index1D, ArrayView<byte>, ArrayView<byte>, int, int, float, float, float, float, byte, byte, byte, float, int, float> renderraykernel;

        /// <summary>
        /// Render override function
        /// </summary>
        public override void Render()
        {
            RenderShadows();
        }

        private void RenderShadows()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            switch (rendermode)
            {
                case 0:
                    DefaultRenderShadows(inp, outp);
                    break;
                case 1:
                case 2:
                case 3:
                    AcceleratedRenderShadows(inp, outp);
                    break;
            }

            //BitmapDataConverter.DrawImage(GetOutput(), outp, true);
            BitmapDataConverter.DrawByteArrayToBitmap(GetOutput(), outp);
        }

        private void DefaultRenderShadows(byte[] inp, byte[] outp)
        {
            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            float dx = MathF.Cos((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dy = MathF.Sin((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dh = MathF.Cos((angle + 90) * MathF.PI / 180);

            float amb = ((float)ambient) / 255;

            byte lr = lightcolor.R;
            byte lg = lightcolor.G;
            byte lb = lightcolor.B;

            float luminosity;
            for (int i = 0; i < wid * hei; i += 4)
            {
                float x = i % wid / 4;
                float y = i / wid;
                float h = inp[i];
                luminosity = 1f;
                while (x < wid / 4 && x >= 0 && y < hei && y >= 0 && h <= 255 && h >= 0 && luminosity > 0)
                {
                    if (luminosity > 1 + dropoff * (h - bias - inp[wid * (int)y + 4 * (int)x]))
                    {
                        luminosity = 1 + dropoff * (h - bias - inp[wid * (int)y + 4 * (int)x]);
                    }

                    x += dx;
                    y += dy;
                    h += dh;
                }

                outp[i + 3] = 255;
                outp[i + 2] = (byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255);
                outp[i + 1] = (byte)Math.Clamp(amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255, 0, 255);
                outp[i + 0] = (byte)Math.Clamp(amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255, 0, 255);
            }
        }

        private void CompileKernel()
        {
            context = Context.CreateDefault();
            
            switch (rendermode)
            {
                case 1:
                    accelerator = context.CreateCPUAccelerator(0);
                    break;
                case 2:
                    context = Context.Create(builder => { builder.Assertions().Verify().OpenCL(); });
                    accelerator = context.CreateCLAccelerator(0);
                    break;
                case 3:
                    accelerator = context.CreateCudaAccelerator(0);
                    break;
            }

            renderraykernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<byte>, ArrayView<byte>, int, int, float, float, float, float, byte, byte, byte, float, int, float>(RenderRayKernel);
        }

        private void AcceleratedRenderShadows(byte[] inp, byte[] outp)
        {
            using (MemoryBuffer1D<byte, Stride1D.Dense> output = accelerator.Allocate1D<byte>(outp))
            using (MemoryBuffer1D<byte, Stride1D.Dense> input = accelerator.Allocate1D<byte>(inp))
            {
                int wid = GetData().Width;
                int hei = GetData().Height;

                float dx = MathF.Cos((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
                float dy = MathF.Sin((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
                float dh = MathF.Cos((angle + 90) * MathF.PI / 180);

                float amb = ((float)ambient) / 255;

                byte lr = lightcolor.R;
                byte lg = lightcolor.G;
                byte lb = lightcolor.B;

                renderraykernel(wid * hei, input.View, output.View, wid, hei, dx, dy, dh, amb, lr, lg, lb, dropoff, bias, intensity);
                accelerator.Synchronize();

                Array.Copy(output.GetAsArray1D<byte>(), outp, outp.Length);
            }  
        }

        static void RenderRayKernel(Index1D index, ArrayView<byte> inp, ArrayView<byte> outp, int wid, int hei, float dx, float dy, float dh, float amb, byte lr, byte lg, byte lb, float dropoff, int bias, float intensity)
        {
            int i = index * 4;
            float x = index % wid;
            float y = index / wid;
            float h = inp[i];
            float luminosity = 1f;
            while (x < wid && x >= 0 && y < hei && y >= 0 && h <= 255 && h >= 0 && luminosity > 0)
            {
                if (luminosity > 1 + dropoff * (h - bias - inp[wid * (int)y * 4 + (int)x * 4]))
                {
                    luminosity = 1 + dropoff * (h - bias - inp[wid * (int)y * 4 + (int)x * 4]);
                }

                x += dx;
                y += dy;
                h += dh;
            }

            float outr = amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255;
            float outg = amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255;
            float outb = amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255;

            /*outp[i + 2] = (byte)IntrinsicMath.Clamp(outr, 0, 255);
            outp[i + 1] = (byte)IntrinsicMath.Clamp(outg, 0, 255);
            outp[i + 0] = (byte)IntrinsicMath.Clamp(outb, 0, 255);*/

            if (outr > 255)
            {
                outr = 255;
            }
            if (outr < 0)
            {
                outr = 0;
            }
            outp[i + 2] = (byte)outr;

            if (outg > 255)
            {
                outg = 255;
            }
            if (outg < 0)
            {
                outg = 0;
            }
            outp[i + 1] = (byte)outg;

            if (outb > 255)
            {
                outb = 255;
            }
            if (outb < 0)
            {
                outb = 0;
            }
            outp[i + 0] = (byte)outb;

            outp[i + 3] = 255;
            //outp[i + 2] = (byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255);
            //outp[i + 1] = (byte)Math.Clamp(amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255, 0, 255);
            //outp[i + 0] = (byte)Math.Clamp(amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255, 0, 255);
        }

        /// <summary>
        /// GradientTerrainShader constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public RayTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            lightcolor = Color.FromArgb(255, 255, 255, 255);

            dropoff = 0.1f;
            direction = 20f;
            angle = 360f - 30f;
            bias = 0;
            intensity = 0.6f;
            ambient = 100;

            CompileKernel();
        }
    }
}