using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class GradientTerrainShader : Renderer
    {
        /// <summary>
        /// Intensity of light source
        /// </summary>
        public float intensity;
        /// <summary>
        /// Ambient lighting value
        /// </summary>
        public int ambient;
        /// <summary>
        /// Persistance of light
        /// </summary>
        public int persistance;
        /// <summary>
        /// Angle of light source
        /// </summary>
        public float angle;
        /// <summary>
        /// Factor by which to flatten the lighting
        /// </summary>
        public int flatten;

        /// <summary>
        /// 0 = precise
        /// 1 = smooth
        /// </summary>
        public int vectormode;

        /// <summary>
        /// Color of light source
        /// </summary>
        public Color lightcolor;

        /// <summary>
        /// Render override function
        /// </summary>
        public override void Render()
        {
            if (vectormode == 0)
            {
                RenderShadows();
            }
        }

        private void RenderShadows()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            float amb = ((float)ambient) / 255;

            byte lr = lightcolor.R;
            byte lg = lightcolor.G;
            byte lb = lightcolor.B;

            for (int i = 0; i < wid * hei; i += 4)
            {
                int dir = 0;
                float magnitude = 0;
                
                if (vectormode == 0)
                {
                    int[,] adj = new int[,] { { -1, -1 }, { -1, -1 } };

                    // Build matrix of adjacent bytes

                    // Check if down valid
                    bool downvalid = i + wid < inp.Length;
                    bool rightvalid = i % wid != wid - 4;

                    adj[0, 0] = inp[i];

                    if (downvalid)
                    {
                        adj[0, 1] = inp[i + wid];
                    }

                    if (rightvalid)
                    {
                        adj[1, 0] = inp[i + 4];
                    }

                    if (downvalid && rightvalid)
                    {
                        adj[1, 1] = inp[i + wid + 4];
                    }

                    // X and Y of current pixel vector

                    float x = ((adj[0, 0] + adj[1, 0]) / 2 - (adj[0, 1] + adj[1, 1]) / 2);
                    float y = ((adj[0, 0] + adj[0, 1]) / 2 - (adj[1, 0] + adj[1, 1]) / 2);

                    // X and Y of light source vector

                    float xl = MathF.Cos((angle + 90) * MathF.PI / 180);
                    float yl = MathF.Sin((angle + 90) * MathF.PI / 180);

                    // Projection magnitude of pixel vector and light source vector

                    float xf = (x * xl + y * yl) * xl;
                    float yf = (x * xl + y * yl) * yl;
                    magnitude = MathF.Sqrt(MathF.Pow(xf, 2) + MathF.Pow(yf, 2));

                    // Direction of pixel vector in relation to light source vector (Whether the magnitude is positive or negative)

                    if (MathF.Abs(xf + xl) < MathF.Abs(xf))
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }
                }
                else if (vectormode == 1)
                {
                    int[,] adj = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };

                    // Build matrix of adjacent bytes

                    // Check if down valid
                    bool downvalid = i + wid < inp.Length;
                    bool rightvalid = i % wid != wid - 4;

                    adj[0, 0] = inp[i];

                    if (downvalid)
                    {
                        adj[0, 1] = inp[i + wid];
                    }

                    if (rightvalid)
                    {
                        adj[1, 0] = inp[i + 4];
                    }

                    if (downvalid && rightvalid)
                    {
                        adj[1, 1] = inp[i + wid + 4];
                    }

                    // X and Y of current pixel vector

                    float x = ((adj[0, 0] + adj[1, 0]) / 2 - (adj[0, 1] + adj[1, 1]) / 2);
                    float y = ((adj[0, 0] + adj[0, 1]) / 2 - (adj[1, 0] + adj[1, 1]) / 2);

                    // X and Y of light source vector

                    float xl = MathF.Cos((angle + 90) * MathF.PI / 180);
                    float yl = MathF.Sin((angle + 90) * MathF.PI / 180);

                    // Projection magnitude of pixel vector and light source vector

                    float xf = (x * xl + y * yl) * xl;
                    float yf = (x * xl + y * yl) * yl;
                    magnitude = MathF.Sqrt(MathF.Pow(xf, 2) + MathF.Pow(yf, 2));

                    // Direction of pixel vector in relation to light source vector (Whether the magnitude is positive or negative)

                    if (MathF.Abs(xf + xl) < MathF.Abs(xf))
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }
                }
                //System.Diagnostics.Debug.WriteLine(magnitude);

                float luminosity = Math.Clamp(dir * magnitude / flatten + persistance, 0, 255);

                // Write to output

                outp[i + 3] = 255;
                outp[i + 2] = (byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255); //(byte)Lerper.Lerp(Lerper.Lerp(lightcolor.R, darkcolor.R, Math.Clamp(dir * magnitude + 128, 0, 255) / 256), outp[i + 2], 1 - opacity);
                outp[i + 1] = (byte)Math.Clamp(amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255, 0, 255);
                outp[i + 0] = (byte)Math.Clamp(amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255, 0, 255);

                //(byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255);
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// GradientTerrainShader constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public GradientTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            angle = 220f;
            ambient = 30;
            intensity = 0.6f;

            persistance = 1;
            flatten = 5;

            lightcolor = Color.White;
        }
    }
}