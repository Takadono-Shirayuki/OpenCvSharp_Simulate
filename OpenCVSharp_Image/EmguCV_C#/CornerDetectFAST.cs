namespace EmguCV_C_
{
    public partial class CornerDetectFAST : UserControl
    {
        BasicOperations basicOperations;
        public CornerDetectFAST(BasicOperations basicOperations)
        {
            InitializeComponent();
            this.basicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            basicOperations.DetectCornerFAST(trackBar1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                else if (value > 255)
                    value = 255;
                trackBar1.Value = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            basicOperations.ShowCornerFAST(trackBar1.Value);
        }
    }
}
