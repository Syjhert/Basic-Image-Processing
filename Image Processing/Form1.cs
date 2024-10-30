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
            Brightness,
            Rotate,
            MirrorHorizontal,
            MirrorVertical,
            Histogram,
            Scale,
            Binary,
            Sepia
        }
        filter webcamFilter;
        public Form1()
        {
            InitializeComponent();
            webcamFilter = filter.None;
            webcamMode = false;

            ToolStripMenuItem[] stretchMenuItems =
            {
                pixelCopyToolStripMenuItem,
                greyscalingToolStripMenuItem,
                inversionToolStripMenuItem,
                mirrorHorizontalToolStripMenuItem,
                mirrorVerticalToolStripMenuItem,
                histogramToolStripMenuItem,
                binaryToolStripMenuItem,
                grayToolStripMenuItem,
                inversionToolStripMenuItem1,
                sepiaToolStripMenuItem,
                mirrorHorizontalToolStripMenuItem1,
                mirrorVerticalToolStripMenuItem1,
                histogramToolStripMenuItem1,
                scaleToolStripMenuItem1,
                binaryToolStripMenuItem1,
                sepiaToolStripMenuItem1
            };

            foreach (ToolStripMenuItem item in stretchMenuItems)
            {
                item.Click += stretchPictureBox;
            }
            loadBackgroundBtn.Click += stretchPictureBox;
        }
        private void stretchPictureBox(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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
            BasicDIP.PixelCopy(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void greyscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.Grayscaling(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.Inversion(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.MirrorHorizontal(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.MirrorVertical(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.Hist(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        //Brightness
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                webcamFilter = filter.Brightness;
                timer1.Enabled = true;
            }
            else
            {
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
                BasicDIP.Equalisation(loaded, ref processed, contrastTrackBar.Value);
                //System.Diagnostics.Debug.WriteLine(contrastTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        //Rotation
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                webcamFilter = filter.Rotate;
                timer1.Enabled = true;
            }
            else
            {
                BasicDIP.Rotate(loaded, ref processed, rotateTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            BasicDIP.Scale(loaded, ref processed, 200, 200);
            pictureBox2.Image = processed;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            BasicDIP.Binary(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicDIP.Sepia(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            devices = DeviceManager.GetAllDevices();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( !webcamMode )
                devices[0].ShowWindow(pictureBox1);
            webcamMode = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devices[0].Stop();
            timer1.Enabled = false;
            pictureBox1.Image = null;
            webcamMode = false;
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
        private void mirrorHorizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.MirrorHorizontal;
            timer1.Enabled = true;
        }

        private void mirrorVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.MirrorVertical;
            timer1.Enabled = true;
        }

        private void histogramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Histogram;
            timer1.Enabled = true;
        }

        private void scaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Scale;
            timer1.Enabled = true;
        }

        private void binaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Binary;
            timer1.Enabled = true;
        }

        private void sepiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Sepia;
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
            if (bmap == null )
            {
                return;
            }
            b = new Bitmap(bmap);

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (webcamFilter)
            {
                case filter.Gray:
                    ImageProcess2.BitmapFilter.GrayScale(b);
                    pictureBox2.Image = b;
                    return;
                case filter.Inversion:
                    ImageProcess2.BitmapFilter.Invert(b);
                    pictureBox2.Image = b;
                    return;
                case filter.Contrast:
                    BasicDIP.Equalisation(b, ref processed, contrastTrackBar.Value);
                    break;
                case filter.Brightness:
                    BasicDIP.Brightness(b, ref processed, brightnessTrackBar.Value);
                    break;
                case filter.Rotate:
                    BasicDIP.Rotate(b, ref processed, rotateTrackBar.Value);
                    break;
                case filter.MirrorHorizontal:
                    BasicDIP.MirrorHorizontal(b, ref processed);
                    break;
                case filter.MirrorVertical:
                    BasicDIP.MirrorVertical(b, ref processed);
                    break;
                case filter.Histogram:
                    BasicDIP.Hist(b, ref processed);
                    break;
                case filter.Scale:
                    BasicDIP.Scale(b, ref processed, 100, 100);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case filter.Binary:
                    BasicDIP.Binary(b, ref processed);
                    break;
                case filter.Sepia:
                    BasicDIP.Sepia(b, ref processed);
                    break;
                default:
                    break;
            }
            pictureBox2.Image = processed;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                loaded = new Bitmap(openFileDialog2.FileName);
                pictureBox1.Image = loaded;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                processed = new Bitmap(openFileDialog3.FileName);
                pictureBox2.Image = processed;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap background = new Bitmap(pictureBox2.Image);
            Bitmap result = new Bitmap(background.Width, background.Height);
            Color green = Color.FromArgb(0, 255, 0);
            int greygreen = (green.R + green.G + green.B) / 3;
            int threshold = 5;
            for (int x = 0; x < background.Width; x++)
            {
                for (int y = 0; y < background.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color backpixel = background.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractValue = Math.Abs(grey - greygreen);

                    if (subtractValue > threshold)
                        result.SetPixel(x, y, pixel);
                    else
                        result.SetPixel(x, y, backpixel);
                }
            }
            pictureBox3.Image = result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog1.FileName);
            }
        }
    }
}
