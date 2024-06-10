using OpenCvSharp;

namespace EmguCV_C_
{
    internal class Window : BasicOperations
    {
        Mat WnP = new Mat();
        int size = 0;

        public Window(Mat showingImage)
        {
            ShowingImage = showingImage;
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public Mat WindowProcessing
        {
            get { return WnP; }
        }

        //Hàm tạo cửa sổ
        public Bitmap CreateWindow(int x, int y, int Size = -1)
        {
            if (Size == -1)
                Size = size;
            if (x< Size || y < Size || x > ShowingImage.Width - Size || y > ShowingImage.Height - Size)
                return MatToBitmap(WnP);
            WnP = new Mat(ShowingImage, new Rect(x - size / 2, y - size / 2, 2 * size + 1, 2 * size + 1));
            return MatToBitmap(WnP);
        }

        //Tính mức xám trung bình
        public int Mean()
        {
            int mean = 0;
            for (int i = 0; i < WnP.Rows; i++)
            {
                for (int j = 0; j < WnP.Cols; j++)
                {
                    mean += WnP.At<byte>(i, j);
                }
            }
            mean = mean / (WnP.Rows * WnP.Cols);
            return mean;
        }

        //Tính độ lệch chuẩn
        public int StandardDeviation()
        {
            int mean = Mean();
            int deviation = 0;
            for (int i = 0; i < WnP.Rows; i++)
            {
                for (int j = 0; j < WnP.Cols; j++)
                {
                    deviation += (WnP.At<byte>(i, j) - mean) * (WnP.At<byte>(i, j) - mean);
                }
            }
            deviation = deviation / (WnP.Rows * WnP.Cols);
            return deviation;
        }
    }
}
