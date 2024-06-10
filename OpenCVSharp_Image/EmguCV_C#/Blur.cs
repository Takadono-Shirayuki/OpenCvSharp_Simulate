namespace EmguCV_C_
{
    public partial class Blur : UserControl
    {
        BasicOperations BasicOperations;
        public Blur(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (1 + 2 * trackBar1.Value).ToString();
            BasicOperations.BlurImage(1 + 2 * trackBar1.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (1 + 2 * trackBar2.Value).ToString();
            BasicOperations.GaussianBlur(1 + 2 * trackBar2.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 25)
                    trackBar1.Value = 12;
                else if (value < 3)
                    trackBar1.Value = 0;
                else
                    trackBar1.Value = (value - 1) / 2;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value > 25)
                    trackBar2.Value = 12;
                else if (value < 1)
                    trackBar2.Value = 0;
                else
                    trackBar2.Value = (value - 1) / 2;
            }
        }
    }
}
