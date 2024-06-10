namespace EmguCV_C_
{
    public partial class RotateImage : UserControl
    {
        BasicOperations BasicOperations;
        public RotateImage(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            BasicOperations.RotateImage(trackBar1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
                trackBar1.Value = value % 360;
        }
    }
}
