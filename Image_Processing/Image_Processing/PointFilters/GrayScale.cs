using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// done
namespace Image_Processing
{
    internal class GrayScale : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double firstIntensity = (0.299 * (double)sourceColor.R) + (0.587 * (double)sourceColor.G) + (0.144 * (double)sourceColor.B);
            int intesity = Clamp((int)firstIntensity, 0, 255);
            Color resultColor = Color.FromArgb(intesity, intesity, intesity);
            return resultColor;
        }
    }
}
