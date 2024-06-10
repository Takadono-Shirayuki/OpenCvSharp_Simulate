namespace OpenCVSharp_Video
{
    public partial class Form1 : Form
    {
        public delegate void Operation();
        public delegate string TbValueChange(int Value);
        public delegate int ValueChange(string Value);
        public delegate void ShowImage();

        BasicOperations BasicOperations;
        public Form1()
        {
            InitializeComponent();
            BasicOperations = new BasicOperations(pictureBox1);
        }

        //Gửi thông báo hệ thống
        private void SendMessage(string message)
        {
            Message.Text = "Thông báo: \n" + message;
            if (!tắtThôngBáoToolStripMenuItem.Checked)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Gửi thông báo chức năng hiện tại
        private void SendSubMessage(string message)
        {
            Message.Text = "Chức năng hiện tại: " + message;
        }

        //Thêm Control vào Panel1
        int ControlLocation = 0;
        private void AddInteractiveTrackbar(string Text, Operation? operation = null, TbValueChange? tbValueChange = null, ValueChange? valueChange = null, int DefautValue = 0, int TrackBarMinimun = 0, int TrackBarMaxium = 255, int TrackBarLargeChange = 10)
        {
            InteractiveTrackBar interactiveTrackbar = new InteractiveTrackBar(Text, operation, tbValueChange, valueChange, TrackBarMinimun, TrackBarMaxium, TrackBarLargeChange);
            interactiveTrackbar.Location = new Point(0, ControlLocation);
            panel1.Controls.Add(interactiveTrackbar);
            interactiveTrackbar.DefaultValue = DefautValue;
            ControlLocation += 75;
        }

        private void AddInteractiveDoubleTrackbar(string[] Text, Operation? operation = null, TbValueChange? tbValueChange = null, ValueChange? valueChange = null, int[]? DefaultValue = null, int[]? TrackBarMinimun = null, int[]? TrackBarMaxium = null, int[]? TrackBarLargeChange = null)
        {
            InteractiveDoubleTrackBar interactiveDoubleTrackbar = new InteractiveDoubleTrackBar(Text, operation, tbValueChange, valueChange, TrackBarMinimun, TrackBarMaxium, TrackBarLargeChange);
            interactiveDoubleTrackbar.Location = new Point(0, ControlLocation);
            panel1.Controls.Add(interactiveDoubleTrackbar);
            if (DefaultValue != null)
            {
                interactiveDoubleTrackbar.DefaultValueLow = DefaultValue[0];
                interactiveDoubleTrackbar.DefaultValueHigh = DefaultValue[1];
            }
            ControlLocation += 145;
        }

        private void AddInteractiveSelectTrackbar(string[] Text, Operation[] operation, TbValueChange? tbValueChange = null, ValueChange? valueChange = null, int DefaultValue = 0, int TrackBarMinimun = 0, int TrackBarMaxium = 255, int TrackBarLargeChange = 10)
        {
            List<InteractiveSelectTrackBar> Group = new List<InteractiveSelectTrackBar>();
            for (int i = 0; i < Text.Length; i++)
            {
                InteractiveSelectTrackBar interactiveSelectTrackbar = new InteractiveSelectTrackBar(Group, Text[i], operation[i], tbValueChange, valueChange, TrackBarMinimun, TrackBarMaxium, TrackBarLargeChange);
                interactiveSelectTrackbar.Location = new Point(0, ControlLocation);
                panel1.Controls.Add(interactiveSelectTrackbar);
                interactiveSelectTrackbar.DefaultValue = DefaultValue;
                ControlLocation += 75;
            }
        }

        private void AddIButton(string Text, ShowImage showImage)
        {
            IButton iButton = new IButton(Text, showImage);
            iButton.Location = new Point(200, ControlLocation);
            panel1.Controls.Add(iButton);
            ControlLocation += 65;
        }

        /*************************************************************************************************************************************************************************************/
        //Các sự kiện MenuItem Thao tác cơ bản
        private void mởVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.flv;*.mov;*.wmv;*.mkv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Boolean IsOpened = BasicOperations.LoadVideo(openFileDialog.FileName);
                if (IsOpened)
                {
                    BasicOperations.ReadVideo(0);
                    SendMessage("Mở video thành công");
                    progressBar1.Maximum = BasicOperations.GetFrameCount();
                    progressBar1.Value = 0;

                    quayLạiVideoGốcToolStripMenuItem.Enabled = true;
                    lưuVideoToolStripMenuItem.Enabled = true;
                    đóngVideoToolStripMenuItem.Enabled = true;

                    thayĐổiĐộSángToolStripMenuItem.Enabled = true;
                    thayĐổiĐộTươngPhảnToolStripMenuItem.Enabled = true;
                    cânBằngHistogramToolStripMenuItem.Enabled = true;
                    làmMờToolStripMenuItem.Enabled = true;
                    làmXóiMònLàmGiãnToolStripMenuItem.Enabled = true;
                    phátHiệnMàuSắcToolStripMenuItem.Enabled = true;
                    phátHiệnCạnhVớiCannyToolStripMenuItem.Enabled = true;

                    lưuThaoTácToolStripMenuItem.Enabled = true;
                    xóaThaoTácVừaThựcHiệnToolStripMenuItem.Enabled = true;
                    phátVideoToolStripMenuItem.Enabled = true;
                    lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Enabled = true;
                    cácThayĐổiHiệnTạiToolStripMenuItem.Enabled = true;

                    chọnChứcNăngToolStripMenuItem.Enabled = true;
                    chứcNăng1ToolStripMenuItem1.Enabled = true;
                }
                else
                    SendMessage("Mở video thất bại");
            }
        }

        private void quayLạiVideoGốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.ResetVideo();
            SendMessage("Đã quay lại Video gốc");
        }

        private void lưuVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Video Files|*.mp4;*.avi;*.flv;*.mov;*.wmv;*.mkv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Boolean IsSaved = BasicOperations.SaveVideo(saveFileDialog.FileName);
                if (IsSaved)
                    SendMessage("Lưu video thành công");
                else
                    SendMessage("Lưu video thất bại");
            }
        }

        private void đóngVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.CloseVideo();

            quayLạiVideoGốcToolStripMenuItem.Enabled = false;
            lưuVideoToolStripMenuItem.Enabled = false;
            đóngVideoToolStripMenuItem.Enabled = false;

            thayĐổiĐộSángToolStripMenuItem.Enabled = false;
            thayĐổiĐộTươngPhảnToolStripMenuItem.Enabled = false;
            cânBằngHistogramToolStripMenuItem.Enabled = false;
            làmMờToolStripMenuItem.Enabled = false;
            làmXóiMònLàmGiãnToolStripMenuItem.Enabled = false;
            phátHiệnMàuSắcToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiCannyToolStripMenuItem.Enabled = false;

            lưuThaoTácToolStripMenuItem.Enabled = false;
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Enabled = false;
            phátVideoToolStripMenuItem.Enabled = false;
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Enabled = false;
            cácThayĐổiHiệnTạiToolStripMenuItem.Enabled = false;

            chọnChứcNăngToolStripMenuItem.Enabled = false;
            chứcNăng1ToolStripMenuItem1.Enabled = false;
            SetFunction(0);
            SendMessage("Đã đóng Video");
        }

        //Thay đổi độ sáng
        private void BrightnessChangeOperation()
        {
            BasicOperations.ChangeBrightness(int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText));
        }
        private void thayĐổiĐộSángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Độ sáng", BrightnessChangeOperation, null, null, 0, -255);
            SendSubMessage("Thay đổi độ sáng của Video");
        }

        //Thay đổi độ tương phản
        private void ContrastChangeOperation()
        {
            BasicOperations.ChangeContrast(float.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText));
        }
        private string TbValueChangeContrast(int Value)
        {
            if (Value < 0)
                return "0";
            if (Value > 190)
                return "10";
            if (Value < 100)
                return ((float)Value / 100).ToString();
            return ((float)Value / 10 - 9).ToString();
        }
        private int ValueChangeContrast(string Value)
        {
            if (float.TryParse(Value, out float result))
            {
                if (result < 0)
                    return 0;
                if (result > 10)
                    return 190;
                if (result < 1)
                    return (int)(result * 100);
                return (int)(result * 10 + 90);
            }
            return -1;
        }
        private void thayĐổiĐộTươngPhảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Độ tương phản", ContrastChangeOperation, TbValueChangeContrast, ValueChangeContrast, 100, 0, 190);
            SendSubMessage("Thay đổi độ tương phản của Video");
        }

        //Cân bằng Histogram
        private void cânBằngHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.AddOperation(BasicOperations.EqualizeHist, new int[0], new double[0]);
            SendMessage("Đã cân bằng Histogram");
        }

        //Làm mờ
        private void BlurOperation()
        {
            BasicOperations.AddOperation(BasicOperations.Blur, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText) }, new double[0]);
        }
        private void GaussianBlurOperation()
        {
            BasicOperations.AddOperation(BasicOperations.GaussianBlur, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, new double[0]);
        }
        private string TbValueChangeOdd1_25(int Value)
        {
            return (Value * 2 + 1).ToString();
        }
        private int ValueChangeOdd1_25(string Value)
        {
            if (int.TryParse(Value, out int result))
            {
                if (result < 1)
                    return 0;
                if (result > 25)
                    return 12;
                return (result - 1) / 2;
            }
            return -1;
        }
        private void làmMờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Làm mờ đồng nhất: ", BlurOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            AddInteractiveTrackbar("Làm mờ Gaussian: ", GaussianBlurOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            SendSubMessage("Làm mờ Video \n Chương trình thực hiện làm mờ đồng nhất hoặc làm mờ Gaussian dựa trên thao tác mới nhất.");
        }

        //Làm xói mòn và làm giãn
        private void ErodeOperation()
        {
            BasicOperations.AddOperation(BasicOperations.Erode, new int[] { int.Parse(((InteractiveSelectTrackBar)panel1.Controls[0]).ValueText) }, new double[0]);
        }
        private void DilateOperation()
        {
            BasicOperations.AddOperation(BasicOperations.Dilate, new int[] { int.Parse(((InteractiveSelectTrackBar)panel1.Controls[1]).ValueText) }, new double[0]);
        }
        private void làmXóiMònLàmGiãnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveSelectTrackbar(new string[] { "Làm xói mòn", "Làm giãn" }, new Operation[] { ErodeOperation, DilateOperation }, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            SendSubMessage("Làm xói mòn và làm giãn Video");
        }

        //Phát hiện màu sắc
        private void ColorDetectionOperation()
        {
            int[] IntParameter = new int[6];
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                IntParameter[i] = int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[i]).ValueLowText);
                IntParameter[i + 3] = int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[i]).ValueHighText);
            }
            BasicOperations.AddOperation(BasicOperations.DetectColor, IntParameter, new double[0]);
        }
        private void phátHiệnMàuSắcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveDoubleTrackbar(new string[] { "Ngưỡng màu sắc thấp", "Ngưỡng màu sắc cao" }, ColorDetectionOperation, null, null, new int[] { 0, 179 }, null, new int[] { 179, 179 });
            AddInteractiveDoubleTrackbar(new string[] { "Ngưỡng bão hòa thấp", "Ngưỡng bão hòa cao" }, ColorDetectionOperation, null, null, new int[] { 0, 255 }, null, new int[] { 255, 255 });
            AddInteractiveDoubleTrackbar(new string[] { "Ngưỡng độ sáng thấp", "Ngưỡng độ sáng cao" }, ColorDetectionOperation, null, null, new int[] { 0, 255 }, null, new int[] { 255, 255 });
            SendSubMessage("Phát hiện màu sắc trong Video");
        }

        //Phát hiện cạnh với Canny
        private void CannyOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectEdge, new int[] { int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueLowText), int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueHighText) }, new double[0]);
        }
        private void ShowDetectedEdge()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectEdge, new int[] { int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueLowText), int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueHighText) }, new double[0], "Edge Detect with Canny");
        }
        private void phátHiệnCạnhVớiCannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectEdgeOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveDoubleTrackbar(new string[] { "Ngưỡng thấp", "Ngưỡng cao" }, CannyOperation, null, null, new int[] { 100, 200 }, null, new int[] { 255, 255 });
            AddIButton("Hiển thị kết quả", ShowDetectedEdge);
            SendSubMessage("Phát hiện cạnh trong Video với Canny");
        }

        /*************************************************************************************************************************************************************************************/
        private void xóaThaoTácVừaThựcHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            BasicOperations.DeleteOperation();
            BasicOperations.ReadVideo(progressBar1.Value);
            SendMessage("Đã xóa thao tác vừa thực hiện");
        }

        private void phátVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.PlayVideo();
            SendSubMessage("Phát Video");
        }

        private void lưuKhungHìnhĐangHiểnThịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                    SendMessage("Lưu khung hình thành công");
                }
                catch
                {
                    SendMessage("Lưu khung hình thất bại");
                }
            }
        }

        private void cácThayĐổiHiệnTạiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Các sự kiện MenuItem Chức năng
        private void SetFunction(int function)
        {
            chứcNăng1ToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiLoGToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiDoGToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiHarrisToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiFASTToolStripMenuItem.Enabled = false;

            switch (function)
            {
                case 1:
                    chứcNăng1ToolStripMenuItem.Enabled = true;
                    phátHiệnCạnhVớiLoGToolStripMenuItem.Enabled = true;
                    phátHiệnCạnhVớiDoGToolStripMenuItem.Enabled = true;
                    phátHiệnGócVớiHarrisToolStripMenuItem.Enabled = true;
                    phátHiệnGócVớiShiTomasiToolStripMenuItem.Enabled = true;
                    phátHiệnGócVớiFASTToolStripMenuItem.Enabled = true;
                    break;
                default:
                    break;
            }
            if (function != 0)
                SendMessage("Đã chọn chức năng " + function.ToString());
        }

        private void chứcNăng1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetFunction(1);
        }

        /*************************************************************************************************************************************************************************************/
        //Các sự kiện MenuItem Cài đặt
        private void tắtThôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tắtThôngBáoToolStripMenuItem.Checked = !tắtThôngBáoToolStripMenuItem.Checked;
        }

        /*************************************************************************************************************************************************************************************/
        //Các sự kiện MenuItem Chức năng 1

        //Phát hiện cạnh với LoG
        private void LoGOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectEdgeLoG, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText) }, new double[0]);
        }
        private void ShowDetectedEdgeLoG()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectEdgeLoG, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText) }, new double[0], "Edge Detect with LoG");
        }
        private void phátHiệnCạnhVớiLoGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectEdgeOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Kích thước khối: ", LoGOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            AddIButton("Hiển thị kết quả", ShowDetectedEdgeLoG);
            SendSubMessage("Phát hiện cạnh trong Video với LoG");
        }

        //Phát hiện cạnh với DoG
        private void DoGOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectEdgeDoG, new int[] { int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueLowText), int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueHighText) }, new double[0]);
        }
        private void ShowDetectedEdgeDoG()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectEdgeDoG, new int[] { int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueLowText), int.Parse(((InteractiveDoubleTrackBar)panel1.Controls[0]).ValueHighText) }, new double[0], "Edge Detect with DoG");
        }
        private void phátHiệnCạnhVớiDoGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectEdgeOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveDoubleTrackbar(new string[] { "Ngưỡng thấp", "Ngưỡng cao" }, DoGOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, new int[] { 0, 0 }, null, new int[] { 12, 12 }, new int[] { 2, 2 });
            AddIButton("Hiển thị kết quả", ShowDetectedEdgeDoG);
            SendSubMessage("Phát hiện cạnh trong Video với DoG");
        }

        //Phát hiện góc với Harris
        private void HarrisOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectCornerHarris, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[3]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText) });
        }
        private void ShowDetectedCornerHarris()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectCornerHarris, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText) }, "Corner Detect with Harris");
        }
        private string TbValueChangeHarris(int Value)
        {
            return Math.Round(Value / 100.0, 2).ToString();
        }
        private int ValueChangeHarris(string Value)
        {
            if (double.TryParse(Value, out double result))
            {
                if (result < 0)
                    return 0;
                if (result > 1)
                    return 100;
                return (int)(result * 100);
            }
            return -1;
        }
        private void phátHiệnGócVớiHarrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectCornerOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Kích thước khối: ", HarrisOperation, null, null, 1, 1, 20, 2);
            AddInteractiveTrackbar("Kích thước cửa sổ: ", HarrisOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            AddInteractiveTrackbar("Hệ số k: ", HarrisOperation, TbValueChangeHarris, ValueChangeHarris, 0, 0, 100);
            AddInteractiveTrackbar("Ngưỡng phát hiện: ", HarrisOperation, null, null, 0, 0, 1000);
            AddIButton("Hiển thị kết quả", ShowDetectedCornerHarris);
            SendSubMessage("Phát hiện góc trong Video với Harris");
        }

        //Phát hiện góc với Shi-Tomasi
        private void ShiTomasiOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectCornerShiTomasi, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText), double.Parse(((InteractiveTrackBar)panel1.Controls[3]).ValueText), double.Parse(((InteractiveTrackBar)panel1.Controls[4]).ValueText) });
        }
        private void ShowDetectedCornerShiTomasi()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectCornerShiTomasi, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText), double.Parse(((InteractiveTrackBar)panel1.Controls[3]).ValueText), double.Parse(((InteractiveTrackBar)panel1.Controls[4]).ValueText) }, "Corner Detect with Shi-Tomasi");
        }
        private string TbValueChangeLog10(int Value)
        {
            return Math.Round(Math.Pow(10, Value / 100.0 - 2), 2).ToString();
        }
        private int ValueChangeLog10(string Value)
        {
            if (double.TryParse(Value, out double result))
            {
                if (result < 0)
                    return 0;
                if (result > 100)
                    return 400;
                return (int)(Math.Log10(result) * 100 + 200);
            }
            return -1;
        }
        private void phátHiệnGócVớiShiTomasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectCornerOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Số góc tối đa: ", ShiTomasiOperation, null, null, 0, 0, 100);
            AddInteractiveTrackbar("Kích thước cửa sổ: ", ShiTomasiOperation, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            AddInteractiveTrackbar("Hệ số chính xác: ", ShiTomasiOperation, TbValueChangeLog10, ValueChangeLog10, 0, 0, 400);
            AddInteractiveTrackbar("Khoảng cách tối thiểu: ", ShiTomasiOperation, null, null);
            AddInteractiveTrackbar("Hệ số k: ", ShiTomasiOperation, TbValueChangeHarris, ValueChangeHarris, 0, 0, 100);
            AddIButton("Hiển thị kết quả", ShowDetectedCornerShiTomasi);
            SendSubMessage("Phát hiện góc trong Video với Shi-Tomasi");
        }

        //Phát hiện góc với FAST
        private void FASTOperation()
        {
            BasicOperations.AddOperation(BasicOperations.DetectCornerFAST, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText) }, new double[0]);
        }
        private void ShowDetectedCornerFAST()
        {
            BasicOperations.ShowResult(BasicOperations.ShowDetectCornerFAST, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText) }, new double[0], "Corner Detect with FAST");
        }
        private void phátHiệnGócVớiFASTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            BasicOperations.DeleteDetectCornerOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Ngưỡng phát hiện: ", FASTOperation, null, null);
            AddIButton("Hiển thị kết quả", ShowDetectedCornerFAST);
            SendSubMessage("Phát hiện góc trong Video với FAST");
        }

        /*************************************************************************************************************************************************************************************/
        //Các sự kiện MenuItem Chức năng 2
        //Phát hiện dòng chảy quang học với thuật toán Horn-Schunck
        private void HornSchunckOperation()
        {
            BasicOperations.AddMultiFrameOperation(2, BasicOperations.OpticalFlow_Horn_Schunk, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) });
        }
        private void ShowHornSchunckOperation()
        {
            BasicOperations.ShowResult(2, BasicOperations.OpticalFlow_Horn_Schunk, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, "Optical Flow with Horn-Schunck");
        }
        private void thuậtTuánHornSchunckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Ngưỡng giới hạn: ", null, null, null, 0, 0, 100);
            AddInteractiveTrackbar("Tham số lambda: ", null, TbValueChangeHarris, ValueChangeHarris, 0, 0, 100);
            AddInteractiveTrackbar("Kích thước mũi tên: ");
            AddIButton("Áp dụng", HornSchunckOperation);
            AddIButton("Hiển thị kết quả", ShowHornSchunckOperation);
            SendSubMessage("Phát hiện dòng chảy quang học trong Video với thuật toán Horn-Schunck");
        }

        //Phát hiện dòng chảy quang học với thuật toán Lucas-Kanade
        private void ShowLucasKanadeOperation()
        {

            BasicOperations.CreateOutput(BasicOperations.GetCurrentFrame());
            BasicOperations.ShowResult(2, BasicOperations.OpticalFlow_LK, new int[] { int.Parse(((InteractiveTrackBar)panel1.Controls[0]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[2]).ValueText), int.Parse(((InteractiveTrackBar)panel1.Controls[3]).ValueText) }, new double[] { double.Parse(((InteractiveTrackBar)panel1.Controls[1]).ValueText) }, "Optical Flow with Lucas-Kanade");
        }
        private void thuậtToánLucasKanadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicOperations.SaveOperation();
            ControlLocation = 0;
            panel1.Controls.Clear();
            AddInteractiveTrackbar("Ngưỡng giới hạn: ", null, null, null, 0, 0, 100);
            AddInteractiveTrackbar("Sai số tối đa: ", null, TbValueChangeHarris, ValueChangeHarris, 0, 0, 100);
            AddInteractiveTrackbar("Kích thước cửa sổ: ", null, TbValueChangeOdd1_25, ValueChangeOdd1_25, 0, 0, 12, 2);
            AddInteractiveTrackbar("Số tầng kim tự tháp: ", null, null, null, 1, 1, 20);
            AddIButton("Hiển thị kết quả", ShowLucasKanadeOperation);
            SendSubMessage("Phát hiện dòng chảy quang học trong Video với thuật toán Lucas-Kanade");
        }


        /*************************************************************************************************************************************************************************************/
        //Các sự kiện khác
        private void progressBar1_MouseClick(object sender, MouseEventArgs e)
        {
            progressBar1.Value = e.X * progressBar1.Maximum / progressBar1.Width;
            if (BasicOperations.SetCurrentFrame(progressBar1.Value))
            {
                BasicOperations.ReadVideo(progressBar1.Value);
                SendMessage("Đã chuyển đến khung hình thứ " + progressBar1.Value.ToString());
            }
        }
    }
}
