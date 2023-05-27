using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Image_Processing
{
  abstract class GlobalFilter
  {

    protected abstract Bitmap GlobalProcess(Bitmap sourceImage);



    public Bitmap processImage(Bitmap sourseImage, BackgroundWorker worker)
    {
      Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);
      for (int i = 0; i < sourseImage.Width; i++)
      {
        worker.ReportProgress((int)((float)i / resultImage.Width * 100));
        if (worker.CancellationPending) { return null; }
      }
      return resultImage;
    }

  }
}
