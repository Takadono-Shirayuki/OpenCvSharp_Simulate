using OpenCvSharp;

namespace EmguCV_C_
{
    public partial class Histogram : Form
    {
        public Histogram(int[][] Histogram)
        {
            InitializeComponent();
            for (int i =0; i<256; i++)
            {
                chart1.Series[0].Points.AddXY(i, Histogram[0][i]);
                chart2.Series[0].Points.AddXY(i, Histogram[1][i]);
                chart3.Series[0].Points.AddXY(i, Histogram[2][i]);
            }
        }

        private void Histogram_Load(object sender, EventArgs e)
        {

        }
    }
}
