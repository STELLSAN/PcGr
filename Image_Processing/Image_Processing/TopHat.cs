using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    internal class TopHat
    {
        public Bitmap TopHatTransform(Bitmap sourceImage, int a)
        {
            int w = sourceImage.Width;
            int h = sourceImage.Height;

            BitmapData image_data = sourceImage.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            sourceImage.UnlockBits(image_data);

            //opening
           // result = buffer.Erode(image_data, a);
           // result = result.Dilate(image_data, a);
            //top hat transform
            for (int i = 0; i < bytes; i++)
            {
                result[i] = (byte)(buffer[i] - result[i]);
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }
    }
}
