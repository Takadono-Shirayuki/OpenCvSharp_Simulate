using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguCV_C_
{
    public partial class ColorDetection : UserControl
    {
        BasicOperations BasicOperations;
        public ColorDetection(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            if (trackBar1.Value > trackBar2.Value)
                trackBar2.Value = trackBar1.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            if (trackBar2.Value < trackBar1.Value)
                trackBar1.Value = trackBar2.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = trackBar4.Value.ToString();
            if (trackBar4.Value > trackBar3.Value)
                trackBar3.Value = trackBar4.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            if (trackBar3.Value < trackBar4.Value)
                trackBar4.Value = trackBar3.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = trackBar6.Value.ToString();
            if (trackBar6.Value > trackBar5.Value)
                trackBar5.Value = trackBar6.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = trackBar5.Value.ToString();
            if (trackBar5.Value < trackBar6.Value)
                trackBar6.Value = trackBar5.Value;
            BasicOperations.DetectColor(trackBar1.Value, trackBar2.Value, trackBar4.Value, trackBar3.Value, trackBar6.Value, trackBar5.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 179)
                    value = 179;
                trackBar1.Value = value;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 179)
                    value = 179;
                trackBar2.Value = value;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 255)
                    value = 255;
                trackBar4.Value = value;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 255)
                    value = 255;
                trackBar3.Value = value;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 255)
                    value = 255;
                trackBar6.Value = value;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int value))
            {
                if (value < 0)
                    value = 0;
                if (value > 255)
                    value = 255;
                trackBar5.Value = value;
            }
        }
    }
}
