namespace EmguCV_C_
{
    public partial class ProbabilisticHoughLineTransform : UserControl
    {
        BasicOperations basicOperations;
        public ProbabilisticHoughLineTransform(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowHoughProbabilisticTransform(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            basicOperations.HoughProbabilisticTransform(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            basicOperations.HoughProbabilisticTransform(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            basicOperations.HoughProbabilisticTransform(trackBar1.Value, trackBar2.Value, trackBar3.Value);
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
                if (value > 100)
                    value = 100;
                if (value < 0)
                    value = 0;
                trackBar3.Value = value;
            }
        }
    }
}
