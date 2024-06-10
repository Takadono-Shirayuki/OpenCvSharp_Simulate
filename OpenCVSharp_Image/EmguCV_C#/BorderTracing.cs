namespace EmguCV_C_
{
    public partial class BorderTracing : UserControl
    {
        BasicOperations basicOperations;
        public BorderTracing(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            if (trackBar1.Value > trackBar2.Value)
            {
                trackBar2.Value = trackBar1.Value;
            }
            basicOperations.FindContours(trackBar1.Value, trackBar2.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            if (trackBar2.Value < trackBar1.Value)
            {
                trackBar1.Value = trackBar2.Value;
            }
            basicOperations.FindContours(trackBar1.Value, trackBar2.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 255)
                    value = 255;
                if (value < 0)
                    value = 0;
                trackBar1.Value = value;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value > 255)
                    value = 255;
                if (value < 0)
                    value = 0;
                trackBar2.Value = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowContours(trackBar1.Value, trackBar2.Value);
        }
    }
}
