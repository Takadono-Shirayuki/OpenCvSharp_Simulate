using OpenCvSharp;

namespace EmguCV_C_
{
    public partial class PixelInformation : UserControl
    {
        Mat Image;
        public PixelInformation(Mat ShowingImage)
        {
            InitializeComponent();
            Image = ShowingImage;
        }

        public void MME(int[] PixelLocation)
        {
            Vec3b pixel = Image.At<Vec3b>(PixelLocation[1], PixelLocation[0]);
            textBox1.Text = PixelLocation[0].ToString();
            textBox2.Text = PixelLocation[1].ToString();
            textBox3.Text = pixel.Item0.ToString();
            textBox4.Text = pixel.Item1.ToString();
            textBox5.Text = pixel.Item2.ToString();
            textBox6.Text = ((pixel.Item0 + pixel.Item1 + pixel.Item2) / 3).ToString();
        }
    }
}
