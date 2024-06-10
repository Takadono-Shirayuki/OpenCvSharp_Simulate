namespace EmguCV_C_
{
    public partial class ChangeContrast : UserControl
    {
        BasicOperations BasicOperations;
        Boolean IsScroll = true;
        public ChangeContrast(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBar1.Value;
            if (value >= 0)
                textBox1.Text = Math.Round((1 + value / 10.0), 2).ToString();
            else
                textBox1.Text = Math.Round((1 + value / 100.0), 2).ToString();
            BasicOperations.ChangeContrast(float.Parse(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float value))
            {
                if (value > 10)
                    value = 10;
                if (value < 0)
                    value = 0;
                if (value >= 1)
                    trackBar1.Value = (int)((value - 1) * 10);
                else
                    trackBar1.Value = (int)((value - 1) * 100);
            }
        }
    }
}
