using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCvTest
{
    public partial class MainForm : Form
    {

        private Capture cap;
        private HaarCascade haar;

        private Emgu.CV.Image<Bgr, byte> diabloMap;
        private Emgu.CV.Image<Bgr, byte>[] diabloModels;
        private List<Rectangle> diabloDetectedRectangles;
        private List<Image<Gray, byte>> diabloDetectedImages;
        private StopSignDetector diabloDetector;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //The name of the window
            String win1 = "Test Window";

            //Create the window using the specific name
            CvInvoke.cvNamedWindow(win1);

            //Create an image of 400x200 of Blue color
            using (Image<Bgr, Byte> img = new Image<Bgr, byte>(400, 200, new Bgr(255, 0, 0)))
            {
                //Create the font
                MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                //Draw "Hello, world." on the image using the specific font
                img.Draw("Hello, world", ref f, new Point(10, 80), new Bgr(0, 255, 0));

                //Show the image
                CvInvoke.cvShowImage(win1, img.Ptr);
                //Wait for the key pressing event
                CvInvoke.cvWaitKey(0);
                //Destory the window
                CvInvoke.cvDestroyWindow(win1);
            }
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer(); //create an image viewer
            Capture capture = new Capture(); //create a camera captue
            Application.Idle += new EventHandler(delegate(object senderSub, EventArgs eSub)
            {  //run this until application closed (close button click on image viewer)
                viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
            });
            viewer.ShowDialog(); //show the image viewer
        }

        private void tmrFaceDetection_Tick(object sender, EventArgs e)
        {
            using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
            {
                if (nextFrame != null)
                {
                    // there's only one channel (greyscale), hence the zero index
                    //var faces = nextFrame.DetectHaarCascade(haar)[0];
                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                    var faces =
                            grayframe.DetectHaarCascade(
                                    haar, 1.4, 4,
                                    HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                    new Size(nextFrame.Width / 8, nextFrame.Height / 8)
                                    )[0];

                    foreach (var face in faces)
                    {
                        nextFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
                    }
                    pictureBox1.Image = nextFrame.ToBitmap();
                }
            }
        }

        private void cbFaceDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (cap == null)
            {
                // passing 0 gets zeroth webcam
                cap = new Capture(0);
                // adjust path to find your xml
                haar = new HaarCascade("..\\..\\lib\\haarcascade_frontalface_alt2.xml");
            }
            tmrFaceDetection.Enabled = cbFaceDetection.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Emgu.CV.Image<Bgr, byte> map = new Image<Bgr, byte>(new Bitmap(picbMap.Image));
            Emgu.CV.Image<Bgr, byte> model = new Image<Bgr, byte>(new Bitmap(picbMask.Image));
            List<Rectangle> detectedRectangles = new List<Rectangle>();
            List<Image<Gray, byte>> detectedImages = new List<Image<Gray, byte>>();

            StopSignDetector detector = new StopSignDetector(model);
            
            detector.DetectStopSign(
                map,
                detectedImages,
                detectedRectangles
            );

            picbMapMask.Image = StopSignDetector.GetRedPixelMask(map).ToBitmap();
            picbModelMask.Image = StopSignDetector.GetRedPixelMask(model).ToBitmap();

            using (Graphics gr = Graphics.FromImage(picbMap.Image))
            {
                Pen borderPen = new Pen(Color.Red, 1);

                for (var i = 0; i < detectedRectangles.Count; i++)
                {
                    gr.DrawImage(
                        detectedImages[i].ToBitmap(),
                        detectedRectangles[i].Location
                    );
                    gr.DrawRectangle(borderPen, detectedRectangles[i]);
                }
            }

            picbMap.Invalidate();
        }

        private void btnDiabloInit_Click(object sender, EventArgs e)
        {
            diabloModels = new Image<Bgr, byte>[3];
            diabloModels[0] = new Image<Bgr, byte>(new Bitmap(picbModel1.Image));
            diabloModels[1] = new Image<Bgr, byte>(new Bitmap(picbModel2.Image));
            diabloModels[2] = new Image<Bgr, byte>(new Bitmap(picbModel3.Image));
        }

        private void tabpDiabloDetection_Click(object sender, EventArgs e)
        {
            diabloMap = new Image<Bgr, byte>(new Bitmap(picbDiabloMap.Image));
            List<Rectangle> diabloDetectedRectangles = new List<Rectangle>();
            List<Image<Gray, byte>> diabloDetectedImages = new List<Image<Gray, byte>>();
        }

        private void btnMapMaskMake_Click(object sender, EventArgs e)
        {
            StopSignDetector.MaskHueLow = (int)numericUpDown1.Value;
            StopSignDetector.MaskHueHigh = (int)numericUpDown2.Value;

            Emgu.CV.Image<Bgr, byte> map = new Image<Bgr, byte>(new Bitmap(picbDiabloMap.Image));

            picbDiabloMapMask.Image = StopSignDetector.GetRedPixelMask(map).ToBitmap();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picbDiabloMap.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnDiabloDetect_Click(object sender, EventArgs e)
        {
            StopSignDetector.MaskHueLow = (int)numericUpDown1.Value;
            StopSignDetector.MaskHueHigh = (int)numericUpDown2.Value;

            diabloMap = new Image<Bgr, byte>(new Bitmap(picbDiabloMap.Image));

            diabloModels = new Image<Bgr, byte>[3];
            diabloModels[0] = new Image<Bgr, byte>(new Bitmap(picbModel1.Image));
            diabloModels[1] = new Image<Bgr, byte>(new Bitmap(picbModel2.Image));
            diabloModels[2] = new Image<Bgr, byte>(new Bitmap(picbModel3.Image));

            List<Rectangle> detectedRectangles = new List<Rectangle>();
            List<Image<Gray, byte>> detectedImages = new List<Image<Gray, byte>>();


            for (var i = 0; i < diabloModels.Length; i++)
            {
                StopSignDetector detector = new StopSignDetector(diabloModels[2 - i]);

                detector.DetectStopSign(
                    diabloMap,
                    detectedImages,
                    detectedRectangles
                );

                picbDiabloMapMask.Image = StopSignDetector.GetRedPixelMask(diabloMap).ToBitmap();
            }

            using (Graphics gr = Graphics.FromImage(picbDiabloResult.Image))
            {
                Pen borderPen = new Pen(Color.Red, 1);

                for (var i = 0; i < detectedRectangles.Count; i++)
                {
                    gr.DrawImage(
                        detectedImages[i].ToBitmap(),
                        detectedRectangles[i].Location
                    );
                    gr.DrawRectangle(borderPen, detectedRectangles[i]);
                }
            }
            

            picbDiabloResult.Invalidate();
        }

        private void btnDiabloInit_Click_1(object sender, EventArgs e)
        {
            StopSignDetector.MaskHueLow = (int)numericUpDown1.Value;
            StopSignDetector.MaskHueHigh = (int)numericUpDown2.Value;

            diabloModels = new Image<Bgr, byte>[3];
            diabloModels[0] = new Image<Bgr, byte>(new Bitmap(picbModel1.Image));
            diabloModels[1] = new Image<Bgr, byte>(new Bitmap(picbModel2.Image));
            diabloModels[2] = new Image<Bgr, byte>(new Bitmap(picbModel3.Image));

            picbModelMask1.Image = StopSignDetector.GetRedPixelMask(diabloModels[0]).ToBitmap();
            picbModelMask2.Image = StopSignDetector.GetRedPixelMask(diabloModels[1]).ToBitmap();
            picbModelMask3.Image = StopSignDetector.GetRedPixelMask(diabloModels[2]).ToBitmap();
        }
    }
}
