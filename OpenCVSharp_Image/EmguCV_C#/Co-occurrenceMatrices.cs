using OpenCvSharp;

namespace EmguCV_C_
{
    public partial class Co_occurrenceMatrices : Form
    {
        int[,] CooccurrenceMatrices = new int[256, 256];

        public Co_occurrenceMatrices(BasicOperations BasicOperations)
        {
            InitializeComponent();
            Mat CooccurrenceMatricesMat = new Mat(new OpenCvSharp.Size(256, 256), MatType.CV_8UC1);
            Mat Gray = new Mat();
            Cv2.CvtColor(BasicOperations.GetShowingImage(), Gray, ColorConversionCodes.BGR2GRAY);

            //Tính ma trận đồng xuất hiện
            for (int i = 0; i < Gray.Cols; i++)
            {
                for (int j = 0; j < Gray.Rows; j++)
                {
                    if (i > 0)
                        CooccurrenceMatrices[Gray.At<byte>(j, i), Gray.At<byte>(j, i - 1)]++;
                    if (j > 0)
                        CooccurrenceMatrices[Gray.At<byte>(j, i), Gray.At<byte>(j - 1, i)]++;
                    if (i + 1 < Gray.Cols)
                        CooccurrenceMatrices[Gray.At<byte>(j, i), Gray.At<byte>(j, i + 1)]++;
                    if (j + 1 < Gray.Rows)
                        CooccurrenceMatrices[Gray.At<byte>(j, i), Gray.At<byte>(j + 1, i)]++;
                }
            }

            //Tính tổng các giá trị và giá trị lớn nhất
            int sum = 0;
            int max = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    sum += CooccurrenceMatrices[i, j];
                    if (max < CooccurrenceMatrices[i, j])
                        max = CooccurrenceMatrices[i, j];
                }
            }

            //Chuẩn hóa ma trận đồng xuất hiện
            int Ratio = max / 256;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    CooccurrenceMatricesMat.Set<byte>(j, i, (byte)(CooccurrenceMatrices[i, j] / Ratio));
                }
            }

            //Tính độ đồng nhất và đồng đều
            double homogeneity = 0;
            double uniformity = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    homogeneity += (double)CooccurrenceMatrices[i, j] / (1 + Math.Abs(i - j));
                    uniformity += (double)CooccurrenceMatrices[i, j] * CooccurrenceMatrices[i, j];
                }
            }
            Cv2.CvtColor(CooccurrenceMatricesMat, CooccurrenceMatricesMat, ColorConversionCodes.GRAY2BGR);  
            pictureBox1.Image = BasicOperations.MatToBitmap(CooccurrenceMatricesMat);
            Sum.Text = "Tổng các giá trị: " + sum.ToString();
            HomogeneityMeaSure.Text = homogeneity.ToString();
            UniformityMeasure.Text = uniformity.ToString();
        }

        Boolean AllowMME = true;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowMME)
            {
                double scale = Math.Max(256.0 / pictureBox1.Width, 256.0 / pictureBox1.Height);
                int x = 128 - (int)((pictureBox1.Width / 2 - e.X) * scale);
                int y = 128 - (int)((pictureBox1.Height / 2 - e.Y) * scale);
                if (x < 0) 
                    x = 0;
                if (x > 255)
                    x = 255;
                if (y < 0)
                    y = 0;
                if (y > 255)
                    y = 255;
                X.Text = "X: " + x.ToString();
                Y.Text = "Y: " + y.ToString();
                Value.Text = "Giá trị: " + CooccurrenceMatrices[y, x].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AllowMME = !AllowMME;
        }
    }
}
