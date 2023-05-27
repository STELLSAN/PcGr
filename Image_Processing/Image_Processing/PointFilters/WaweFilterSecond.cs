using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{ 
  internal class WaweFilterSecond:Filters
  {
    protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
    {
      try
      {
        return sourceImage.GetPixel((int)(x + (20 * Math.Sin((2 * Math.PI * y) / 60))), y);
      }
      catch
      {
        return Color.FromArgb(0, 0, 0);
      }
    }
  }
}
