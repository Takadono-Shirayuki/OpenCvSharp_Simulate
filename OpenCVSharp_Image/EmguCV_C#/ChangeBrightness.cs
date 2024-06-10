namespace EmguCV_C_
{
    public partial class ChangeBrightness : UserControl
    {
        BasicOperations BasicOperations;
        public ChangeBrightness(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 255)
                    trackBar1.Value = 255;
                else if (value < -255)
                    trackBar1.Value = -255;
                else
                    trackBar1.Value = value;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            BasicOperations.ChangeBrightness(trackBar1.Value);
        }
    }
}
