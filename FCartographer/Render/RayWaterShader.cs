using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using FCartographer.ColorUtility;

namespace FCartographer
{
    /// <summary>
    /// Render class that renders optionally lit water.
    /// </summary>
    public class RayWaterShader : Renderer
    {
        /// <summary>
        /// intensity of light source on waves
        /// </summary>
        public float waveintensity;
        /// <summary>
        /// Intensity of light source
        /// </summary>
        public float intensity;
        /// <summary>
        /// Intensity of ambient light source
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
        /// Level at which the water sits on the terrain
        /// </summary>
        public byte level;
        private HeightLayer terrain;

        /// <summary>
        /// Color of water
        /// </summary>
        public Color c1;

        /// <summary>
        /// Color of incident light
        /// </summary>
        public Color lightcolor;

        /// <summary>
        /// Color of shadow
        /// </summary>
        public Color shadowcolor;

        /// <summary>
        /// Float between 0 and 1 that dictates how bright the incident light is
        /// </summary>
        public float brightness;

        /// <summary>
        /// Whether or not to render waves
        /// </summary>
        public bool render_waves;
        /// <summary>
        /// Whether or not to render ray-based shadows and lighting
        /// </summary>
        public bool render_rays;
        /// <summary>
        /// Whether or not to render the depth of the water
        /// </summary>
        public bool render_depth;
        /// <summary>
        /// Whether or not to render the reflection of the sun on the waves
        /// </summary>
        public bool render_sun_reflection;

        /// <summary>
        /// Int representing how the program handles depth.
        /// 
        /// 0 = opacity mode
        /// 1 = falloff mode
        /// </summary>
        public int depthmode;

        /// <summary>
        /// 
        /// </summary>
        public int dropoffdepth;

        /// <summary>
        /// Float representing the contrast of the water
        /// 0 - 1
        /// </summary>
        public float watercontrast = 0.1f;

        /// <summary>
        /// determines whether or not to use terrain lighting
        /// </summary>
        public bool independentlighting;

        /// <summary>
        /// Override Render function
        /// </summary>
        public override void Render()
        {
            RenderWater();
        }

        /// <summary>
        /// Masks and renders the water according to an internal sun
        /// </summary>
        public void RenderWater()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            byte[] terr = null;
            if (terrain != null)
            {
                terr = BitmapDataConverter.BitmapToByteArray(terrain.GetData());
            }

            float dx = MathF.Cos((180 + direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dy = MathF.Sin((180 + direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dh = MathF.Cos((angle + 90) * MathF.PI / 180);

            int min = 255;
            int max = 0;
            for (int i = 0; i < inp.Length; i++)
            {
                if (inp[i] < min)
                {
                    min = inp[i];
                }
                if (inp[i] > max)
                {
                    max = inp[i];
                }
            }

            lightcolor = Color.FromArgb(255, 200, 255, 255);


            int range = max - min;

            byte lr = lightcolor.R;
            byte lg = lightcolor.G;
            byte lb = lightcolor.B;

            float amb = ((float)ambient) / 255;

            watercontrast = 0.017f;

            Color litcolor = Color.FromArgb(
                255,
                (byte)Math.Clamp(amb * c1.R + watercontrast * lr * intensity * ((float)c1.R) / 255, 0, 255),
                (byte)Math.Clamp(amb * c1.G + watercontrast * lg * intensity * ((float)c1.G) / 255, 0, 255),
                (byte)Math.Clamp(amb * c1.B + watercontrast * lb * intensity * ((float)c1.B) / 255, 0, 255));

            /*ColorHSL litcolorHSL;

            litcolorHSL = ColorHSL.FromARGB(c1);
            litcolorHSL.L = Math.Clamp(litcolorHSL.L + watercontrast, 0, 1);
            litcolor = litcolorHSL.ToARGB();*/

            for (int i = 0; i < wid * hei; i += 4)
            {
                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                // Mask calculation
                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                if (terr != null && terr[i] > level)
                {
                    outp[i + 3] = 0;
                    continue;
                }

                byte a = c1.A;
                byte r = c1.R;
                byte g = c1.G;
                byte b = c1.B;

                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                // Wave rendering
                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---

                if (render_waves)
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

                    float x = ((adj[0, 0] + adj[1, 0]) / 2 - (adj[0, 1] + adj[1, 1]) / 2) * waveintensity;
                    float y = ((adj[0, 0] + adj[0, 1]) / 2 - (adj[1, 0] + adj[1, 1]) / 2) * waveintensity;

                    // X and Y of light source vector

                    float xl = MathF.Cos((angle + 90) * MathF.PI / 180);
                    float yl = MathF.Sin((angle + 90) * MathF.PI / 180);

                    // Projection magnitude of pixel vector and light source vector

                    float xf = (x * xl + y * yl) * xl;
                    float yf = (x * xl + y * yl) * yl;
                    float magnitude = MathF.Sqrt(MathF.Pow(xf, 2) + MathF.Pow(yf, 2));

                    // Direction of pixel vector in relation to light source vector (Whether the magnitude is positive or negative)

                    int dir;
                    if (MathF.Abs(xf + xl) < MathF.Abs(xf))
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }

                    // Write to output

                    a = 255;
                    r = (byte)Lerper.Lerp(litcolor.R, c1.R, Math.Clamp(dir * magnitude + 128, 0, 255) / 256);
                    g = (byte)Lerper.Lerp(litcolor.G, c1.G, Math.Clamp(dir * magnitude + 128, 0, 255) / 256);
                    b = (byte)Lerper.Lerp(litcolor.B, c1.B, Math.Clamp(dir * magnitude + 128, 0, 255) / 256);
                }

                if (terr != null)
                {
                    // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                    // Ray lighting calculation
                    // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---

                    render_rays = true;

                    if (render_rays)
                    {
                        float x = i % wid / 4;
                        float y = i / wid;

                        float h;
                        render_waves = true;
                        if (render_waves)
                        {
                            h = inp[i] / range * 10 + level;
                        }
                        else
                        {
                            h = level;
                        }

                        float luminosity = 1f;
                        while (x < wid / 4 && x >= 0 && y < hei && y >= 0 && h <= 255 && h >= 0 && luminosity > 0)
                        {
                            if (luminosity > 1 + dropoff * (h - bias - terr[wid * (int)y + 4 * (int)x]))
                            {
                                luminosity = 1 + dropoff * (h - bias - terr[wid * (int)y + 4 * (int)x]);
                            }

                            x += dx;
                            y += dy;
                            h += dh;
                        }

                        intensity = 0.6f;

                        r = (byte)Math.Clamp(amb * r + luminosity * lr * intensity * ((float)r) / 255, 0, 255);
                        g = (byte)Math.Clamp(amb * g + luminosity * lg * intensity * ((float)g) / 255, 0, 255);
                        b = (byte)Math.Clamp(amb * b + luminosity * lb * intensity * ((float)b) / 255, 0, 255);
                    }

                    // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                    // Depth lighting calculation
                    // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---

                    if (render_depth)
                    {
                        if (depthmode == 0)
                        {
                            a = (byte)Math.Clamp(-(terr[i] - level) + dropoffdepth, 0, 255);
                        }
                        if (depthmode == 1)
                        {

                        }
                    }
                    else
                    {
                        a = 255;
                    }
                    
                }

                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
                // Write to output
                // ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---

                outp[i + 3] = a;
                outp[i + 2] = r;
                outp[i + 1] = g;
                outp[i + 0] = b;
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// Masks water to terrain layer
        /// </summary>
        public void MaskWater()
        {
            byte[] tinp = BitmapDataConverter.BitmapToByteArray(terrain.GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            for (int i = 0; i < outp.Length; i += 4)
            {
                if (tinp[i] > level)
                {
                    outp[i + 3] = 0;
                }
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// Sets the terrain reference for masking
        /// </summary>
        /// <param name="_terrain"></param>
        public void SetTerrain(HeightLayer _terrain)
        {
            terrain = _terrain;
        }

        /// <summary>
        /// Sets the incedent light angle, re-renders
        /// </summary>
        /// <param name="_lightdirection"></param>
        /// <param name="_lightangle"></param>
        public void SetAngles(float _lightdirection, float _lightangle)
        {
            direction = _lightdirection;
            angle = _lightangle;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public RayWaterShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            c1 = Color.FromArgb(255, 0, 39, 232);

            lightcolor = Color.FromArgb(255, 255, 255, 255);
            brightness = 0.5f;

            SetAngles(45, -45);

            waveintensity = 30;
            intensity = 0.6f;
            ambient = 20;
            dropoff = 0.1f;
            direction = -20f;
            angle = -30f;
            bias = 0;

            watercontrast = 0.015f;

            dropoffdepth = 160;
        }
    }
}
