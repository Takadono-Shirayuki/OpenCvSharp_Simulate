namespace EmguCV_C_
{
    public partial class EdgeDetectionDoG : UserControl
    {
        BasicOperations BasicOperations;
        public EdgeDetectionDoG(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (1 + 2 * trackBar1.Value).ToString();
            BasicOperations.DetectEdgeDoG(1 + 2 * trackBar1.Value, (1 + 2 * (int)(trackBar1.Value * float.Parse(textBox1.Text))));
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = Math.Round(1.0 + (float)trackBar2.Value / 100, 2).ToString();
            BasicOperations.DetectEdgeDoG(1 + 2 * trackBar1.Value, (1 + 2 * (int)(trackBar1.Value * float.Parse(textBox1.Text))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicOperations.ShowDetectEdgeDoG(1 + 2 * trackBar1.Value, (1 + 2 * (int)(trackBar1.Value * float.Parse(textBox1.Text))));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 25)
                    value = 25;
                if (value < 1)
                    value = 1;
                trackBar1.Value = (value - 1) / 2;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out float value))
            {
                if (value > 2)
                    value = 2;
                else if (value < 1)
                    value = 1;
                trackBar2.Value = (int)((value - 1) * 100);
            }
        }
    }
}
