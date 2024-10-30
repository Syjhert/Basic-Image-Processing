using System.Diagnostics;
using System.Windows.Forms;
using WebCamLib;
using ImageProcess2;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Device[] devices;
        Bitmap b;
        bool webcamMode;
        enum filter
        {
            None,
            Gray,
            Inversion,
            Contrast,
            Brightness
        }
        filter webcamFilter;
        public Form1()
        {
            InitializeComponent();
            webcamFilter = filter.None;
            webcamMode = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loaded = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = loaded;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                processed.Save(saveFileDialog1.FileName);
            }
        }
        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, pixel);
                }
            }
            pictureBox2.Image = processed;
        }



        private void greyscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //compressed color to 1 byte cuz we use the grey for the RGB
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            int average;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    average = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    Color grey = Color.FromArgb(average, average, average);
                    processed.SetPixel(x, y, grey);
                }
            }
            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //inverting an inverted image will get the original image
            //used to see the darker sides of an image
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    Color inverted = Color.FromArgb(
                        255 - pixel.R, 255 - pixel.G, 255 - pixel.B
                    );
                    processed.SetPixel(x, y, inverted);
                }
            }
            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(loaded.Width - x - 1, y, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, loaded.Height - y - 1, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            BasicDIP.Hist(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                webcamFilter = filter.Brightness;
                timer1.Enabled = true;
            }
            else
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                BasicDIP.Brightness(loaded, ref processed, brightnessTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                webcamFilter = filter.Contrast;
                timer1.Enabled = true;
            }
            else
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                BasicDIP.Equalisation(loaded, ref processed, contrastTrackBar.Value);
                //System.Diagnostics.Debug.WriteLine(contrastTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            BasicDIP.Rotate(loaded, ref processed, rotateTrackBar.Value);
            pictureBox2.Image = processed;
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            BasicDIP.Scale(loaded, ref processed, 200, 200);
            pictureBox2.Image = processed;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            processed = new Bitmap(loaded.Width, loaded.Height);

            Color pixel;
            int ave;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    pixel = loaded.GetPixel(x, y);
                    ave = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    if (ave < 180)
                    {
                        processed.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        processed.SetPixel(x, y, Color.White);
                    }
                }
            }
            pictureBox2.Image = processed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            devices = DeviceManager.GetAllDevices();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devices[0].ShowWindow(pictureBox1);
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devices[0].Stop();
            timer1.Enabled = false;
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Gray;
            timer1.Enabled = true;
        }
        private void inversionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Inversion;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Implicit Data can be any type of data (object or primitive type)
            IDataObject data;
            Image bmap;

            // Get 1 Frame from the Webcam
            devices[0].Sendmessage();
            data = Clipboard.GetDataObject();
            bmap = (Image)data.GetData("System.Drawing.Bitmap", true);
            b = new Bitmap(bmap);

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (webcamFilter)
            {
                case filter.Gray:
                    ImageProcess2.BitmapFilter.GrayScale(b);
                    pictureBox2.Image = b;
                    break;
                case filter.Inversion:
                    ImageProcess2.BitmapFilter.Invert(b);
                    pictureBox2.Image = b;
                    break;
                case filter.Contrast:
                    BasicDIP.Equalisation(b, ref processed, contrastTrackBar.Value);
                    pictureBox2.Image = processed;
                    break;
                case filter.Brightness:
                    BasicDIP.Brightness(b, ref processed, brightnessTrackBar.Value);
                    pictureBox2.Image = processed;
                    break;
                default:
                    break;
            }

        }

        
    }
}
