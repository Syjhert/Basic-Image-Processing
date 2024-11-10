using System.Diagnostics;
using System.Windows.Forms;
using WebCamLib;
using ImageProcess2;
using System.CodeDom;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Device[] devices;
        Bitmap b;

        //AForge
        private FilterInfoCollection videoDevices;   // List of available video devices
        private VideoCaptureDevice videoSource;

        int webcamMode;
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
            Subtract,
            Smoothing,
            GaussianBlur,
            Sharpen,
            MeanRemoval,
            EmbossLaplascian,
            EmbossHoriVerti,
            EmbossAllDirection,
            EmbossLossy,
            EmbossHorizontal,
            EmbossVertical
        }
        filter webcamFilter;
        public Form1()
        {
            InitializeComponent();
            webcamFilter = filter.None;
            webcamMode = 0;

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
                sepiaToolStripMenuItem,
                smoothingToolStripMenuItem,
                gaussianBlurToolStripMenuItem,
                sharpenToolStripMenuItem,
                meanRemovalToolStripMenuItem,
                embossToolStripMenuItem,
                laplascianToolStripMenuItem,
                horizontalVerticalToolStripMenuItem,
                allDirectionsToolStripMenuItem,
                lossyToolStripMenuItem1,
                horizontalToolStripMenuItem1,
                verticalToolStripMenuItem1
            };
            foreach (ToolStripMenuItem item in nonContinuousFilters)
            {
                item.Click += turnOffTimer;
            }

            // AForge
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Debug.WriteLine("DEVICES:  ");
            foreach (FilterInfo device in videoDevices)
                Debug.WriteLine($"Device [{device.Name}]");

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
            }
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            devices = DeviceManager.GetAllDevices();
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
        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = frame; // Display the frame in pictureBox1
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            turnOffCameraMode();
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
            if (webcamMode != 0)
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
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.PixelCopy(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void greyscalingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Grayscaling(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Inversion(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.MirrorHorizontal(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.MirrorVertical(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Hist(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        //Brightness
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (webcamMode != 0)
            {
                webcamFilter = filter.Brightness;
                timer1.Enabled = true;
            }
            else if (loaded != null)
            {
                BasicDIP.Brightness(loaded, ref processed, brightnessTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            if (webcamMode != 0)
            {
                webcamFilter = filter.Contrast;
                timer1.Enabled = true;
            }
            else if (loaded != null)
            {
                BasicDIP.Equalisation(loaded, ref processed, contrastTrackBar.Value);
                //System.Diagnostics.Debug.WriteLine(contrastTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        //Rotation
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            if (webcamMode != 0)
            {
                webcamFilter = filter.Rotate;
                timer1.Enabled = true;
            }
            else if (loaded != null)
            {
                BasicDIP.Rotate(loaded, ref processed, rotateTrackBar.Value);
                pictureBox2.Image = processed;
            }
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            BasicDIP.Scale(loaded, ref processed, 200, 200);
            pictureBox2.Image = processed;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            processed = new Bitmap(loaded.Width, loaded.Height);

            BasicDIP.Binary(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Sepia(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Smoothing(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.GaussianBlur(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.Sharpen(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.MeanRemoval(loaded, ref processed);
            pictureBox2.Image = processed;
        }
        private void laplascianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossLaplascian(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void horizontalVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossHoriVerti(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void allDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossAllDirections(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void lossyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossLossy(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossHorizontal(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
                loaded = getOneFrame();
            else if (loaded == null)    //normal picture mode and no image is loaded yet
                return;

            BasicDIP.EmbossVertical(loaded, ref processed);
            pictureBox2.Image = processed;
        }

        //Turn on webcam using the Device.cs library given by sir
        private void devicecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webcamMode != 1)
            {
                turnOffCameraMode();
                devices[0].ShowWindow(pictureBox1);
            }
            webcamMode = 1;
        }
        //AForge camera
        private void turnOnAForgeDevice(int deviceId)
        {
            turnOffCameraMode();
            if (videoDevices.Count >= deviceId + 1)
            {
                //first device
                var filterInfo = videoDevices[deviceId];
                Debug.WriteLine($"Connecting to [{filterInfo.Name}]...");
                videoSource = new VideoCaptureDevice(filterInfo.MonikerString);

                videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
                videoSource.Start();

                webcamMode = 2;
            }
            else
            {
                Debug.WriteLine("No video device found.");
            }
        }

        private void videoDevice1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOnAForgeDevice(0);
        }
        private void videoDevice2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOnAForgeDevice(1);
        }
        private void videoDevice3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOnAForgeDevice(2);
        }

        private void turnOffCameraMode()
        {
            if (webcamMode == 1)
            {
                devices[0].Stop();
                timer1.Enabled = false;
            }
            else if (webcamMode == 2)
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }
            }

            pictureBox1.Image = null;
            webcamMode = 0;
        }
        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffCameraMode();
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
        private void smoothingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Smoothing;
            timer1.Enabled = true;
        }
        private void gaussianBlurToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.GaussianBlur;
            timer1.Enabled = true;
        }
        private void sharpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.Sharpen;
            timer1.Enabled = true;
        }
        private void meanRemovalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.MeanRemoval;
            timer1.Enabled = true;
        }
        private void laplascianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossLaplascian;
            timer1.Enabled = true;
        }
        private void horizontalVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossHoriVerti;
            timer1.Enabled = true;
        }
        private void allDirectionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossAllDirection;
            timer1.Enabled = true;
        }
        private void lossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossLossy;
            timer1.Enabled = true;
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossHorizontal;
            timer1.Enabled = true;
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcamFilter = filter.EmbossVertical;
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
                case filter.Smoothing:
                    BasicDIP.Smoothing(b, ref processed);
                    break;
                case filter.GaussianBlur:
                    BasicDIP.GaussianBlur(b, ref processed);
                    break;
                case filter.Sharpen:
                    BasicDIP.Sharpen(b, ref processed);
                    break;
                case filter.MeanRemoval:
                    BasicDIP.MeanRemoval(b, ref processed);
                    break;
                case filter.EmbossLaplascian:
                    BasicDIP.EmbossLaplascian(b, ref processed);
                    break;
                case filter.EmbossHoriVerti:
                    BasicDIP.EmbossHoriVerti(b, ref processed);
                    break;
                case filter.EmbossAllDirection:
                    BasicDIP.EmbossAllDirections(b, ref processed);
                    break;
                case filter.EmbossLossy:
                    BasicDIP.EmbossLossy(b, ref processed);
                    break;
                case filter.EmbossHorizontal:
                    BasicDIP.EmbossHorizontal(b, ref processed);
                    break;
                case filter.EmbossVertical:
                    BasicDIP.EmbossVertical(b, ref processed);
                    break;
                default:
                    break;
            }
            pictureBox2.Image = processed;

        }
        private Bitmap getOneFrame()
        {
            if (webcamMode == 1)
                return getOneFrameDevice();
            if (webcamMode == 2)
                return getOneFrameAForge();
            return null;
        }
        private Bitmap getOneFrameDevice()
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
        private Bitmap getOneFrameAForge()
        {
            if (pictureBox1.Image == null)
            {
                return null;
            }
            return new Bitmap(pictureBox1.Image);
        }

        //Open file to picturebox1
        private void loadImageBtn_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
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
        private void subtractBtn_Click(object sender, EventArgs e)
        {
            if (webcamMode != 0)
            {
                webcamFilter = filter.Subtract;
                timer1.Enabled = true;
                return;
            }
            else if (pictureBox1.Image == null)
                return;
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
