using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
  internal class Closing
  {
    public Bitmap processImage(Bitmap sourceImage)
    {
      int W = sourceImage.Width;
      int H = sourceImage.Height;
      Bitmap resultImage = new Bitmap(W, H);
      Bitmap resultImage2 = new Bitmap(W, H);

      int MW = 3;
      int MH = 3;
      int[,] mask = new int[MW, MH];

      mask[0, 0] = 1;
      mask[0, 1] = 1;
      mask[0, 2] = 1;

      mask[1, 0] = 1;
      mask[1, 1] = 1;
      mask[1, 2] = 1;

      mask[2, 0] = 1;
      mask[2, 1] = 1;
      mask[2, 2] = 1;

      for (int y = MH / 2; y < H - MH / 2; y++)
      {
        for (int x = MW / 2; x < W - MW / 2; x++)
        {
          int max = 0;
          for (int j = -MH / 2; j <= MH / 2; j++)
          {
            for (int i = -MW / 2; i <= MW / 2; i++)
            {
              if ((mask[i + MW / 2, j + MH / 2] == 1) && (sourceImage.GetPixel(x + i, y + j).R > max))
              {
                max = sourceImage.GetPixel(x + i, y + j).R;
              }
            }
            resultImage.SetPixel(x, y, Color.FromArgb(255, max, max, max));
          }
        }
      }
      for (int y = MH / 2; y < H - MH / 2; y++)
      {
        for (int x = MW / 2; x < W - MW / 2; x++)
        {
          int min = 255;
          for (int j = -MH / 2; j <= MH / 2; j++)
          {
            for (int i = -MW / 2; i <= MW / 2; i++)
            {
              if ((mask[i + MW / 2, j + MH / 2] == 1) && (resultImage.GetPixel(x + i, y + j).R < min))
              {
                min = resultImage.GetPixel(x + i, y + j).R;
              }
            }
            resultImage2.SetPixel(x, y, Color.FromArgb(255, min, min, min));
          }
        }
      }
      return resultImage2;
    }
  }
}
