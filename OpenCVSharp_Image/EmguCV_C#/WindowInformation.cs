using OpenCvSharp;

namespace EmguCV_C_
{
    public partial class WindowInformation : UserControl
    {
        Window Window;
        public WindowInformation(Mat ShowingImage)
        {
            InitializeComponent();
            Window = new Window(ShowingImage);
        }

        public void MME(int[] PixelLocation)
        {
            textBox1.Text = PixelLocation[0].ToString();
            textBox2.Text = PixelLocation[1].ToString();
            pictureBox1.Image = Window.CreateWindow(PixelLocation[0], PixelLocation[1]);
            textBox3.Text = Window.Mean().ToString();
            textBox4.Text = Window.StandardDeviation().ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Window.Size = (int)numericUpDown1.Value;
            pictureBox1.Image = Window.CreateWindow(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            textBox3.Text = Window.Mean().ToString();
            textBox4.Text = Window.StandardDeviation().ToString();
        }
    }
}
