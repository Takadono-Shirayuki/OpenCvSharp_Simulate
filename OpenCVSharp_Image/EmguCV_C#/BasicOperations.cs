using OpenCvSharp;
using System.Drawing.Imaging;
using System.Numerics;

namespace EmguCV_C_
{
    public class BasicOperations
    {
        PictureBox? usingPictureBox;
        //Hàm lấy và đặt PictureBox sử dụng
        public PictureBox? UsingPictureBox
        {
            get { return usingPictureBox; }
            set { usingPictureBox = value; }
        }

        //Hàm Dispose
        public void Dispose()
        {
            SourceImage.Dispose();
            TempImage.Dispose();
            ShowingImage.Dispose();
            bitmap.Dispose();
        }

        //Biến Mat dùng cho việc xử lý ảnh
        Mat SourceImage = new Mat();
        protected Mat TempImage = new Mat();
        protected Mat ShowingImage = new Mat();
        public Mat GetShowingImage()
        {
            return ShowingImage;
        }

        //Biến Bitmap dùng cho việc chuyển đổi giữa Mat và Bitmap
        static Bitmap? bitmap;

        //Chuyển đổi từ Mat sang Bitmap
        unsafe public static Bitmap MatToBitmap(Mat mat)
        {
            try
            {
                bitmap.Dispose();
            }
            catch { }
            bitmap = new Bitmap(mat.Width, mat.Height, PixelFormat.Format24bppRgb);

            BitmapData data;
            if (mat.Type() == OpenCvSharp.MatType.CV_8UC3)
            {
                data = bitmap.LockBits(new Rectangle(0, 0, mat.Width, mat.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            }
            else
            {
                data = bitmap.LockBits(new Rectangle(0, 0, mat.Width, mat.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            }
            byte* dstdata = (byte*)data.Scan0.ToPointer();
            byte* srcData = (byte*)mat.Data;
            for (int row = 0; row < data.Height; row++)
            {
                Buffer.MemoryCopy(&srcData[row * mat.Step()], &dstdata[row * data.Stride], mat.Cols * mat.Channels(), mat.Cols * mat.Channels());
            }

            bitmap.UnlockBits(data);
            return bitmap;
        }

        //Hàm mở ảnh
        public string LoadImage(string path)
        {
            ShowingImage.Release();
            Mat mat = Cv2.ImRead(path);
            if (mat == null)
            {
                return "Mở File thất bại";
            }
            SourceImage = mat;
            TempImage = mat.Clone();
            ShowingImage = mat.Clone();
            usingPictureBox.Image = MatToBitmap(mat);
            return "Mở File thành công";
        }

        //Hàm lưu ảnh tạm thời
        public void SaveTempImage()
        {
            TempImage = ShowingImage.Clone();
        }

        //Hàm đặt về ảnh gốc
        public void ResetImage()
        {
            TempImage = SourceImage.Clone();
            ShowingImage = SourceImage.Clone();
            usingPictureBox.Image = MatToBitmap(SourceImage);
        }

        //Hàm đặt về ảnh tạm thời
        public void ResetToTempImage()
        {
            ShowingImage = TempImage.Clone();
            usingPictureBox.Image = MatToBitmap(TempImage);
        }

        //Hàm chuyển đổi màu ảnh
        public void ChangeBrightness(int brightness)
        {
            TempImage.ConvertTo(ShowingImage, MatType.CV_8UC3, 1, brightness);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }

        public void ChangeContrast(float contrast)
        {
            TempImage.ConvertTo(ShowingImage, MatType.CV_8UC3, contrast, 0);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }

        //Hàm cân bằng Histogram cho ảnh màu
        public void HistogramEqualization()
        {
            Cv2.CvtColor(TempImage, ShowingImage, ColorConversionCodes.BGR2YCrCb);
            Mat[] channels = Cv2.Split(ShowingImage);
            Cv2.EqualizeHist(channels[0], channels[0]);
            Cv2.Merge(channels, ShowingImage);
            Cv2.CvtColor(ShowingImage, ShowingImage, ColorConversionCodes.YCrCb2BGR);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            TempImage = ShowingImage.Clone();
        }

        //Hàm làm mờ ảnh
        public void BlurImage(int size)
        {
            Cv2.Blur(TempImage, ShowingImage, new OpenCvSharp.Size(size, size));
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }
        public void GaussianBlur(int size)
        {
            Cv2.GaussianBlur(TempImage, ShowingImage, new OpenCvSharp.Size(size, size), 0);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }

        //Hàm âm bản ảnh
        public void NegativeImage()
        {
            ShowingImage = new Mat();
            Cv2.BitwiseNot(TempImage, ShowingImage);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            TempImage = ShowingImage.Clone();
        }

        //Hàm làm xói mòn và làm giản ảnh
        public void ErodeImage(int size, int iterations)
        {
            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(size, size));
            Cv2.Erode(TempImage, ShowingImage, element, null, iterations);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            TempImage = ShowingImage.Clone();
            element.Dispose();
        }
        public void DilateImage(int size, int iterations)
        {
            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(size, size));
            Cv2.Dilate(TempImage, ShowingImage, element, null, iterations);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            TempImage = ShowingImage.Clone();
            element.Dispose();
        }

        //Xoay ảnh
        public void RotateImage(int angle)
        {
            Mat matRotation = Cv2.GetRotationMatrix2D(new Point2f(ShowingImage.Width / 2, ShowingImage.Height / 2), angle, 1);
            Cv2.WarpAffine(TempImage, ShowingImage, matRotation, TempImage.Size());
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            matRotation.Dispose();
        }

        //Phát hiện màu sắc
        public void DetectColor(int minH, int maxH, int minS, int maxS, int minV, int maxV)
        {
            Mat hsv = new Mat();
            Cv2.CvtColor(TempImage, hsv, ColorConversionCodes.BGR2HSV);
            Mat mask = new Mat();
            Cv2.InRange(hsv, new Scalar(minH, minS, minV), new Scalar(maxH, maxS, maxV), mask);
            Cv2.CvtColor(mask, mask, ColorConversionCodes.GRAY2BGR);
            Cv2.BitwiseAnd(TempImage, mask, ShowingImage);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            hsv.Dispose();
            mask.Dispose();
        }

        //Phát hiện đường viền
        public void DetectEdge(int threshold1, int threshold2)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, threshold1, threshold2);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
            ShowingImage = TempImage - gray;
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowDetectEdge(int threshold1, int threshold2)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, threshold1, threshold2);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
            Cv2.ImShow("Edge", gray);
            gray.Dispose();
            GC.Collect();
        }
        
        //Phát hiện đường viền bằng LoG
        public void DetectEdgeLoG(int size)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 0);
            Mat Dst = new Mat();
            Cv2.Laplacian(gray, Dst, MatType.CV_16S, size);
            Cv2.ConvertScaleAbs(Dst, Dst);
            Cv2.CvtColor(Dst, Dst, ColorConversionCodes.GRAY2BGR);
            ShowingImage = TempImage - Dst;
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            Dst.Dispose();
            GC.Collect();
        }
        public void ShowDetectEdgeLoG(int size)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 0);
            Mat Dst = new Mat();
            Cv2.Laplacian(gray, Dst, MatType.CV_16S, size);
            Cv2.ConvertScaleAbs(Dst, Dst);
            Cv2.ImShow("Edge", Dst);
            gray.Dispose();
            Dst.Dispose();
            GC.Collect();
        }

        //Phát hiện đường viền bằng DoG
        public void DetectEdgeDoG(int size1, int size2)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(size1, size1), 0);
            Mat gray2 = new Mat();
            Cv2.GaussianBlur(gray, gray2, new OpenCvSharp.Size(size2, size2), 0);
            gray = gray - gray2;
            gray.ConvertTo(gray, MatType.CV_8U, 16);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
            ShowingImage = TempImage - gray;
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            gray2.Dispose();
            GC.Collect();
        }
        public void ShowDetectEdgeDoG(int size1, int size2)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(size1, size1), 0);
            Mat gray2 = new Mat();
            Cv2.GaussianBlur(gray, gray2, new OpenCvSharp.Size(size2, size2), 0);
            gray = gray - gray2;
            gray.ConvertTo(gray, MatType.CV_8U, 16);
            Cv2.ImShow("Edge", gray);
            gray.Dispose();
            gray2.Dispose();
            GC.Collect();
        }

        //Phát hiện đường viền bằng Sobel
        public void DetectEdgeSobel(int size)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Mat grad_x = new Mat();
            Mat grad_y = new Mat();
            Mat abs_grad_x = new Mat();
            Mat abs_grad_y = new Mat();
            Cv2.Sobel(gray, grad_x, MatType.CV_16S, 1, 0, size);
            Cv2.Sobel(gray, grad_y, MatType.CV_16S, 0, 1, size);
            Cv2.ConvertScaleAbs(grad_x, abs_grad_x);
            Cv2.ConvertScaleAbs(grad_y, abs_grad_y);
            Cv2.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, gray);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
            ShowingImage = TempImage - gray;
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            grad_x.Dispose();
            grad_y.Dispose();
            abs_grad_x.Dispose();
            abs_grad_y.Dispose();
            GC.Collect();
        }
        public void ShowDetectEdgeSobel(int size)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Mat grad_x = new Mat();
            Mat grad_y = new Mat();
            Mat abs_grad_x = new Mat();
            Mat abs_grad_y = new Mat();
            Cv2.Sobel(gray, grad_x, MatType.CV_16S, 1, 0, size);
            Cv2.Sobel(gray, grad_y, MatType.CV_16S, 0, 1, size);
            Cv2.ConvertScaleAbs(grad_x, abs_grad_x);
            Cv2.ConvertScaleAbs(grad_y, abs_grad_y);
            Cv2.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, gray);
            Cv2.ImShow("Edge", gray);
            gray.Dispose();
            grad_x.Dispose();
            grad_y.Dispose();
            abs_grad_x.Dispose();
            abs_grad_y.Dispose();
            GC.Collect();
        }
        
        //Phát hiện góc Harris
        public void DetectCornerHarris(int blockSize, int ksize, double k, int threshold)
        {
            ShowingImage = TempImage.Clone();
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Mat dst = new Mat();
            Cv2.CornerHarris(gray, dst, blockSize, ksize, k);
            Cv2.Dilate(dst, dst, new Mat());
            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    if (dst.At<float>(i, j) > (float)threshold/100)
                    {
                        Cv2.Circle(ShowingImage, new OpenCvSharp.Point(j, i), 2, Scalar.Red);
                    }
                }
            }
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }
        public void ShowCornerHarris(int blockSize, int ksize, double k, int threshold)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Mat dst = new Mat();
            Cv2.CornerHarris(gray, dst, blockSize, ksize, k);
            Cv2.Dilate(dst, dst, new Mat());
            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    if (dst.At<float>(i, j) <= (float)threshold / 100)
                    {
                        dst.Set<float>(i, j, 0);
                    }
                }
            }
            Cv2.ImShow("Corner", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Phát hiện góc bằng FAST
        public void DetectCornerFAST(int threshold)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            KeyPoint[] keyPoints = Cv2.FAST(gray, threshold);
            Cv2.DrawKeypoints(TempImage, keyPoints, ShowingImage, Scalar.Red, DrawMatchesFlags.Default);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowCornerFAST(int threshold)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            KeyPoint[] keyPoints = Cv2.FAST(gray, threshold);
            Mat dst = new Mat(gray.Size(), MatType.CV_8UC1);
            Cv2.DrawKeypoints(dst, keyPoints, dst, Scalar.Red, DrawMatchesFlags.Default);
            Cv2.ImShow("Corner", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Tìm biên của vật thể
        public void FindContours(int threshold1, int threshold2)
        {
            ShowingImage = TempImage.Clone();
            Mat gray = new Mat();
            HierarchyIndex[] hierarchy;
            OpenCvSharp.Point[][] contours;

            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, threshold1, threshold2);
            Cv2.FindContours(gray, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            Cv2.DrawContours(ShowingImage, contours, -1, Scalar.Red, 2);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowContours(int threshold1, int threshold2)
        {
            Mat gray = new Mat();
            HierarchyIndex[] hierarchy;
            OpenCvSharp.Point[][] contours;

            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, threshold1, threshold2);
            Cv2.FindContours(gray, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            Mat dst = new Mat(gray.Size(), MatType.CV_8UC3);
            Cv2.DrawContours(dst, contours, -1, Scalar.Red, 2);
            Cv2.ImShow("Contours", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Biến đổi Hough tiêu chuẩn
        public void HoughTransform(int threshold)
        {
            ShowingImage = TempImage.Clone();
            Mat gray = TempImage.Canny(50, 200);
            LineSegmentPolar[] lines = Cv2.HoughLines(gray, 1, Math.PI / 180, threshold);
            foreach (LineSegmentPolar line in lines)
            {
                float rho = line.Rho;
                float theta = line.Theta;
                double a = Math.Cos(theta);
                double b = Math.Sin(theta);
                double x0 = a * rho;
                double y0 = b * rho;
                OpenCvSharp.Point pt1 = new OpenCvSharp.Point(x0 + 1000 * (-b), y0 + 1000 * a);
                OpenCvSharp.Point pt2 = new OpenCvSharp.Point(x0 - 1000 * (-b), y0 - 1000 * a);
                Cv2.Line(ShowingImage, pt1, pt2, Scalar.Red, 2);
            }
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowHoughTransform(int threshold)
        {
            Mat gray = TempImage.Canny(50, 200);
            LineSegmentPolar[] lines = Cv2.HoughLines(gray, 1, Math.PI / 180, threshold);
            Mat dst = new Mat(gray.Size(), MatType.CV_8UC3, new Scalar(0));
            foreach (LineSegmentPolar line in lines)
            {
                float rho = line.Rho;
                float theta = line.Theta;
                double a = Math.Cos(theta);
                double b = Math.Sin(theta);
                double x0 = a * rho;
                double y0 = b * rho;
                OpenCvSharp.Point pt1 = new OpenCvSharp.Point(x0 + 1000 * (-b), y0 + 1000 * a);
                OpenCvSharp.Point pt2 = new OpenCvSharp.Point(x0 - 1000 * (-b), y0 - 1000 * a);
                Cv2.Line(dst, pt1, pt2, Scalar.Red, 2);
            }
            Cv2.ImShow("Hough", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Biến đổi Hough xác suất
        public void HoughProbabilisticTransform(int threshold, int minLineLength, int maxLineGap)
        {
            ShowingImage = TempImage.Clone();
            Mat gray = TempImage.Canny(50, 200);
            LineSegmentPoint[] lines = Cv2.HoughLinesP(gray, 1, Math.PI / 180, threshold, minLineLength, maxLineGap);
            foreach (LineSegmentPoint line in lines)
            {
                Cv2.Line(ShowingImage, line.P1, line.P2, Scalar.Red, 2);
            }
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowHoughProbabilisticTransform(int threshold, int minLineLength, int maxLineGap)
        {
            Mat gray = TempImage.Canny(50, 200);
            LineSegmentPoint[] lines = Cv2.HoughLinesP(gray, 1, Math.PI / 180, threshold, minLineLength, maxLineGap);
            Mat dst = new Mat(gray.Size(), MatType.CV_8UC3, new Scalar(0));
            foreach (LineSegmentPoint line in lines)
            {
                Cv2.Line(dst, line.P1, line.P2, Scalar.Red, 2);
            }
            Cv2.ImShow("Hough", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Phát hiện đường tròn bằng Hough
        public void HoughCircleTransform(int minRadius, int maxRadius, int parameters1, int parameters2)
        {
            ShowingImage = TempImage.Clone();
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.MedianBlur(gray, gray, 5);

            CircleSegment[] circles = Cv2.HoughCircles(gray, HoughModes.Gradient, 1, 20, parameters1, parameters2, minRadius, maxRadius);
            foreach (CircleSegment circle in circles)
            {
                Cv2.Circle(ShowingImage, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, Scalar.Red, 2);
            }
            usingPictureBox.Image = MatToBitmap(ShowingImage);
            gray.Dispose();
            GC.Collect();
        }
        public void ShowHoughCircleTransform(int minRadius, int maxRadius, int parameters1, int parameters2)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(TempImage, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.MedianBlur(gray, gray, 5);

            CircleSegment[] circles = Cv2.HoughCircles(gray, HoughModes.Gradient, 1, 20, parameters1, parameters2, minRadius, maxRadius);
            Mat dst = new Mat(gray.Size(), MatType.CV_8UC3, new Scalar(0));
            foreach (CircleSegment circle in circles)
            {
                Cv2.Circle(dst, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, Scalar.Red, 2);
            }
            Cv2.ImShow("Hough", dst);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        //Tính Histogram
        public int[][] Histogram()
        {
            int width = ShowingImage.Width;
            int height = ShowingImage.Height;
            int[][] histogram = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                histogram[i] = new int[256];
            }
            Mat[] bgr = Cv2.Split(ShowingImage);
            for (int i=0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    histogram[0][bgr[0].At<byte>(i, j)]++;
                    histogram[1][bgr[1].At<byte>(i, j)]++;
                    histogram[2][bgr[2].At<byte>(i, j)]++;
                }    
            }    
            return histogram;
        }

        public Boolean FFT = false;
        Mat FFTImage = new Mat();
        //Biến đổi Fourier
        public void FourierTransform()
        {
            if (FFT)
            {
                InverseFourierTransform();
                FFT = false;
                return;
            }
            FFT = true;
            Cv2.CvtColor(ShowingImage, ShowingImage, ColorConversionCodes.BGR2GRAY);
            ShowingImage.ConvertTo(ShowingImage, MatType.CV_32F);

            Cv2.Dft(ShowingImage, FFTImage, DftFlags.ComplexOutput | DftFlags.Scale);

            Cv2.Dft(ShowingImage, ShowingImage, DftFlags.ComplexOutput);
            Cv2.Magnitude(ShowingImage.Split()[0], ShowingImage.Split()[1], ShowingImage);
            Cv2.CopyMakeBorder(ShowingImage, ShowingImage, 0, Cv2.GetOptimalDFTSize(ShowingImage.Rows) - ShowingImage.Rows, 0, Cv2.GetOptimalDFTSize(ShowingImage.Cols) - ShowingImage.Cols, BorderTypes.Constant, Scalar.All(0));

            //Scale ảnh theo logarit
            ShowingImage += new Scalar(1);
            Cv2.Log(ShowingImage, ShowingImage);
            RearrangeFFT();
            Cv2.Normalize(ShowingImage, ShowingImage, 0, 1, NormTypes.MinMax);
            ShowingImage.ConvertTo(ShowingImage, MatType.CV_8U, 255);
            Cv2.CvtColor(ShowingImage, ShowingImage, ColorConversionCodes.GRAY2BGR);
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }

        //Biến đổi Fourier ngược
        public void InverseFourierTransform()
        {
            Cv2.Dft(FFTImage, FFTImage, DftFlags.Inverse | DftFlags.RealOutput);
            FFTImage.ConvertTo(FFTImage, MatType.CV_8U);
            Cv2.CvtColor(FFTImage, FFTImage, ColorConversionCodes.GRAY2BGR);
            ShowingImage = FFTImage.Clone();
            usingPictureBox.Image = MatToBitmap(ShowingImage);
        }

        //Sắp xếp lại các góc phần tư sao cho điểm gốc nằm ở tâm ảnh
        public void RearrangeFFT()
        {
            ShowingImage = ShowingImage.SubMat(new Rect(0, 0, ShowingImage.Cols & -2, ShowingImage.Rows & -2));
            int cx = ShowingImage.Cols / 2;
            int cy = ShowingImage.Rows / 2;
            Mat q0 = ShowingImage[new Rect(0, 0, cx, cy)];
            Mat q1 = ShowingImage[new Rect(cx, 0, cx, cy)];
            Mat q2 = ShowingImage[new Rect(0, cy, cx, cy)];
            Mat q3 = ShowingImage[new Rect(cx, cy, cx, cy)];
            Mat tmp = new Mat();
            q0.CopyTo(tmp);
            q3.CopyTo(q0);
            tmp.CopyTo(q3);
            q1.CopyTo(tmp);
            q2.CopyTo(q1);
            tmp.CopyTo(q2);
            tmp.Dispose();
        }
    }
}
