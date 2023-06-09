﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
  internal class GlassFilter:Filters
  {
    Random rnd = new Random();
    protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
    {
      try
      {
        return sourceImage.GetPixel((int)(x + ((rnd.NextDouble() - 0.5) * 10)), (int)(y + ((rnd.NextDouble() - 0.5) * 10)));
      }
      catch
      {
        return Color.FromArgb(0, 0, 0);
      }
    }
  }
}
