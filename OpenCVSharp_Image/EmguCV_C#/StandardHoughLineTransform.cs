namespace EmguCV_C_
{
    public partial class StandardHoughLineTransform : UserControl
    {
        BasicOperations basicOperations;
        public StandardHoughLineTransform(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            basicOperations.HoughTransform(trackBar1.Value);
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

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowHoughTransform(trackBar1.Value);
        }
    }
}
