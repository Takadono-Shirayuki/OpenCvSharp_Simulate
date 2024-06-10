namespace EmguCV_C_
{
    public partial class EdgeDetectionLoG : UserControl
    {
        BasicOperations BasicOperations;
        public EdgeDetectionLoG(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (1 + 2 * trackBar1.Value).ToString();
            BasicOperations.DetectEdgeLoG(1 + 2 * trackBar1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 25)
                    value = 25;
                else if (value < 3)
                    value = 3;
                trackBar1.Value = (value - 1) / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicOperations.ShowDetectEdgeLoG(1 + 2 * trackBar1.Value);
        }
    }
}
