using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace FCartographer.Util
{
    internal class BitmapOperations
    {
        internal static void MaskBitmap(Bitmap input, Bitmap mask, Bitmap output)
        {
            byte[] byteinput = new byte[input.Width * input.Height * 4];
            BitmapData dat = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(byteinput, 0, dat.Scan0, byteinput.Length);
            input.UnlockBits(dat);

            byte[] bytemask = new byte[input.Width * input.Height * 4];
            BitmapData dat1 = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(bytemask, 0, dat1.Scan0, bytemask.Length);
            input.UnlockBits(dat1);

            byte[] byteoutput = new byte[input.Width * input.Height * 4];

            for (int i = 0; i < byteinput.Length; i += 4)
            {
                byteoutput[i + 0] = byteinput[i + 0];
                byteoutput[i + 1] = byteinput[i + 1];
                byteoutput[i + 2] = byteinput[i + 2];
                byteoutput[i + 3] = bytemask[i + 2];
            }

            BitmapDataConverter.DrawByteArrayToBitmap(output, byteoutput);
        }

        internal static void ApplyMask(Bitmap input, Bitmap mask)
        {
            byte[] byteinput = new byte[input.Width * input.Height * 4];
            BitmapData dat = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.WriteOnly, input.PixelFormat);
            Marshal.Copy(byteinput, 0, dat.Scan0, byteinput.Length);
            input.UnlockBits(dat);

            byte[] bytemask = new byte[input.Width * input.Height * 4];
            BitmapData dat1 = mask.LockBits(new Rectangle(0, 0, mask.Width, mask.Height), ImageLockMode.WriteOnly, mask.PixelFormat);
            Marshal.Copy(bytemask, 0, dat1.Scan0, bytemask.Length);
            mask.UnlockBits(dat1);

            for (int i = 0; i < byteinput.Length; i += 4)
            {
                byteinput[i + 3] = bytemask[i + 2];
            }

            BitmapDataConverter.DrawByteArrayToBitmap(input, byteinput);
        }
    }
}
