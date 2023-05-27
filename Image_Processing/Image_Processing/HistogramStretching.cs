using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    internal class HistogramStretching
    {
        public Bitmap CalculateBarChart(Bitmap sourceImage)
        {

            /*
            maxVal = image.maximumValue() # 153
            minVal = image.minumumValue() # 84
            dynamic = maxVal-minVal
            for pixel in image.Pixels(){
             newPixel = ((pixel-minVal)/dynamic)*255
            }
             */
            Bitmap barChart = null; 
            int max = 0;
            int min = 999;
            if (sourceImage != null)
            {
                // по пикселю на каждый столбик каждого из каналов
                int width = 768, height = 600;
                // получаем битмап из изображения
                Bitmap bmp = new Bitmap(sourceImage);
                // создаем саму гистограмму
                barChart = new Bitmap(width, height);
                // создаем массивы, в котором будут содержаться количества повторений для каждого из значений каналов.
                // индекс соответствует значению канала
                int[] R = new int[256];
                int[] G = new int[256];
                int[] B = new int[256];
                int i, j;
                Color color;
                // собираем статистику для изображения
                for (i = 0; i < bmp.Width; ++i)
                    for (j = 0; j < bmp.Height; ++j)
                    {
                        color = bmp.GetPixel(i, j);
                        ++R[color.R];
                        ++G[color.G];
                        ++B[color.B];
                    }
                // находим самый высокий столбец, чтобы корректно масштабировать гистограмму по высоте
                for (i = 0; i < 256; ++i)
                {
                    if (R[i] > max)
                        max = R[i];
                    if (G[i] > max)
                        max = G[i];
                    if (B[i] > max)
                        max = B[i];
                }
                // определяем коэффициент масштабирования по высоте
                double point = (double)max / height;
                // отрисовываем столбец за столбцом нашу гистограмму с учетом масштаба
                for (i = 0; i < width - 3; ++i)
                {
                    for (j = height - 1; j > height - R[i / 3] / point; --j)
                    {
                        barChart.SetPixel(i, j, Color.Red);
                    }
                    ++i;
                    for (j = height - 1; j > height - G[i / 3] / point; --j)
                    {
                        barChart.SetPixel(i, j, Color.Green);
                    }
                    ++i;
                    for (j = height - 1; j > height - B[i / 3] / point; --j)
                    {
                        barChart.SetPixel(i, j, Color.Blue);
                    }
                }
            }
            else
                barChart = new Bitmap(1, 1);

            /*
            Color color;
            int dynamic = max - min;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    color = sourceImage.GetPixel(i, j);
                    sourceImage.GetPixel(i, j);
                    color = (c)
                }
            }
            newPixel = ((pixel - minVal) / dynamic) * 255;
            */

            return barChart;
        }

    }
}
