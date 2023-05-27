using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Image_Processing
{
    internal class Intensity : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = Clamp(sourceColor.R + 100, 0, 255);
            int G = Clamp(sourceColor.G + 100, 0, 255);
            int B = Clamp(sourceColor.B + 100, 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
