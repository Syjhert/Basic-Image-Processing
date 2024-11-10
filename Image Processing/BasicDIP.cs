using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public class ConvMatrix
    {

        public int TopLeft = 0, TopMid = 0, TopRight = 0;

        public int MidLeft = 0, Pixel = 1, MidRight = 0;

        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;

        public int Factor = 1;

        public int Offset = 0;

        public void SetAll(int nVal)

        {

            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =

                      BottomLeft = BottomMid = BottomRight = nVal;

        }

    }
    static class BasicDIP
    {
        public static void PixelCopy(Bitmap reference, ref Bitmap result)
        {
            result = new Bitmap(reference.Width, reference.Height);

            Color pixel;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    result.SetPixel(x, y, pixel);
                }
            }
        }
        public static void Grayscaling(Bitmap reference, ref Bitmap result)
        {
            //compressed color to 1 byte cuz we use the grey for the RGB
            result = new Bitmap(reference.Width, reference.Height);

            Color pixel;
            int average;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    average = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    Color grey = Color.FromArgb(average, average, average);
                    result.SetPixel(x, y, grey);
                }
            }
        }
        public static void Inversion(Bitmap reference, ref Bitmap result)
        {
            //inverting an inverted image will get the original image
            //used to see the darker sides of an image
            result = new Bitmap(reference.Width, reference.Height);

            Color pixel;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    Color inverted = Color.FromArgb(
                        255 - pixel.R, 255 - pixel.G, 255 - pixel.B
                    );
                    result.SetPixel(x, y, inverted);
                }
            }
        }
        public static void MirrorHorizontal(Bitmap reference, ref Bitmap result)
        {
            result = new Bitmap(reference.Width, reference.Height);

            Color pixel;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    result.SetPixel(reference.Width - x - 1, y, pixel);
                }
            }
        }

        public static void MirrorVertical(Bitmap reference, ref Bitmap result)
        {
            result = new Bitmap(reference.Width, reference.Height);

            Color pixel;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    result.SetPixel(x, reference.Height - y - 1, pixel);
                }
            }
        }
        public static void Hist(Bitmap reference, ref Bitmap result)
        {
            Color sample;
            Color gray;
            Byte graydata;
            int[] histtdata = new int[256];
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    sample = reference.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    histtdata[graydata]++;
                }
            }

            result = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    result.SetPixel(x, y, Color.White);
                }
            }
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histtdata[x] / 5, result.Height - 1); y++)
                {
                    result.SetPixel(x, (result.Height - 1) - y, Color.Black);
                }
            }
        }

        public static void Brightness(Bitmap a, ref Bitmap b, int value)
        {
            b = new Bitmap(a.Width, a.Height);
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    Color temp = a.GetPixel(x, y);
                    Color changed;
                    if (value > 0)
                        changed = Color.FromArgb(Math.Min(temp.R + value, 255), Math.Min(temp.G + value, 255), Math.Min(temp.B + value, 255));
                    else
                        changed = Color.FromArgb(Math.Max(temp.R + value, 0), Math.Max(temp.G + value, 0), Math.Max(temp.B + value, 0));
                    b.SetPixel(x, y, changed);
                }
            }
        }

        public static void Equalisation(Bitmap a, ref Bitmap b, int degree)
        {
            int height = a.Height;
            int width = a.Width;
            int numSamples, histSum;
            int[] Ymap = new int[256];
            int[] hist = new int[256];
            int percent = degree;

            Color calculated;
            Color gray;
            Byte graydata;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    calculated = a.GetPixel(x, y);
                    graydata = (byte)((calculated.R + calculated.G + calculated.B) / 3);
                    hist[graydata]++;
                }
            }
            numSamples = (width * height);
            histSum = 0;
            for (int h = 0; h < 256; h++)
            {
                histSum += hist[h];
                Ymap[h] = histSum * 255 / numSamples;
            }

            if (percent < 100)
            {
                 for (int h = 0; h < 256; h++)
                {
                    Ymap[h] = h + ((int)Ymap[h] - h) * percent / 100;
                }
            }

            b = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color temp = Color.FromArgb(Ymap[a.GetPixel(x, y).R], Ymap[a.GetPixel(x, y).G], Ymap[a.GetPixel(x, y).B]);
                    b.SetPixel(x, y, temp);
                }
            }
        }

        public static void Rotate(Bitmap a, ref Bitmap b, int value) //value -360 - 360
        {
            float angleRadians = (float)(value*Math.PI/180);
            int xCenter = a.Width / 2;
            int yCenter = a.Height / 2;
            int height = a.Height;
            int width = a.Width;
            float cosA = (float)Math.Cos(angleRadians);
            float sinA = (float)Math.Sin(angleRadians);
            int xs, ys, xp, yp, x0, y0;
            b = new Bitmap(width, height);

            for (xp = 0; xp < width; xp++)
            {
                for (yp = 0; yp < height; yp++)
                {
                    x0 = xp - xCenter;      // translate to (0, 0)
                    y0 = yp - yCenter;
                    xs = (int)(x0 * cosA + y0 * sinA);  // rotate around the origin
                    ys = (int)(-x0 * sinA + y0 * cosA);
                    xs = (int)(xs + xCenter);      // translate back to (xCenter, yCenter)
                    ys = (int)(ys + yCenter);
                    xs = Math.Max(0, Math.Min(width - 1, xs));  // force the source...
                    ys = Math.Max(0, Math.Min(height - 1 , ys));
                    b.SetPixel(xp, yp, a.GetPixel(xs, ys));
                }
            }
        }

        public static void Scale(Bitmap a, ref Bitmap b, int targetWidth,  int targetHeight)
        {
            int xTarget, yTarget, xSource, ySource;
            int width = a.Width;
            int height = a.Height;
            b = new Bitmap(targetWidth, targetHeight);

            for ( xTarget = 0; xTarget < targetWidth; xTarget++)
            {
                for ( yTarget = 0;  yTarget < targetHeight; yTarget++)
                {
                    xSource = xTarget * width / targetWidth;
                    ySource = yTarget * height / targetHeight;
                    b.SetPixel(xTarget, yTarget, a.GetPixel(xSource, ySource));
                }
            }
        }

        public static void Binary(Bitmap reference, ref Bitmap result)
        {
            result = new Bitmap(reference.Width, reference.Height);
            Color pixel;
            int ave;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    ave = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    if (ave < 180)
                    {
                        result.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.White);
                    }
                }
            }
        }

        public static void Sepia(Bitmap reference, ref Bitmap result)
        {
            result = new Bitmap(reference.Width, reference.Height);
            Color pixel;
            int tr, tg, tb;
            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    pixel = reference.GetPixel(x, y);
                    tr = (int)((pixel.R * .393) + (pixel.G * .769) + (pixel.B * .189));
                    tg = (int)((pixel.R * .349) + (pixel.G * .686) + (pixel.B * .168));
                    tb = (int)((pixel.R * .272) + (pixel.G * .534) + (pixel.B * .131));
                    Color color = Color.FromArgb(Math.Min(tr, 255), Math.Min(tg, 255), Math.Min(tb, 255));
                    result.SetPixel(x, y, color);
                }
            }
        }

        public static void Subtract(Bitmap image, Bitmap background, ref Bitmap result)
        {
            //change greenscreen color
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
        }

        public static Bitmap Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors 

            if (0 == m.Factor || b == null)
                return null;


            //Uncomment below to check for matrix
            //Debug.WriteLine("Matrix: " + "\n" +
            //        m.TopLeft + "\t" + m.TopMid + "\t" + m.TopRight + "\n" +
            //        m.MidLeft + "\t" + m.Pixel + "\t" + m.MidRight + "\n" +
            //        m.BottomLeft + "\t" + m.BottomMid + "\t" + m.BottomRight + "\n" +
            //        "/" + m.Factor + " + " + m.Offset);


            // GDI+ still lies to us - the return format is BGR, NOT RGB.  

            Bitmap bSrc = (Bitmap)b.Clone();
            Bitmap result = new Bitmap(bSrc.Width, bSrc.Height);
            
            //edited bitmap
            BitmapData bmData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                               ImageLockMode.ReadWrite,
                               PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            int stride2 = stride * 2;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) +
                            (pSrc[5] * m.TopMid) +
                            (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) +
                            (pSrc[5 + stride] * m.Pixel) +
                            (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) +
                            (pSrc[5 + stride2] * m.BottomMid) +
                            (pSrc[8 + stride2] * m.BottomRight))
                            / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) +
                            (pSrc[4] * m.TopMid) +
                            (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) +
                            (pSrc[4 + stride] * m.Pixel) +
                            (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) +
                            (pSrc[4 + stride2] * m.BottomMid) +
                            (pSrc[7 + stride2] * m.BottomRight))
                            / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) +
                                       (pSrc[3] * m.TopMid) +
                                       (pSrc[6] * m.TopRight) +
                                       (pSrc[0 + stride] * m.MidLeft) +
                                       (pSrc[3 + stride] * m.Pixel) +
                                       (pSrc[6 + stride] * m.MidRight) +
                                       (pSrc[0 + stride2] * m.BottomLeft) +
                                       (pSrc[3 + stride2] * m.BottomMid) +
                                       (pSrc[6 + stride2] * m.BottomRight))
                            / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }
            result.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return result;

        }

        public static void Smoothing(Bitmap reference, ref Bitmap result, int nWeight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;
            result = Conv3x3(reference, m);
        }
        public static void GaussianBlur(Bitmap reference, ref Bitmap result, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Pixel = nWeight;
            m.Factor = nWeight + 12;
            result = Conv3x3(reference, m);
        }
        public static void Sharpen(Bitmap reference, ref Bitmap result, int nWeight = 11)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;
            result = Conv3x3(reference, m);
        }

        public static void MeanRemoval(Bitmap reference, ref Bitmap result, int nWeight = 9)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;
            result = Conv3x3(reference, m);
        }

        public static void EmbossLaplascian(Bitmap reference, ref Bitmap result, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
            m.Pixel = nWeight;
            m.Factor = nWeight - 3;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }

        public static void EmbossHoriVerti(Bitmap reference, ref Bitmap result, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -1;
            m.Pixel = nWeight;
            m.Factor = nWeight - 3;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }

        public static void EmbossAllDirections(Bitmap reference, ref Bitmap result, int nWeight = 8)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 7;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }

        public static void EmbossLossy(Bitmap reference, ref Bitmap result, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-2);
            m.TopLeft = m.TopRight = m.BottomMid = 1;
            m.Pixel = nWeight;
            m.Factor = nWeight - 3;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }

        public static void EmbossHorizontal(Bitmap reference, ref Bitmap result, int nWeight = 2)
        {
            ConvMatrix m = new ConvMatrix();
            m.MidLeft = m.MidRight = -1;
            m.Pixel = nWeight;
            m.Factor = nWeight - 1;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }

        public static void EmbossVertical(Bitmap reference, ref Bitmap result, int nWeight = 0)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopMid = -1;
            m.BottomMid = 1;
            m.Pixel = nWeight;
            m.Factor = nWeight + 1;
            m.Offset = 127;
            result = Conv3x3(reference, m);
        }
    }
}
