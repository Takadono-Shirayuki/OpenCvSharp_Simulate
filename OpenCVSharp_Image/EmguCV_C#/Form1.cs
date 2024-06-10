using System.Diagnostics;
using System.Security.Cryptography;

namespace EmguCV_C_
{

    public partial class Form1 : Form
    {
        BasicOperations BasicOperations = new BasicOperations();
        delegate void mouseMoveEvent(int[] PixelLocation);
        delegate void mouseClickEvent();

        mouseMoveEvent MME;
        mouseClickEvent MCE;
        Boolean AllowMME = false;
        Boolean AllowMCE = false;
        Boolean Hold = false;
        mouseMoveEvent MouseMoveEvent
        {
            set
            {
                MME = value;
                AllowMME = true;
                Hold = false;
            }
            get
            {
                return MME;
            }
        }

        mouseClickEvent MouseClickEvent
        {
            set
            {
                MCE = value;
                AllowMCE = true;
            }
            get
            {
                return MCE;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BasicOperations.UsingPictureBox = pictureBox1;
        }

        // Hiển thị thông báo
        private void SendMessage(string message)
        {
            Message.Text = message;
            if (!tắtThôngBáoToolStripMenuItem.Checked)
                MessageBox.Show(message);
        }

        // Các sự kiện cho pictureBox
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        public int[] GetPixel(int x, int y)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Normal)
                return [x, y];
            if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                return [x * pictureBox1.Image.Width / pictureBox1.Width, y * pictureBox1.Image.Height / pictureBox1.Height];
            }
            if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                return [x - (pictureBox1.Width - pictureBox1.Image.Width) / 2, y - (pictureBox1.Height - pictureBox1.Image.Height) / 2];
            }
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                float scale = Math.Max((float)pictureBox1.Image.Width / pictureBox1.Width, (float)pictureBox1.Image.Height / pictureBox1.Height);
                return [pictureBox1.Image.Width / 2 - (int)((pictureBox1.Width / 2 - x) * scale), pictureBox1.Image.Height / 2 - (int)((pictureBox1.Height / 2 - y) * scale)];
            }
            return [];
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowMME && !Hold)
            {
                int[] PixelLocation = GetPixel(e.X, e.Y);
                if (PixelLocation[0] < 0 || PixelLocation[0] >= pictureBox1.Image.Width || PixelLocation[1] < 0 || PixelLocation[1] >= pictureBox1.Image.Height)
                    return;
                if (PixelLocation[1] < 0 || PixelLocation[1] >= pictureBox1.Image.Height)
                    return;
                MouseMoveEvent(PixelLocation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hold = !Hold;
            if (AllowMCE)
                MouseClickEvent();
        }

        //
        private void SetFunction(int F)
        {
            chứcNăng1ToolStripMenuItem.Enabled = false;
            hiệnHistogramToolStripMenuItem.Enabled = false;
            thôngTinPixelToolStripMenuItem.Enabled = false;
            thôngTinCửaSổToolStripMenuItem.Enabled = false;
            biếnĐổiFourierToolStripMenuItem.Enabled = false;

            chứcNăng2ToolStripMenuItem.Enabled = false;
            hiệnViềnBằngLoGToolStripMenuItem.Enabled = false;
            hiệnViềnBằngDoGToolStripMenuItem.Enabled = false;
            hiệnGócBằngHarrisToolStripMenuItem.Enabled = false;
            hiệnGócBằngFASTToolStripMenuItem.Enabled = false;
            hiệnCạnhBằngSobelToolStripMenuItem.Enabled = false;

            chứcNăng3ToolStripMenuItem.Enabled = false;
            tìmBiênCủaVậtThểToolStripMenuItem.Enabled = false;
            biếnĐổiHoughTiêuChuẩnToolStripMenuItem.Enabled = false;
            biếnĐổiHoughXácSuấtToolStripMenuItem.Enabled = false;
            biếnĐổiHoughChoĐườngTrònToolStripMenuItem.Enabled = false;
            chuyểnSangMiềnĐenTrắngToolStripMenuItem.Enabled = false;
            maTrậnĐồngXuấtHiệnToolStripMenuItem.Enabled = false;
            xoayHìnhẢnhTheoĐườngBiếnĐổiHoughToolStripMenuItem.Enabled = false;
            switch (F)
            {
                case 1:
                    chứcNăng1ToolStripMenuItem.Enabled = true;
                    hiệnHistogramToolStripMenuItem.Enabled = true;
                    thôngTinPixelToolStripMenuItem.Enabled = true;
                    thôngTinCửaSổToolStripMenuItem.Enabled = true;
                    biếnĐổiFourierToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    chứcNăng2ToolStripMenuItem.Enabled = true;
                    hiệnViềnBằngLoGToolStripMenuItem.Enabled = true;
                    hiệnViềnBằngDoGToolStripMenuItem.Enabled = true;
                    hiệnGócBằngHarrisToolStripMenuItem.Enabled = true;
                    hiệnGócBằngFASTToolStripMenuItem.Enabled = true;
                    hiệnCạnhBằngSobelToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    chứcNăng3ToolStripMenuItem.Enabled = true;
                    tìmBiênCủaVậtThểToolStripMenuItem.Enabled = true;
                    biếnĐổiHoughTiêuChuẩnToolStripMenuItem.Enabled = true;
                    biếnĐổiHoughXácSuấtToolStripMenuItem.Enabled = true;
                    biếnĐổiHoughChoĐườngTrònToolStripMenuItem.Enabled = true;
                    chuyểnSangMiềnĐenTrắngToolStripMenuItem.Enabled = true;
                    maTrậnĐồngXuấtHiệnToolStripMenuItem.Enabled = true;
                    xoayHìnhẢnhTheoĐườngBiếnĐổiHoughToolStripMenuItem.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        //Các sự kiện cho các menu item trong menu strip
        //MenuItem Thao tác cơ bản
        private void mởẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string message = BasicOperations.LoadImage(path);
                SendMessage(BasicOperations.LoadImage(path));
                if (message == "Mở File thành công")
                {
                    BasicOperations.FFT = false;
                    AllowMME = false;
                    AllowMCE = false;
                    splitContainer2.Panel1.Controls.Clear();

                    quayLạiẢnhGốcToolStripMenuItem.Enabled = true;
                    quayLạiẢnhTạmThờiToolStripMenuItem.Enabled = true;
                    lưuẢnhToolStripMenuItem.Enabled = true;
                    đóngẢnhToolStripMenuItem.Enabled = true;

                    thayĐổiĐộSángToolStripMenuItem.Enabled = true;
                    thayĐổiĐộTươngPhảnToolStripMenuItem.Enabled = true;
                    cânBằngHistogramToolStripMenuItem.Enabled = true;
                    làmMờToolStripMenuItem.Enabled = true;
                    âmBảnToolStripMenuItem.Enabled = true;
                    làmXóiMònẢnhToolStripMenuItem.Enabled = true;
                    xoayẢnhToolStripMenuItem.Enabled = true;
                    phátHiệnMàuSắcToolStripMenuItem.Enabled = true;
                    phátHiệnBiênToolStripMenuItem.Enabled = true;

                    chọnChứcNăngToolStripMenuItem.Enabled = true;
                    chứcNăng1ToolStripMenuItem1.Enabled = true;
                    chứcNăng2ToolStripMenuItem1.Enabled = true;
                    chứcNăng3ToolStripMenuItem1.Enabled = true;
                }
            }
        }

        private void lưuẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                pictureBox1.Image.Save(path);
                SendMessage("Lưu ảnh thành công");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            splitContainer2.Panel1.Controls.Clear();

            pictureBox1.Image = null;
            quayLạiẢnhGốcToolStripMenuItem.Enabled = false;
            quayLạiẢnhTạmThờiToolStripMenuItem.Enabled = false;
            lưuẢnhToolStripMenuItem.Enabled = false;
            đóngẢnhToolStripMenuItem.Enabled = false;

            thayĐổiĐộSángToolStripMenuItem.Enabled = false;
            thayĐổiĐộTươngPhảnToolStripMenuItem.Enabled = false;
            cânBằngHistogramToolStripMenuItem.Enabled = false;
            làmMờToolStripMenuItem.Enabled = false;
            âmBảnToolStripMenuItem.Enabled = false;
            làmXóiMònẢnhToolStripMenuItem.Enabled = false;
            xoayẢnhToolStripMenuItem.Enabled = false;
            phátHiệnMàuSắcToolStripMenuItem.Enabled = false;
            phátHiệnBiênToolStripMenuItem.Enabled = false;

            chọnChứcNăngToolStripMenuItem.Enabled = false;
            chứcNăng1ToolStripMenuItem1.Enabled = false;
            chứcNăng2ToolStripMenuItem1.Enabled = false;
            chứcNăng3ToolStripMenuItem1.Enabled = false;
            SetFunction(0);
        }

        private void quayLạiẢnhGốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            splitContainer2.Panel1.Controls.Clear();
            BasicOperations.ResetImage();
        }

        private void quayLạiẢnhTạmThờiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            splitContainer2.Panel1.Controls.Clear();
            BasicOperations.ResetToTempImage();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            normalToolStripMenuItem.Checked = true;
            zoomToolStripMenuItem.Checked = false;
            stretchImageToolStripMenuItem.Checked = false;
            centerImageToolStripMenuItem.Checked = false;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            normalToolStripMenuItem.Checked = false;
            zoomToolStripMenuItem.Checked = false;
            stretchImageToolStripMenuItem.Checked = true;
            centerImageToolStripMenuItem.Checked = false;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            normalToolStripMenuItem.Checked = false;
            zoomToolStripMenuItem.Checked = false;
            stretchImageToolStripMenuItem.Checked = false;
            centerImageToolStripMenuItem.Checked = true;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            normalToolStripMenuItem.Checked = false;
            zoomToolStripMenuItem.Checked = true;
            stretchImageToolStripMenuItem.Checked = false;
            centerImageToolStripMenuItem.Checked = false;
        }

        private void thayĐổiĐộSángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new ChangeBrightness(BasicOperations));
        }

        private void thayĐổiĐộTươngPhảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new ChangeContrast(BasicOperations));
        }

        private void cânBằngHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            BasicOperations.HistogramEqualization();
        }

        private void làmMờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new Blur(BasicOperations));
        }

        private void âmBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            BasicOperations.NegativeImage();
        }

        private void làmXóiMònẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new ErodeAndDilate(BasicOperations));
        }

        private void xoayẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new RotateImage(BasicOperations));
        }

        private void phátHiệnMàuSắcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new ColorDetection(BasicOperations));
        }

        private void phátHiệnBiênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new EdgeDetection(BasicOperations));
        }

        //MenuItem Chức năng
        private void chứcNăng1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFunction(1);
        }

        private void chứcNăng2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetFunction(2);
        }

        private void chứcNăng3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetFunction(3);
        }
        //MenuItem Cài đặt
        private void tắtThôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tắtThôngBáoToolStripMenuItem.Checked = !tắtThôngBáoToolStripMenuItem.Checked;
        }

        //MenuItem Chức năng 1
        private void hiệnHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Histogram histogram = new Histogram(BasicOperations.Histogram());
            histogram.Show();
        }

        private void thôngTinPixelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = true;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            PixelInformation pixelInformation = new PixelInformation(BasicOperations.GetShowingImage());
            MouseMoveEvent = pixelInformation.MME;
            splitContainer2.Panel1.Controls.Add(pixelInformation);
        }

        private void thôngTinCửaSổToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = true;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            WindowInformation windowInformation = new WindowInformation(BasicOperations.GetShowingImage());
            MouseMoveEvent = windowInformation.MME;
            splitContainer2.Panel1.Controls.Add(windowInformation);
        }

        private void biếnĐổiFourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            BasicOperations.FourierTransform();
        }

        //MenuItem Chức năng 2
        private void hiệnViềnBằngLoGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new EdgeDetectionLoG(BasicOperations));
        }

        private void hiệnViềnBằngDoGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new EdgeDetectionDoG(BasicOperations));
        }

        private void hiệnGócBằngHarrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new CornerDetectHarris(BasicOperations));
        }

        private void hiệnGócBằngFASTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new CornerDetectFAST(BasicOperations));
        }

        //MenuItem Chức năng 3
        private void tìmBiênCủaVậtThểToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new BorderTracing(BasicOperations));
        }

        private void biếnĐổiHoughTiêuChuẩnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new StandardHoughLineTransform(BasicOperations));
        }

        private void biếnĐổiHoughXácSuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new ProbabilisticHoughLineTransform(BasicOperations));
        }

        private void biếnĐổiHoughChoĐườngTrònToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new HoughCircleTransform(BasicOperations));
        }

        private void chuyểnSangMiềnĐenTrắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = true;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            BlackAndWhiteImageProcessing blackAndWhiteImageProcessing = new BlackAndWhiteImageProcessing(BasicOperations);
            MouseMoveEvent = blackAndWhiteImageProcessing.MME;
            splitContainer2.Panel1.Controls.Add(blackAndWhiteImageProcessing);
        }

        private void maTrậnĐồngXuấtHiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Co_occurrenceMatrices co_OccurrenceMatrices = new Co_occurrenceMatrices(BasicOperations);
            co_OccurrenceMatrices.Show();
        }

        private void xoayHìnhẢnhTheoĐườngBiếnĐổiHoughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = true;
            AllowMCE = true;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            RotateImageUseHoughLine rotateImageUseHoughLine = new RotateImageUseHoughLine(BasicOperations.GetShowingImage(), pictureBox1);
            MouseMoveEvent = rotateImageUseHoughLine.MME;
            MouseClickEvent = rotateImageUseHoughLine.MCE;
            splitContainer2.Panel1.Controls.Add(rotateImageUseHoughLine);
        }

        private void hiệnCạnhBằngSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowMME = false;
            AllowMCE = false;
            BasicOperations.SaveTempImage();
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(new EdgeDetectionSobel(BasicOperations));
        }
    }
}
