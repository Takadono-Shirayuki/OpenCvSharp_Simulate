using OpenCvSharp;
using System.Diagnostics;

namespace OpenCVSharp_Video
{
    public class BasicOperations
    {
        PictureBox UsingPictureBox;
        VideoCapture Cap;

        public delegate void Operation(Mat Frame, int[] IntParameter, double[] DoubleParameter);
        public delegate Mat MultiFrameOperation(Mat[] Frame, int[] IntParameter, double[] DoubleParameter);
        public delegate Mat ReturnOperation(Mat Frame, int[] IntParameter, double[] DoubleParameter);
        public struct VideoInfo
        {
            public double Time;
            public int Length;

            public int Brightness;
            public double Contrast;

            public Operation? TempOperation;
            public Dictionary<int, Operation> Operations;
            public int DictionaryCount;
            public Dictionary<int, int[]> IntParameter;
            public Dictionary<int, double[]> DoubleParameter;

            public VideoInfo(int Length)
            {
                Time = 0;
                this.Length = Length;
                Brightness = 0;
                Contrast = 1;
                TempOperation = null;

                Operations = new Dictionary<int, Operation>();
                DictionaryCount = 0;
                IntParameter = new Dictionary<int, int[]>();
                DoubleParameter = new Dictionary<int, double[]>();
            }

            public void SaveTempOperation()
            {
                if (TempOperation != null)
                    Operations.Add(DictionaryCount++, TempOperation);
                TempOperation = null;
            }

            public void AddTempOperation(Operation operation, int[] IntParameter, double[] DoubleParameter)
            {
                TempOperation = operation;
                this.IntParameter[DictionaryCount] = IntParameter;
                this.DoubleParameter[DictionaryCount] = DoubleParameter;
            }
        }
        VideoInfo VideoInformation;

        public struct MultiFrameOperationInfo
        {
            public Boolean IsMultiFrameOperation;
            public int FrameCount;
            public MultiFrameOperation? Operation;
            public int[]? IntParameter;
            public double[]? DoubleParameter;

            public MultiFrameOperationInfo()
            {
                IsMultiFrameOperation = false;
                FrameCount = 0;
                Operation = null;
                IntParameter = null;
                DoubleParameter = null;
            }
            public void AddMultiFrameOperation(int FrameCount, MultiFrameOperation Operation, int[] IntParameter, double[] DoubleParameter)
            {
                IsMultiFrameOperation = true;
                this.FrameCount = FrameCount;
                this.Operation = Operation;
                this.IntParameter = IntParameter;
                this.DoubleParameter = DoubleParameter;
            }
            public void DeleteMultiFrameOperation()
            {
                IsMultiFrameOperation = false;
            }
        }
        MultiFrameOperationInfo MultiFrameOperationInformation;

        List<Mat> FrameList = new List<Mat>();
        /*********************************************************************************************************************/
        /// <summary>
        /// Lưu thao tác
        /// </summary>
        public void SaveOperation()
        {
            VideoInformation.SaveTempOperation();
        }

        /// <summary>
        /// Thêm thao tác xử lý trên Video
        /// </summary>
        /// <param name="operation">Thao tác cần thêm</param>
        /// <param name="IntParameter">Các tham số nguyên</param>
        /// <param name="DoubleParameter">Các tham số thực</param>
        public void AddOperation(Operation operation, int[] IntParameter, double[] DoubleParameter)
        {
            VideoInformation.AddTempOperation(operation, IntParameter, DoubleParameter);
            ReadVideo(VideoInformation.Time);
        }

        /// <summary>
        /// Xóa thao tác vừa thực hiện
        /// </summary>
        public void DeleteOperation()
        {
            VideoInformation.TempOperation = null;
        }

        /// <summary>
        /// Xóa thao tác
        /// </summary>
        /// <param name="key">Khóa của thao tác</param>
        public void DeleteOperation(int key)
        {
            VideoInformation.Operations.Remove(key);
        }

        /*********************************************************************************************************************/
        /// <summary>
        /// Thêm thao tác trên nhiều khung hình
        /// </summary>
        /// <param name="FrameCount">Số lượng khung hình sử dụng</param>
        /// <param name="Operation">Thao tác cần thêm</param>
        /// <param name="IntParameter">Các tham số nguyên</param>
        /// <param name="DoubleParameter">Các tham số thực</param>
        public void AddMultiFrameOperation(int FrameCount, MultiFrameOperation Operation, int[] IntParameter, double[] DoubleParameter)
        {
            MultiFrameOperationInformation.AddMultiFrameOperation(FrameCount, Operation, IntParameter, DoubleParameter);
            ReadVideo(VideoInformation.Time);
        }

        /// <summary>
        /// Xóa thao tác trên nhiều khung hình
        /// </summary>
        public void DeleteMultiFrameOperation()
        {
            MultiFrameOperationInformation.DeleteMultiFrameOperation();
        }

        /*********************************************************************************************************************/
        /// <summary>
        /// Lấy số lượng khung hình
        /// </summary>
        /// <returns></returns>
        public int GetFrameCount()
        {
            return Cap.FrameCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictureBox"></param>
        public BasicOperations(PictureBox pictureBox)
        {
            UsingPictureBox = pictureBox;
        }

        //Chuyển đổi Mat sang Bitmap
        public static Bitmap MatToBitmap(Mat image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
        }

        //Mở Video
        public Boolean LoadVideo(string path)
        {
            Cap = new VideoCapture(path);
            if (Cap.IsOpened())
            {
                VideoInformation = new VideoInfo(Cap.FrameCount);
                ReadVideo(0);
                return true;
            }
            return false;
        }

        //Đóng Video
        public void CloseVideo()
        {
            Cap.Release();
            UsingPictureBox.Image = null;
        }

        /// <summary>
        /// Lấy khung hình hiện tại
        /// </summary>
        /// <returns></returns>
        public Mat? GetCurrentFrame()
        {
            Mat frame = new Mat();
            if (!Cap.Read(frame))
                return null;
            frame.ConvertTo(frame, MatType.CV_8UC3, VideoInformation.Contrast, VideoInformation.Brightness);
            foreach (var operation in VideoInformation.Operations)
            {
                int index = operation.Key;
                operation.Value(frame, VideoInformation.IntParameter[index], VideoInformation.DoubleParameter[index]);
            }
            return frame;
        }

        public Boolean SetCurrentFrame(int Frame)
        {
            if (Frame < 0 || Frame >= Cap.FrameCount)
                return false;
            Cap.Set(VideoCaptureProperties.PosFrames, Frame);
            VideoInformation.Time = Cap.Get(VideoCaptureProperties.PosMsec);
            return true;
        }

        /// <summary>
        /// Đọc Video và hiển thị lên PictureBox
        /// </summary>
        /// <param name="Time">Thời gian tính bằng mini giây</param>
        public void ReadVideo(double Time)
        {
            Cap.Set(VideoCaptureProperties.PosMsec, Time);
            Mat? frame = GetCurrentFrame();
            if (frame == null)
                return;
            Mat temp = frame.Clone();
            if (VideoInformation.TempOperation != null)
                VideoInformation.TempOperation(frame, VideoInformation.IntParameter[VideoInformation.DictionaryCount], VideoInformation.DoubleParameter[VideoInformation.DictionaryCount]);
            if (MultiFrameOperationInformation.IsMultiFrameOperation)
            {
                if (Cap.Get(VideoCaptureProperties.PosFrames) < MultiFrameOperationInformation.FrameCount)
                    Cap.Set(VideoCaptureProperties.PosFrames, MultiFrameOperationInformation.FrameCount - 1);
                Mat[] InputFrame = new Mat[MultiFrameOperationInformation.FrameCount];
                Cap.Set(VideoCaptureProperties.PosFrames, Cap.Get(VideoCaptureProperties.PosFrames) - MultiFrameOperationInformation.FrameCount + 1);
                for (int i = 0; i < MultiFrameOperationInformation.FrameCount; i++)
                {
                    InputFrame[i] = GetCurrentFrame();
                }
                frame.SetTo(Scalar.Red, MultiFrameOperationInformation.Operation(InputFrame, MultiFrameOperationInformation.IntParameter, MultiFrameOperationInformation.DoubleParameter).Split()[2]);
            }
            UsingPictureBox.Image = MatToBitmap(frame);
            frame.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Phát kết quả của thao tác
        /// </summary>
        /// <param name="Operation">Thao tác</param>
        /// <param name="IntParameter">Các tham số nguyên</param>
        /// <param name="DoubleParameter">Các tham số thực</param>
        /// <param name="Title">Tiêu đề cửa sổ</param>
        public void ShowResult(ReturnOperation Operation, int[] IntParameter, double[] DoubleParameter, string Title)
        {
            Stopwatch stopwatch = new Stopwatch();
            Mat? frame;
            Cv2.NamedWindow(Title, WindowFlags.KeepRatio);
            stopwatch.Start();
            while (true)
            {
                Cap.Set(VideoCaptureProperties.PosMsec, VideoInformation.Time + stopwatch.ElapsedMilliseconds);
                frame = GetCurrentFrame();
                if (frame == null)
                    break;
                Cv2.ImShow(Title, Operation(frame, IntParameter, DoubleParameter));
                if (Cv2.WaitKey(1) == 27)
                {
                    VideoInformation.Time += stopwatch.ElapsedMilliseconds;
                    break;
                }
                frame.Dispose();
                GC.Collect();
            }
            Cv2.DestroyWindow(Title);
        }

        /// <summary>
        /// Phát kết quả của thao tác trên nhiều khung hình
        /// </summary>
        /// <param name="FrameCount">Số khung hình của thao tác</param>
        /// <param name="Operation">Thao tác</param>
        /// <param name="IntParameter">Các tham số nguyên</param>
        /// <param name="DoubleParameter">Các tham số thực</param>
        /// <param name="Title">Tiêu đề cửa sổ</param>
        public void ShowResult(int FrameCount, MultiFrameOperation Operation, int[] IntParameter, double[] DoubleParameter, string Title)
        {
            Stopwatch stopwatch = new Stopwatch();
            Mat? frame, Output;
            if (Cap.Get(VideoCaptureProperties.PosFrames) < FrameCount)
                Cap.Set(VideoCaptureProperties.PosFrames, FrameCount - 1);
            Cap.Set(VideoCaptureProperties.PosFrames, Cap.Get(VideoCaptureProperties.PosFrames) - FrameCount + 1);
            List<Mat> InputFrame = new List<Mat>();
            for (int i = 0; i < FrameCount; i++)
            {
                InputFrame.Add(GetCurrentFrame());
            }
            Cv2.NamedWindow(Title, WindowFlags.KeepRatio);
            stopwatch.Start();
            while (true)
            {
                Cap.Set(VideoCaptureProperties.PosMsec, VideoInformation.Time + stopwatch.ElapsedMilliseconds);
                frame = GetCurrentFrame();
                if (frame == null)
                    break;
                InputFrame.Add(frame);
                InputFrame.RemoveAt(0);
                Output = frame.Clone();
                Output.SetTo(Scalar.Red, Operation(InputFrame.ToArray<Mat>(), IntParameter, DoubleParameter).Split()[2]);

                Cv2.ImShow(Title, Output);
                if (Cv2.WaitKey(1) == 27)
                {
                    VideoInformation.Time += stopwatch.ElapsedMilliseconds;
                    break;
                }
                Output.Dispose();
                GC.Collect();
            }
            InputFrame.Clear();
            Cv2.DestroyWindow(Title);
        }

        /// <summary>
        /// Phát Video
        /// </summary>
        public void PlayVideo()
        {
            Stopwatch stopwatch = new Stopwatch();
            Mat? frame;

            Cv2.NamedWindow("Play Video", WindowFlags.KeepRatio);
            stopwatch.Start();
            while (true)
            {
                Cap.Set(VideoCaptureProperties.PosMsec, VideoInformation.Time + stopwatch.ElapsedMilliseconds);

                frame = GetCurrentFrame();
                if (frame == null)
                    break;
                if (VideoInformation.TempOperation != null)
                    VideoInformation.TempOperation(frame, VideoInformation.IntParameter[VideoInformation.DictionaryCount], VideoInformation.DoubleParameter[VideoInformation.DictionaryCount]);
                Cv2.ImShow("Play Video", frame);

                if (Cv2.WaitKey(1) == 27)
                {
                    VideoInformation.Time += stopwatch.ElapsedMilliseconds;
                    break;
                }
            }
            Cv2.DestroyWindow("Play Video");
        }

        /// <summary>
        /// Đặt lại Video
        /// </summary>
        public void ResetVideo()
        {
            VideoInformation.Brightness = 0;
            VideoInformation.Contrast = 1;
            VideoInformation.Operations.Clear();
            VideoInformation.DictionaryCount = 0;
            VideoInformation.IntParameter.Clear();
            VideoInformation.DoubleParameter.Clear();
            
            DeleteOperation();
            DeleteMultiFrameOperation();
            ReadVideo(0);
        }

        /// <summary>
        /// Lưu Video
        /// </summary>
        /// <param name="path">Đường dẫn</param>
        /// <returns></returns>
        public Boolean SaveVideo(string path)
        {
            try
            {
                VideoWriter writer = new VideoWriter(path, FourCC.XVID, Cap.Fps, new OpenCvSharp.Size(Cap.FrameWidth, Cap.FrameHeight));
                Mat frame = new Mat();
                Mat Output;
                List<Mat> InputFrame = new List<Mat>();

                while (true)
                {
                    if (Cap.Read(frame))
                    {
                        frame.ConvertTo(frame, MatType.CV_8UC3, VideoInformation.Contrast, VideoInformation.Brightness);
                        foreach (var operation in VideoInformation.Operations)
                        {
                            int index = operation.Key;
                            operation.Value(frame, VideoInformation.IntParameter[index], VideoInformation.DoubleParameter[index]);
                        }
                        InputFrame.Add(frame);
                        Output = frame.Clone();
                        if (MultiFrameOperationInformation.IsMultiFrameOperation && Cap.Get(VideoCaptureProperties.PosFrames) >= MultiFrameOperationInformation.FrameCount)
                        {
                            InputFrame.RemoveAt(0);
                            Cap.Set(VideoCaptureProperties.PosFrames, Cap.Get(VideoCaptureProperties.PosFrames) - MultiFrameOperationInformation.FrameCount + 1);
                            for (int i = 0; i < MultiFrameOperationInformation.FrameCount; i++)
                            {
                                InputFrame[i] = GetCurrentFrame();
                            }
                            Output.SetTo(Scalar.Red, MultiFrameOperationInformation.Operation(InputFrame.ToArray<Mat>(), MultiFrameOperationInformation.IntParameter, MultiFrameOperationInformation.DoubleParameter).Split()[2]);
                        }
                        writer.Write(Output);
                    }
                    else
                    {
                        break;
                    }
                }
                writer.Release();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*********************************************************************************************************************/
        //Thao tác cơ bản
        /// <summary>
        /// Thay đổi độ sáng
        /// </summary>
        /// <param name="Value">Độ sáng</param>
        public void ChangeBrightness(int Value)
        {
            VideoInformation.Brightness = Value;
            ReadVideo(VideoInformation.Time);
        }

        /// <summary>
        /// Thay đổi độ tương phản
        /// </summary>
        /// <param name="Value">Độ tương phản</param>
        public void ChangeContrast(double Value)
        {
            VideoInformation.Contrast = Value;
            ReadVideo(VideoInformation.Time);
        }

        /// <summary>
        /// Cân bằng histogram
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">Rỗng</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void EqualizeHist(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Cv2.CvtColor(Frame, Frame, ColorConversionCodes.BGR2YCrCb);
            Cv2.Split(Frame, out Mat[] channels);
            Cv2.EqualizeHist(channels[0], channels[0]);
            Cv2.Merge(channels, Frame);
            Cv2.CvtColor(Frame, Frame, ColorConversionCodes.YCrCb2BGR);
        }

        /// <summary>
        /// Làm mờ khung hình
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: kích thước của kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void Blur(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Cv2.Blur(Frame, Frame, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]));
        }

        /// <summary>
        /// Làm mờ khung hình bằng Gaussian
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: kích thước của kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void GaussianBlur(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Cv2.GaussianBlur(Frame, Frame, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]), 0);
        }

        /// <summary>
        /// Làm xói mòn khung hình
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: kích thước của kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void Erode(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]));
            Cv2.Erode(Frame, Frame, kernel);
            kernel.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Làm nổi khung hình
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: kích thước của kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void Dilate(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]));
            Cv2.Dilate(Frame, Frame, kernel);
            kernel.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Phát hiện màu sắc
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: MinH, [1]: MinS, [2]: MinV, [3]: MaxH, [4]: MaxS, [5]: MaxV</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void DetectColor(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat Temp = Frame.Clone();
            Mat hsv = new Mat();
            Cv2.CvtColor(Frame, hsv, ColorConversionCodes.BGR2HSV);
            Mat mask = new Mat();
            Cv2.InRange(hsv, new Scalar(IntParameter[0], IntParameter[1], IntParameter[2]), new Scalar(IntParameter[3], IntParameter[4], IntParameter[5]), mask);
            Cv2.CvtColor(mask, mask, ColorConversionCodes.GRAY2BGR);
            Cv2.BitwiseAnd(Temp, mask, Frame);
            hsv.Dispose();
            mask.Dispose();
            GC.Collect();
        }

        /*********************************************************************************************************************/
        //Tìm cạnh
        /// <summary>
        /// Xóa thao tác tìm cạnh
        /// </summary>
        public void DeleteDetectEdgeOperation()
        {
            foreach (var item in VideoInformation.Operations)
            {
                if (item.Value.Method.Name.Contains("DetectEdge"))
                {
                    VideoInformation.Operations.Remove(item.Key);
                    VideoInformation.IntParameter.Remove(item.Key);
                    VideoInformation.DoubleParameter.Remove(item.Key);
                    break;
                }
            }
        }

        /// <summary>
        /// Tìm cạnh bằng Canny
        /// </summary>
        /// <param name="Frame">Hình ảnh đầu vào</param>
        /// <param name="IntParameter">[0]: Ngưỡng thấp, [1]: Ngưỡng cao</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void DetectEdge(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, IntParameter[0], IntParameter[1]);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
            Cv2.Subtract(Frame, gray, Frame);
            gray.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ cạnh bằng Canny
        /// </summary>
        /// <param name="Frame">Hình ảnh đầu vào</param>
        /// <param name="IntParameter">[0]: Ngưỡng thấp, [1]: Ngưỡng cao</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static Mat ShowDetectEdge(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Canny(gray, gray, IntParameter[0], IntParameter[1]);
            return gray;
        }

        ///<summary>
        /// Phát hiện cạnh bằng LoG
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void DetectEdgeLoG(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 0);
            Mat dst = new Mat();
            Cv2.Laplacian(gray, dst, MatType.CV_16S, IntParameter[0]);
            Cv2.ConvertScaleAbs(dst, dst);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.GRAY2BGR);
            Cv2.Subtract(Frame, dst, Frame);
            gray.Dispose();
            dst.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ cạnh bằng LoG
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước kernel</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static Mat ShowDetectEdgeLoG(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 0);
            Mat dst = new Mat();
            Cv2.Laplacian(gray, dst, MatType.CV_16S, IntParameter[0]);
            Cv2.ConvertScaleAbs(dst, dst);
            gray.Dispose();
            return dst;
        }

        /// <summary>
        /// Tìm cạnh bằng DoG
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước kernel 1, [1]: Kích thức kernel 2</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void DetectEdgeDoG(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Mat dst1 = new Mat();
            Cv2.GaussianBlur(gray, dst1, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]), 0);
            Mat dst2 = new Mat();
            Cv2.GaussianBlur(gray, dst2, new OpenCvSharp.Size(IntParameter[1], IntParameter[1]), 0);
            Mat dst = 16 * (dst2 - dst1);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.GRAY2BGR);
            Cv2.Subtract(Frame, dst, Frame);
            gray.Dispose();
            dst.Dispose();
            dst1.Dispose();
            dst2.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ cạnh bằng DoG
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước kernel 1, [1]: Kích thước kernel 2</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static Mat ShowDetectEdgeDoG(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Mat dst1 = new Mat();
            Cv2.GaussianBlur(gray, dst1, new OpenCvSharp.Size(IntParameter[0], IntParameter[0]), 0);
            Mat dst2 = new Mat();
            Cv2.GaussianBlur(gray, dst2, new OpenCvSharp.Size(IntParameter[1], IntParameter[1]), 0);
            Mat dst = 16 * (dst2 - dst1);
            gray.Dispose();
            dst1.Dispose();
            dst2.Dispose();
            return dst;
        }

        /*********************************************************************************************************************/
        //Tìm góc
        /// <summary>
        /// Xóa thao tác tìm góc
        /// </summary>
        public void DeleteDetectCornerOperation()
        {
            foreach (var item in VideoInformation.Operations)
            {
                if (item.Value.Method.Name.Contains("DetectCorner"))
                {
                    VideoInformation.Operations.Remove(item.Key);
                    VideoInformation.IntParameter.Remove(item.Key);
                    VideoInformation.DoubleParameter.Remove(item.Key);
                    break;
                }
            }
        }

        /// <summary>
        /// Phát hiện góc bằng Harris
        /// </summary>
        /// <param name="Frame">Hình ảnh đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước khối, [1]: Kích thước kernel, [2]: Ngưỡng phát hiện</param>
        /// <param name="DoubleParameter">[0]: Tham số Harris</param>
        public static void DetectCornerHarris(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Mat corner = new Mat();
            Cv2.CornerHarris(gray, corner, IntParameter[0], IntParameter[1], DoubleParameter[0]);
            Cv2.Dilate(corner, corner, new Mat());
            for (int i = 0; i < corner.Rows; i++)
                for (int j = 0; j < corner.Cols; j++)
                    if (corner.At<float>(i, j) > IntParameter[2] / 100.0)
                        Cv2.Circle(Frame, new OpenCvSharp.Point(j, i), 2, Scalar.Red);
            gray.Dispose();
            corner.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ góc bằng Harris
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Kích thước khối, [1]: Kích thước kernel</param>
        /// <param name="DoubleParameter">[0]: Tham số Harris</param>
        public static Mat ShowDetectCornerHarris(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Mat corner = new Mat();
            Cv2.CornerHarris(gray, corner, IntParameter[0], IntParameter[1], DoubleParameter[0]);
            Cv2.Dilate(corner, corner, new Mat());
            gray.Dispose();
            return corner;
        }

        /// <summary>
        /// Phát hiện góc bằng Shi-Tomasi
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Số góc tối đa, [1]: Kích thước khối</param>
        /// <param name="DoubleParameter">[0]: Cấp độ chất lượng, [1]: Khoảng cách tối thiểu, [2]: Hệ số k</param>
        public static void DetectCornerShiTomasi(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Point2f[] Cornors = Cv2.GoodFeaturesToTrack(gray, IntParameter[0], DoubleParameter[0], DoubleParameter[1], new Mat(), IntParameter[1], false, DoubleParameter[2]);
            foreach (var item in Cornors)
                Cv2.Circle(Frame, new OpenCvSharp.Point(item.X, item.Y), 2, Scalar.Red, 2);
            gray.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ góc bằng Shi-Tomasi
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Số góc tối đa, [1]: Kích thước khối</param>
        /// <param name="DoubleParameter">[0]: Cấp độ chất lượng, [1]: Khoảng cách tối thiểu, [2]: Hệ số k</param>
        public static Mat ShowDetectCornerShiTomasi(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            Point2f[] Cornors = Cv2.GoodFeaturesToTrack(gray, IntParameter[0], DoubleParameter[0], DoubleParameter[1], new Mat(), IntParameter[1], false, DoubleParameter[2]);
            Mat dst = new Mat(Frame.Size(), MatType.CV_8UC3, Scalar.Black);
            foreach (var item in Cornors)
                Cv2.Circle(dst, new OpenCvSharp.Point(item.X, item.Y), 2, Scalar.Red, 2);
            gray.Dispose();
            return dst;
        }

        /// <summary>
        /// Phát hiện góc bằng FAST
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Ngưỡng tìm kiếm</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static void DetectCornerFAST(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            KeyPoint[] keyPoints = Cv2.FAST(gray, IntParameter[0]);
            Cv2.DrawKeypoints(Frame, keyPoints, Frame, Scalar.Red, DrawMatchesFlags.DrawRichKeypoints);
            gray.Dispose();
            GC.Collect();
        }

        /// <summary>
        /// Tạo bản đồ góc bằng FAST
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Ngưỡng tìm kiếm</param>
        /// <param name="DoubleParameter">Rỗng</param>
        public static Mat ShowDetectCornerFAST(Mat Frame, int[] IntParameter, double[] DoubleParameter)
        {
            Mat dst = new Mat(Frame.Size(), MatType.CV_8UC3, Scalar.Black);
            Mat gray = new Mat();
            Cv2.CvtColor(Frame, gray, ColorConversionCodes.BGR2GRAY);
            KeyPoint[] keyPoints = Cv2.FAST(gray, IntParameter[0]);
            Cv2.DrawKeypoints(dst, keyPoints, dst, Scalar.Red, DrawMatchesFlags.DrawRichKeypoints);
            gray.Dispose();
            return dst;
        }

        /*********************************************************************************************************************/
        //Tính toán dòng quang học

        /// <summary>
        /// Tính dòng quang học bằng thuật toán Horn-Schunk
        /// </summary>
        /// <param name="Frame">Khung hình đầu vào</param>
        /// <param name="IntParameter">[0]: Ngưỡng giới hạn</param>
        /// <param name="DoubleParameter">[0]: Tham số lambda</param>
        /// <returns></returns>
        public static Mat OpticalFlow_Horn_Schunk(Mat[] Frame, int[] IntParameter, double[] DoubleParameter)
        {
            //Chuyển đổi sang ảnh xám
            Mat I1, I2;
            I1 = Frame[0].Clone();
            I2 = Frame[1].Clone();
            Cv2.CvtColor(I1, I1, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(I2, I2, ColorConversionCodes.BGR2GRAY);

            //Tính đạo hàm riêng
            Mat Ix, Iy, It;
            Ix = new Mat();
            Iy = new Mat();
            Cv2.Sobel(I1, Ix, MatType.CV_64F, 1, 0, 3);
            Cv2.Sobel(I1, Iy, MatType.CV_64F, 0, 1, 3);
            It = I2 - I1;
            It.ConvertTo(It, MatType.CV_64F);

            //Khởi tạo U, V
            Mat U, V;
            U = new Mat(I1.Size(), MatType.CV_64F, Scalar.Black);
            V = new Mat(I1.Size(), MatType.CV_64F, Scalar.Black);

            //Tạo kernel tính trung bình
            Mat kernel = new Mat(3, 3, MatType.CV_64F, new Scalar(1 / 9));

            Mat alpha = new Mat(I1.Size(), MatType.CV_64F);
            Mat U_avg, V_avg;
            U_avg = new Mat(I1.Size(), MatType.CV_64F);
            V_avg = new Mat(I1.Size(), MatType.CV_64F);

            for (int i = 0; i < IntParameter[0]; i++)
            {
                //Tính trung bình của U, V
                Cv2.Filter2D(U, U_avg, MatType.CV_64F, kernel);
                Cv2.Filter2D(V, V_avg, MatType.CV_64F, kernel);

                //Tính alpha
                Cv2.Divide(Ix.Mul(U_avg) + Iy.Mul(V_avg) + It, Ix.Mul(Ix) + Iy.Mul(Iy) + Math.Pow(DoubleParameter[0], 2), alpha);

                //Cập nhật U, V
                U = U_avg - Ix.Mul(alpha);
                V = V_avg - Iy.Mul(alpha);
                GC.Collect();
            }

            //Vẽ dòng quang
            Mat Output = new Mat(Frame[0].Size(), MatType.CV_8UC3);
            double max = 0;
            for (int i = 20; i < Output.Rows; i += 20)
                for (int j = 20; j < Output.Cols; j += 20)
                {
                    if (double.IsNaN(U.At<double>(i, j)) || double.IsNaN(V.At<double>(i, j)))
                    {
                        U.Set<double>(i, j, 0);
                        V.Set<double>(i, j, 0);
                        continue;
                    }
                    double p2x = Math.Abs(U.At<double>(i, j));
                    double p2y = Math.Abs(V.At<double>(i, j));
                    if (p2x > max)
                        max = p2x;
                    if (p2y > max)
                        max = p2y;
                }
            U.ConvertTo(U, U.Type(), IntParameter[1] / max);
            V.ConvertTo(V, V.Type(), IntParameter[1] / max);
            for (int i = 20; i < Output.Rows; i += 20)
                for (int j = 20; j < Output.Cols; j += 20)
                {
                    int p2x = (int)U.At<double>(i, j);
                    int p2y = (int)V.At<double>(i, j);
                    if (p2x == 0 && p2y == 0)
                        continue;
                    OpenCvSharp.Point p1 = new OpenCvSharp.Point(j, i);
                    OpenCvSharp.Point p2 = new OpenCvSharp.Point(j + p2y, i + p2x);
                    Cv2.ArrowedLine(Output, p1, p2, Scalar.Red);
                }

            //Giải phóng bộ nhớ
            I1.Dispose();
            I2.Dispose();
            Ix.Dispose();
            Iy.Dispose();
            It.Dispose();
            U.Dispose();
            V.Dispose();
            U_avg.Dispose();
            V_avg.Dispose();
            alpha.Dispose();
            return Output;
        }

        static Mat OpticalFlowMatWithLK = new Mat();
        public void CreateOutput(Mat Frame)
        {
            OpticalFlowMatWithLK = new Mat(Frame.Size(), MatType.CV_8UC3, Scalar.Black);
        }
        /// <summary>
        /// Tính dòng quang học bằng thuật toán Lucas-Kanade
        /// </summary>
        /// <param name="Frame"></param>
        /// <param name="IntParameter"></param>
        /// <param name="DoubleParameter"></param>
        /// <returns></returns>
        public static Mat OpticalFlow_LK(Mat[] Frame, int[] IntParameter, double[] DoubleParameter)
        {
            //Chuyển đổi sang ảnh xám
            Mat I1, I2;
            I1 = Frame[0].Clone();
            I2 = Frame[1].Clone();
            Cv2.CvtColor(I1, I1, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(I2, I2, ColorConversionCodes.BGR2GRAY);

            //Tìm góc trong ảnh đầu tiên
            Point2f[] p0 = Cv2.GoodFeaturesToTrack(I1, 25, 0.01, 10, new Mat(), 3, false, 0.04);

            //Tính dòng quang học
            Point2f[] p1 = new Point2f[p0.Length];
            TermCriteria termCriteria = new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, IntParameter[0], DoubleParameter[0]);
            Cv2.CalcOpticalFlowPyrLK(I1, I2, p0, ref p1, out byte[] status, out float[] err, new OpenCvSharp.Size(IntParameter[1], IntParameter[1]), IntParameter[2], termCriteria);
            
            //Vẽ dòng quang
            for (int i = 0; i < p0.Length; i++)
            {
                if (status[i] == 1)
                {
                    OpenCvSharp.Point p0_ = new OpenCvSharp.Point((int)p0[i].X, (int)p0[i].Y);
                    OpenCvSharp.Point p1_ = new OpenCvSharp.Point((int)p1[i].X, (int)p1[i].Y);
                    Cv2.Line(OpticalFlowMatWithLK, p0_, p1_, Scalar.Red, 2);
                }
            }
            //Giải phóng bộ nhớ
            I1.Dispose();
            I2.Dispose();
            return OpticalFlowMatWithLK;
        }
    }
}
