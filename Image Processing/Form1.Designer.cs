namespace Image_Processing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            greyscalingToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem = new ToolStripMenuItem();
            mirrorHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            scaleToolStripMenuItem = new ToolStripMenuItem();
            binaryToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            onToolStripMenuItem = new ToolStripMenuItem();
            offToolStripMenuItem = new ToolStripMenuItem();
            vIDEOToolStripMenuItem = new ToolStripMenuItem();
            grayToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem1 = new ToolStripMenuItem();
            mirrorHorizontalToolStripMenuItem1 = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem1 = new ToolStripMenuItem();
            histogramToolStripMenuItem1 = new ToolStripMenuItem();
            scaleToolStripMenuItem1 = new ToolStripMenuItem();
            binaryToolStripMenuItem1 = new ToolStripMenuItem();
            sepiaToolStripMenuItem1 = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            brightnessTrackBar = new TrackBar();
            contrastTrackBar = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            rotateTrackBar = new TrackBar();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox3 = new PictureBox();
            loadImageBtn = new Button();
            loadBackgroundBtn = new Button();
            subtractBtn = new Button();
            openFileDialog2 = new OpenFileDialog();
            openFileDialog3 = new OpenFileDialog();
            button1 = new Button();
            saveFileDialog2 = new SaveFileDialog();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            savePicture2Btn = new Button();
            saveFileDialog3 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contrastTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotateTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, dIPToolStripMenuItem, onToolStripMenuItem, offToolStripMenuItem, vIDEOToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1327, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(128, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(128, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, greyscalingToolStripMenuItem, inversionToolStripMenuItem, mirrorHorizontalToolStripMenuItem, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem, scaleToolStripMenuItem, binaryToolStripMenuItem, sepiaToolStripMenuItem });
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(46, 24);
            dIPToolStripMenuItem.Text = "DIP";
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(207, 26);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += pixelCopyToolStripMenuItem_Click;
            // 
            // greyscalingToolStripMenuItem
            // 
            greyscalingToolStripMenuItem.Name = "greyscalingToolStripMenuItem";
            greyscalingToolStripMenuItem.Size = new Size(207, 26);
            greyscalingToolStripMenuItem.Text = "Greyscaling";
            greyscalingToolStripMenuItem.Click += greyscalingToolStripMenuItem_Click;
            // 
            // inversionToolStripMenuItem
            // 
            inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            inversionToolStripMenuItem.Size = new Size(207, 26);
            inversionToolStripMenuItem.Text = "Inversion";
            inversionToolStripMenuItem.Click += inversionToolStripMenuItem_Click;
            // 
            // mirrorHorizontalToolStripMenuItem
            // 
            mirrorHorizontalToolStripMenuItem.Name = "mirrorHorizontalToolStripMenuItem";
            mirrorHorizontalToolStripMenuItem.Size = new Size(207, 26);
            mirrorHorizontalToolStripMenuItem.Text = "Mirror Horizontal";
            mirrorHorizontalToolStripMenuItem.Click += mirrorHorizontalToolStripMenuItem_Click;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(207, 26);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += mirrorVerticalToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(207, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // scaleToolStripMenuItem
            // 
            scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            scaleToolStripMenuItem.Size = new Size(207, 26);
            scaleToolStripMenuItem.Text = "Scale";
            scaleToolStripMenuItem.Click += scaleToolStripMenuItem_Click;
            // 
            // binaryToolStripMenuItem
            // 
            binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            binaryToolStripMenuItem.Size = new Size(207, 26);
            binaryToolStripMenuItem.Text = "Binary";
            binaryToolStripMenuItem.Click += binaryToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(207, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // onToolStripMenuItem
            // 
            onToolStripMenuItem.Name = "onToolStripMenuItem";
            onToolStripMenuItem.Size = new Size(42, 24);
            onToolStripMenuItem.Text = "On";
            onToolStripMenuItem.Click += onToolStripMenuItem_Click;
            // 
            // offToolStripMenuItem
            // 
            offToolStripMenuItem.Name = "offToolStripMenuItem";
            offToolStripMenuItem.Size = new Size(44, 24);
            offToolStripMenuItem.Text = "Off";
            offToolStripMenuItem.Click += offToolStripMenuItem_Click;
            // 
            // vIDEOToolStripMenuItem
            // 
            vIDEOToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { grayToolStripMenuItem, inversionToolStripMenuItem1, mirrorHorizontalToolStripMenuItem1, mirrorVerticalToolStripMenuItem1, histogramToolStripMenuItem1, scaleToolStripMenuItem1, binaryToolStripMenuItem1, sepiaToolStripMenuItem1 });
            vIDEOToolStripMenuItem.Name = "vIDEOToolStripMenuItem";
            vIDEOToolStripMenuItem.Size = new Size(66, 24);
            vIDEOToolStripMenuItem.Text = "VIDEO";
            // 
            // grayToolStripMenuItem
            // 
            grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            grayToolStripMenuItem.Size = new Size(207, 26);
            grayToolStripMenuItem.Text = "Grayscale";
            grayToolStripMenuItem.Click += grayToolStripMenuItem_Click;
            // 
            // inversionToolStripMenuItem1
            // 
            inversionToolStripMenuItem1.Name = "inversionToolStripMenuItem1";
            inversionToolStripMenuItem1.Size = new Size(207, 26);
            inversionToolStripMenuItem1.Text = "Inversion";
            inversionToolStripMenuItem1.Click += inversionToolStripMenuItem1_Click;
            // 
            // mirrorHorizontalToolStripMenuItem1
            // 
            mirrorHorizontalToolStripMenuItem1.Name = "mirrorHorizontalToolStripMenuItem1";
            mirrorHorizontalToolStripMenuItem1.Size = new Size(207, 26);
            mirrorHorizontalToolStripMenuItem1.Text = "Mirror Horizontal";
            mirrorHorizontalToolStripMenuItem1.Click += mirrorHorizontalToolStripMenuItem1_Click;
            // 
            // mirrorVerticalToolStripMenuItem1
            // 
            mirrorVerticalToolStripMenuItem1.Name = "mirrorVerticalToolStripMenuItem1";
            mirrorVerticalToolStripMenuItem1.Size = new Size(207, 26);
            mirrorVerticalToolStripMenuItem1.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem1.Click += mirrorVerticalToolStripMenuItem1_Click;
            // 
            // histogramToolStripMenuItem1
            // 
            histogramToolStripMenuItem1.Name = "histogramToolStripMenuItem1";
            histogramToolStripMenuItem1.Size = new Size(207, 26);
            histogramToolStripMenuItem1.Text = "Histogram";
            histogramToolStripMenuItem1.Click += histogramToolStripMenuItem1_Click;
            // 
            // scaleToolStripMenuItem1
            // 
            scaleToolStripMenuItem1.Name = "scaleToolStripMenuItem1";
            scaleToolStripMenuItem1.Size = new Size(207, 26);
            scaleToolStripMenuItem1.Text = "Scale";
            scaleToolStripMenuItem1.Click += scaleToolStripMenuItem1_Click;
            // 
            // binaryToolStripMenuItem1
            // 
            binaryToolStripMenuItem1.Name = "binaryToolStripMenuItem1";
            binaryToolStripMenuItem1.Size = new Size(207, 26);
            binaryToolStripMenuItem1.Text = "Binary";
            binaryToolStripMenuItem1.Click += binaryToolStripMenuItem1_Click;
            // 
            // sepiaToolStripMenuItem1
            // 
            sepiaToolStripMenuItem1.Name = "sepiaToolStripMenuItem1";
            sepiaToolStripMenuItem1.Size = new Size(207, 26);
            sepiaToolStripMenuItem1.Text = "Sepia";
            sepiaToolStripMenuItem1.Click += sepiaToolStripMenuItem1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 169);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(422, 393);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(452, 169);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(422, 393);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // brightnessTrackBar
            // 
            brightnessTrackBar.Location = new Point(380, 31);
            brightnessTrackBar.Maximum = 50;
            brightnessTrackBar.Minimum = -50;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(302, 56);
            brightnessTrackBar.TabIndex = 3;
            brightnessTrackBar.Scroll += trackBar1_Scroll;
            // 
            // contrastTrackBar
            // 
            contrastTrackBar.Location = new Point(60, 31);
            contrastTrackBar.Maximum = 100;
            contrastTrackBar.Minimum = 1;
            contrastTrackBar.Name = "contrastTrackBar";
            contrastTrackBar.Size = new Size(302, 56);
            contrastTrackBar.TabIndex = 4;
            contrastTrackBar.Value = 1;
            contrastTrackBar.Scroll += contrastTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 70);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 5;
            label1.Text = "Contrast";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(493, 70);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 6;
            label2.Text = "Brightness";
            // 
            // rotateTrackBar
            // 
            rotateTrackBar.Location = new Point(701, 31);
            rotateTrackBar.Maximum = 360;
            rotateTrackBar.Minimum = -360;
            rotateTrackBar.Name = "rotateTrackBar";
            rotateTrackBar.Size = new Size(302, 56);
            rotateTrackBar.TabIndex = 7;
            rotateTrackBar.Scroll += trackBar1_Scroll_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(827, 67);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 8;
            label3.Text = "Rotate";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(893, 169);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(422, 393);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // loadImageBtn
            // 
            loadImageBtn.Location = new Point(154, 586);
            loadImageBtn.Name = "loadImageBtn";
            loadImageBtn.Size = new Size(125, 42);
            loadImageBtn.TabIndex = 10;
            loadImageBtn.Text = "Load image";
            loadImageBtn.UseVisualStyleBackColor = true;
            loadImageBtn.Click += button1_Click;
            // 
            // loadBackgroundBtn
            // 
            loadBackgroundBtn.Location = new Point(515, 586);
            loadBackgroundBtn.Name = "loadBackgroundBtn";
            loadBackgroundBtn.Size = new Size(136, 43);
            loadBackgroundBtn.TabIndex = 11;
            loadBackgroundBtn.Text = "Load background";
            loadBackgroundBtn.UseVisualStyleBackColor = true;
            loadBackgroundBtn.Click += button2_Click;
            // 
            // subtractBtn
            // 
            subtractBtn.Location = new Point(987, 586);
            subtractBtn.Name = "subtractBtn";
            subtractBtn.Size = new Size(113, 36);
            subtractBtn.TabIndex = 12;
            subtractBtn.Text = "Subtract";
            subtractBtn.UseVisualStyleBackColor = true;
            subtractBtn.Click += button3_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            // 
            // button1
            // 
            button1.Location = new Point(1125, 586);
            button1.Name = "button1";
            button1.Size = new Size(133, 36);
            button1.TabIndex = 13;
            button1.Text = "Save New Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 133);
            label4.Name = "label4";
            label4.Size = new Size(360, 20);
            label4.TabIndex = 14;
            label4.Text = "Loaded Reference / Green screen image(Subtraction)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(493, 133);
            label5.Name = "label5";
            label5.Size = new Size(348, 20);
            label5.TabIndex = 15;
            label5.Text = "Processed Result / Background Image (Subtraction)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1045, 133);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 16;
            label6.Text = "Subtraction Result";
            // 
            // savePicture2Btn
            // 
            savePicture2Btn.Location = new Point(675, 586);
            savePicture2Btn.Name = "savePicture2Btn";
            savePicture2Btn.Size = new Size(151, 42);
            savePicture2Btn.TabIndex = 17;
            savePicture2Btn.Text = "Save New Image";
            savePicture2Btn.UseVisualStyleBackColor = true;
            savePicture2Btn.Click += savePicture2Btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 637);
            Controls.Add(savePicture2Btn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(subtractBtn);
            Controls.Add(loadBackgroundBtn);
            Controls.Add(loadImageBtn);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(rotateTrackBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(contrastTrackBar);
            Controls.Add(brightnessTrackBar);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)contrastTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotateTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem greyscalingToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private TrackBar brightnessTrackBar;
        private TrackBar contrastTrackBar;
        private Label label1;
        private Label label2;
        private TrackBar rotateTrackBar;
        private Label label3;
        private ToolStripMenuItem scaleToolStripMenuItem;
        private ToolStripMenuItem binaryToolStripMenuItem;
        private ToolStripMenuItem onToolStripMenuItem;
        private ToolStripMenuItem offToolStripMenuItem;
        private ToolStripMenuItem vIDEOToolStripMenuItem;
        private ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem inversionToolStripMenuItem1;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private PictureBox pictureBox3;
        private Button loadImageBtn;
        private Button loadBackgroundBtn;
        private Button subtractBtn;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private Button button1;
        private SaveFileDialog saveFileDialog2;
        private ToolStripMenuItem mirrorHorizontalToolStripMenuItem1;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem1;
        private ToolStripMenuItem histogramToolStripMenuItem1;
        private ToolStripMenuItem scaleToolStripMenuItem1;
        private ToolStripMenuItem binaryToolStripMenuItem1;
        private ToolStripMenuItem sepiaToolStripMenuItem1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button savePicture2Btn;
        private SaveFileDialog saveFileDialog3;
    }
}
