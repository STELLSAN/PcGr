using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{

    // ???
    internal class GrayWorld : GlobalFilter
    {
        protected override Bitmap GlobalProcess(Bitmap sourceImage)
        {
            // кол-во пикселей
            int pixN= (sourceImage.Width) * (sourceImage.Height);
            // суммы
            int sumR = 0;
            int sumG = 0;
            int sumB = 0;
            Color color;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    color = sourceImage.GetPixel(i, j);
                    sumR += color.R;
                    sumG += color.G;
                    sumB += color.B;
                }
            }
            sumR *= (1 / pixN);
            sumG *= (1 / pixN);
            sumB *= (1 / pixN);
            int Avg = (sumR + sumG + sumB) / 3; 
            int finR;
            int finG;
            int finB;
            Color resultColor;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    color = sourceImage.GetPixel(i, j);
                    finR = color.R * (Avg/sumR);
                    finG = color.G * (Avg / sumG);
                    finB = color.B * (Avg / sumB);
                    resultColor = Color.FromArgb(finR, finG, finB);
                    sourceImage.SetPixel(i, j, resultColor); ;
                }
            }
        return sourceImage;

        }
    }
}
