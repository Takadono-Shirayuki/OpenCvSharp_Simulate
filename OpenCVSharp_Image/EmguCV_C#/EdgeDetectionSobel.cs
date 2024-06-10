namespace EmguCV_C_
{
    public partial class EdgeDetectionSobel : UserControl
    {
        BasicOperations BasicOperations;
        public EdgeDetectionSobel(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (1 + trackBar1.Value * 2).ToString();
            BasicOperations.DetectEdgeSobel(1 + trackBar1.Value * 2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            BasicOperations.ShowDetectEdgeSobel(1 + 2 * trackBar1.Value);
        }
    }
}
