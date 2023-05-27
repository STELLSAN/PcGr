using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    internal class Sepia: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = Clamp((int)(sourceColor.R + (2 * 8)), 0, 255);
            int G = Clamp((int)(sourceColor.G + (0.5 * 8)), 0, 255);
            int B = Clamp((int)(sourceColor.B - (1 * 8)), 0, 255); 
            Color resultColor = Color.FromArgb(R,G,B);
            return resultColor;
        }
    }
}
