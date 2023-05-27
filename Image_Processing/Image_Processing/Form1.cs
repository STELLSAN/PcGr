namespace Image_Processing
{
    using static Filters;
  public partial class Form1 : Form
  {
    Bitmap image;
    public Form1()
    {
            InitializeComponent();
        }

        private void filtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //Bitmap resultImage = filter.processImage(image, backgroundWorker1);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png,*.jpg*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if(backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }
      

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((GlobalFilter)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new GrayScale();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Sepia();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void intensityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Intensity();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Sobel();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Embossing();
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalFilter grayWorld = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(grayWorld);
        }

    private void dlationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dilation dilation = new Dilation();
      Bitmap resultImage = dilation.processImage(image);
      pictureBox1.Image = resultImage;
      pictureBox1.Refresh();
      image = resultImage;
    }

    private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Erosion erosion = new Erosion();
      Bitmap resultImage = erosion.processImage(image);
      pictureBox1.Image = resultImage;
      pictureBox1.Refresh();
      image = resultImage;
    }

    private void openingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Opening open = new Opening();
      Bitmap resultImage = open.processImage(image);
      pictureBox1.Image = resultImage;
      pictureBox1.Refresh();
      image = resultImage;
    }

    private void closingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Closing close = new Closing();
      Bitmap resultImage = close.processImage(image);
      pictureBox1.Image = resultImage;
      pictureBox1.Refresh();
      image = resultImage;
    }

    private void medianToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Filters filter = new Medianfilter();
      backgroundWorker1.RunWorkerAsync(filter);
    }

  

    private void secondWaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Filters filter = new WaweFilterSecond();
      backgroundWorker1.RunWorkerAsync(filter);
    }

    private void firstWaveToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      Filters filter = new WaweFilterFirst();
      backgroundWorker1.RunWorkerAsync(filter);
    }

        private void grayWorldToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GlobalFilter filter = new GrayWorld();
            backgroundWorker2.RunWorkerAsync(filter);
        }

        private void glassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramStretching His = new HistogramStretching();
            Bitmap resultImage = His.CalculateBarChart(image);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
        }

        
    }
}