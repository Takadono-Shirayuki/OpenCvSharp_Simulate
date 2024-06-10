namespace EmguCV_C_
{
    public partial class HoughCircleTransform : UserControl
    {
        BasicOperations basicOperations;
        public HoughCircleTransform(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            basicOperations.HoughCircleTransform(trackBar3.Value, trackBar4.Value, trackBar1.Value, trackBar2.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            basicOperations.HoughCircleTransform(trackBar3.Value, trackBar4.Value, trackBar1.Value, trackBar2.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            basicOperations.HoughCircleTransform(trackBar3.Value, trackBar4.Value, trackBar1.Value, trackBar2.Value);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = trackBar4.Value.ToString();
            basicOperations.HoughCircleTransform(trackBar3.Value, trackBar4.Value, trackBar1.Value, trackBar2.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 255)
                    value = 255;
                if (value < 2)
                    value = 2;
                trackBar1.Value = value;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value > 1000)
                    value = 1000;
                if (value < 0)
                    value = 0;
                trackBar2.Value = value;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int value))
            {
                if (value > 1000)
                    value = 1000;
                if (value < 0)
                    value = 0;
                trackBar3.Value = value;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int value))
            {
                if (value > 1000)
                    value = 1000;
                if (value < 0)
                    value = 0;
                trackBar4.Value = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowHoughCircleTransform(trackBar3.Value, trackBar4.Value, trackBar1.Value, trackBar2.Value);
        }
    }
}
