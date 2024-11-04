using System.Diagnostics;
using System.Windows.Forms;
using WebCamLib;
using ImageProcess2;
using System.CodeDom;

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
            Sepia,
            Subtract
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
                sepiaToolStripMenuItem,
                grayToolStripMenuItem,
                inversionToolStripMenuItem1,
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

            ToolStripMenuItem[] nonContinuousFilters =
            {
                pixelCopyToolStripMenuItem,
                greyscalingToolStripMenuItem,
                inversionToolStripMenuItem,
                mirrorHorizontalToolStripMenuItem,
                mirrorVerticalToolStripMenuItem,
                histogramToolStripMenuItem,
                scaleToolStripMenuItem,
                binaryToolStripMenuItem,
                sepiaToolStripMenuItem
            };
            foreach (ToolStripMenuItem item in nonContinuousFilters)
            {
                item.Click += turnOffTimer;
            }
        }
        // Event listener functions
        private void stretchPictureBox(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void turnOffTimer(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        //-----------

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
            if (webcamMode)
            {
                processed = new Bitmap(pictureBox2.Image);
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                processed.Save(saveFileDialog1.FileName);
            }
        }
        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.PixelCopy(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void greyscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.Grayscaling(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.Inversion(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.MirrorHorizontal(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.MirrorVertical(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
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
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            BasicDIP.Scale(loaded, ref processed, 200, 200);
            pictureBox2.Image = processed;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            processed = new Bitmap(loaded.Width, loaded.Height);

            BasicDIP.Binary(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                loaded = getOneFrame();
            }
            BasicDIP.Sepia(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            devices = DeviceManager.GetAllDevices();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!webcamMode)
                devices[0].ShowWindow(pictureBox1);
            webcamMode = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffCameraMode();
        }

        private void turnOffCameraMode()
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
            b = getOneFrame();
            if (b == null)
                return;

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
                    BasicDIP.Scale(b, ref processed, 200, 200);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case filter.Binary:
                    BasicDIP.Binary(b, ref processed);
                    break;
                case filter.Sepia:
                    BasicDIP.Sepia(b, ref processed);
                    break;
                case filter.Subtract:
                    Bitmap background = new Bitmap(pictureBox2.Image);
                    Bitmap result = new Bitmap(background.Width, background.Height);
                    BasicDIP.Subtract(b, background, ref result);
                    pictureBox3.Image = result;
                    return;
                default:
                    break;
            }
            pictureBox2.Image = processed;

        }

        private Bitmap getOneFrame()
        {
            // Implicit Data can be any type of data (object or primitive type)
            IDataObject data;
            Image bmap;

            // Get 1 Frame from the Webcam
            devices[0].Sendmessage();
            data = Clipboard.GetDataObject();
            bmap = (Image)data.GetData("System.Drawing.Bitmap", true);
            if (bmap == null)
            {
                return null;
            }
            return new Bitmap(bmap);
        }

        //Open file to picturebox1
        private void button1_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                turnOffCameraMode();
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                loaded = new Bitmap(openFileDialog2.FileName);
                pictureBox1.Image = loaded;
            }
        }

        //Open file to picturebox1
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                processed = new Bitmap(openFileDialog3.FileName);
                pictureBox2.Image = processed;
            }
        }

        //Subtract button
        private void button3_Click(object sender, EventArgs e)
        {
            if (webcamMode)
            {
                webcamFilter = filter.Subtract;
                timer1.Enabled = true;
                return;
            }
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap background = new Bitmap(pictureBox2.Image);
            Bitmap result = new Bitmap(background.Width, background.Height);
            BasicDIP.Subtract(image, background, ref result);
            pictureBox3.Image = result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null && saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image.Save(saveFileDialog2.FileName);
            }
        }

        private void savePicture2Btn_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null && saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog3.FileName);
            }
        }
    }
}
