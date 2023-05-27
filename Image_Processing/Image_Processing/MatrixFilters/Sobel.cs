using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
     по оси Y        по оси X
    |-1 -2 -1|      |-1  0  1|
    | 0  0  0|      |-2  0  2|
    | 1  2  1|      |-1  0  1|
 
 */
namespace Image_Processing
{
    internal class Sobel : MatrixFilter
    {
        public Sobel()
        {
            int[,] osY = new int[3,3] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            int[,] osX = new int[3,3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = (float)osY[i,j] + (float)osX[i, j];
                }
            }
        }
    }
}
