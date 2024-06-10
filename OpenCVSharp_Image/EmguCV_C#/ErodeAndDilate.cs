namespace EmguCV_C_
{
    public partial class ErodeAndDilate : UserControl
    {
        BasicOperations BasicOperations;
        public ErodeAndDilate(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (1 + 2 * trackBar1.Value).ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (1 + 2 * trackBar2.Value).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                BasicOperations.ErodeImage(1 + 2 * trackBar1.Value, (int)numericUpDown1.Value);
            else
                BasicOperations.DilateImage(1 + 2 * trackBar2.Value, (int)numericUpDown1.Value);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value > 25)
                    value = 25;
                else if (value < 3)
                    value = 3;
                trackBar2.Value = (value - 1) / 2;
            }
        }
    }
}
