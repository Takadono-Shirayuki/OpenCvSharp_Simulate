namespace EmguCV_C_
{
    public partial class CornerDetectHarris : UserControl
    {
        BasicOperations basicOperations;
        public CornerDetectHarris(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            basicOperations.DetectCornerHarris(trackBar1.Value, 1 + 2 * trackBar2.Value, (float)trackBar3.Value / 100, trackBar4.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (1 + 2 * trackBar2.Value).ToString();
            basicOperations.DetectCornerHarris(trackBar1.Value, 1 + 2 * trackBar2.Value, (float)trackBar3.Value / 100, trackBar4.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = ((float)trackBar3.Value / 100).ToString();
            basicOperations.DetectCornerHarris(trackBar1.Value, 1 + 2 * trackBar2.Value, (float)trackBar3.Value / 100, trackBar4.Value);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = trackBar4.Value.ToString();
            basicOperations.DetectCornerHarris(trackBar1.Value, 1 + 2 * trackBar2.Value, (float)trackBar3.Value / 100, trackBar4.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value < 1)
                    value = 1;
                if (value > 20)
                    value = 20;
                trackBar1.Value = value;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value < 1)
                    value = 1;
                if (value > 25)
                    value = 25;
                trackBar2.Value = (value - 1) / 2;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox3.Text, out float value))
            {
                if (value < 0)
                    value = 0;
                else if (value > 1)
                    value = 1;
                trackBar3.Value = (int)(value * 100);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                else if (value > 255)
                    value = 255;
                trackBar4.Value = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowCornerHarris(trackBar1.Value, 1 + 2 * trackBar2.Value, (float)trackBar3.Value / 100, trackBar4.Value);
        }
    }
}
