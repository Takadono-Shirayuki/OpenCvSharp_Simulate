using OpenCvSharp;

namespace EmguCV_C_
{
    public partial class RotateImageUseHoughLine : UserControl
    {
        Mat TempImage;
        PictureBox UsingPictureBox;
        public RotateImageUseHoughLine(Mat Tempimage, PictureBox usingPictureBox)
        {
            InitializeComponent();
            TempImage = Tempimage;
            UsingPictureBox = usingPictureBox;
        }

        LineSegmentPolar[]? lines;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            Mat ShowingImage = TempImage.Clone();
            Mat gray = TempImage.Canny(50, 200);
            lines = Cv2.HoughLines(gray, 1, Math.PI / 180, trackBar1.Value);
            foreach (LineSegmentPolar line in lines)
            {
                float rho = line.Rho;
                float theta = line.Theta;
                double a = Math.Cos(theta);
                double b = Math.Sin(theta);
                double x0 = a * rho;
                double y0 = b * rho;
                OpenCvSharp.Point pt1 = new OpenCvSharp.Point(x0 + 1000 * (-b), y0 + 1000 * a);
                OpenCvSharp.Point pt2 = new OpenCvSharp.Point(x0 - 1000 * (-b), y0 - 1000 * a);
                Cv2.Line(ShowingImage, pt1, pt2, Scalar.Red, 2);
            }
            UsingPictureBox.Image = BasicOperations.MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 1000) 
                    value = 1000;
                if (value < 0)
                    value = 0;
                trackBar1.Value = value;
            }
        }

        int[] PixelLocation = new int[2];
        public void MME(int[] pixelLocation)
        {
            PixelLocation = pixelLocation;
        }
        public void MCE()
        {
            double mindiff = 1000000;
            double Theta = 0;
            foreach (LineSegmentPolar line in lines)
            {
                float rho = line.Rho;
                float theta = line.Theta;
                double a = Math.Sin(theta);
                double b = Math.Cos(theta);
                double x0 = a * rho;
                double y0 = b * rho;
                double Diff = Math.Abs((PixelLocation[0] - y0) * b + (PixelLocation[1] - x0) * a);
                if (Diff < mindiff)
                {
                    mindiff = Diff;
                    Theta = theta;
                }
            }
            double Angle = Theta * 180 / Math.PI;
            if (comboBox1.SelectedIndex == 0)
                Angle -= 90;
            textBox2.Text = Math.Round(Angle, 2).ToString();
            Mat MatRotation = Cv2.GetRotationMatrix2D(new Point2f(TempImage.Width / 2, TempImage.Height / 2), Angle, 1);
            Mat RotatedImage = new Mat();
            Cv2.WarpAffine(TempImage, RotatedImage, MatRotation, TempImage.Size());
            Cv2.ImShow("Rotated Image", RotatedImage);
            if (Cv2.WaitKey(0) == 27)
            {
                Cv2.DestroyAllWindows();
            }
            if (MessageBox.Show("Bạn có muốn lưu ảnh này không?", "Save Image", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    RotatedImage.SaveImage(saveFileDialog.FileName);
                }
            }
            MatRotation.Dispose();
            RotatedImage.Dispose();
        }
    }
}
