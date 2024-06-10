namespace OpenCVSharp_Video
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            thaoTácCơBảnToolStripMenuItem = new ToolStripMenuItem();
            mởVideoToolStripMenuItem = new ToolStripMenuItem();
            quayLạiVideoGốcToolStripMenuItem = new ToolStripMenuItem();
            lưuVideoToolStripMenuItem = new ToolStripMenuItem();
            đóngVideoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            thayĐổiĐộSángToolStripMenuItem = new ToolStripMenuItem();
            thayĐổiĐộTươngPhảnToolStripMenuItem = new ToolStripMenuItem();
            cânBằngHistogramToolStripMenuItem = new ToolStripMenuItem();
            làmMờToolStripMenuItem = new ToolStripMenuItem();
            làmXóiMònLàmGiãnToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnMàuSắcToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnCạnhVớiCannyToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            lưuThaoTácToolStripMenuItem = new ToolStripMenuItem();
            xóaThaoTácVừaThựcHiệnToolStripMenuItem = new ToolStripMenuItem();
            phátVideoToolStripMenuItem = new ToolStripMenuItem();
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem = new ToolStripMenuItem();
            cácThayĐổiHiệnTạiToolStripMenuItem = new ToolStripMenuItem();
            chọnChứcNăngToolStripMenuItem = new ToolStripMenuItem();
            chứcNăng1ToolStripMenuItem1 = new ToolStripMenuItem();
            chứcNăng1ToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnCạnhVớiLoGToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnCạnhVớiDoGToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnGócVớiHarrisToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnGócVớiShiTomasiToolStripMenuItem = new ToolStripMenuItem();
            phátHiệnGócVớiFASTToolStripMenuItem = new ToolStripMenuItem();
            chứcNăng2ToolStripMenuItem = new ToolStripMenuItem();
            thuậtTuánHornSchunckToolStripMenuItem = new ToolStripMenuItem();
            thuậtToánLucasKanadeToolStripMenuItem = new ToolStripMenuItem();
            càiĐặtToolStripMenuItem = new ToolStripMenuItem();
            tắtThôngBáoToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            Message = new Label();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            splitContainer1 = new SplitContainer();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { thaoTácCơBảnToolStripMenuItem, chọnChứcNăngToolStripMenuItem, chứcNăng1ToolStripMenuItem, chứcNăng2ToolStripMenuItem, càiĐặtToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1400, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // thaoTácCơBảnToolStripMenuItem
            // 
            thaoTácCơBảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mởVideoToolStripMenuItem, quayLạiVideoGốcToolStripMenuItem, lưuVideoToolStripMenuItem, đóngVideoToolStripMenuItem, toolStripSeparator1, thayĐổiĐộSángToolStripMenuItem, thayĐổiĐộTươngPhảnToolStripMenuItem, cânBằngHistogramToolStripMenuItem, làmMờToolStripMenuItem, làmXóiMònLàmGiãnToolStripMenuItem, phátHiệnMàuSắcToolStripMenuItem, phátHiệnCạnhVớiCannyToolStripMenuItem, toolStripSeparator2, lưuThaoTácToolStripMenuItem, xóaThaoTácVừaThựcHiệnToolStripMenuItem, phátVideoToolStripMenuItem, lưuKhungHìnhĐangHiểnThịToolStripMenuItem, cácThayĐổiHiệnTạiToolStripMenuItem });
            thaoTácCơBảnToolStripMenuItem.Name = "thaoTácCơBảnToolStripMenuItem";
            thaoTácCơBảnToolStripMenuItem.Size = new Size(150, 26);
            thaoTácCơBảnToolStripMenuItem.Text = "Thao tác cơ bản";
            // 
            // mởVideoToolStripMenuItem
            // 
            mởVideoToolStripMenuItem.Name = "mởVideoToolStripMenuItem";
            mởVideoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            mởVideoToolStripMenuItem.Size = new Size(375, 26);
            mởVideoToolStripMenuItem.Text = "Mở Video";
            mởVideoToolStripMenuItem.Click += mởVideoToolStripMenuItem_Click;
            // 
            // quayLạiVideoGốcToolStripMenuItem
            // 
            quayLạiVideoGốcToolStripMenuItem.Enabled = false;
            quayLạiVideoGốcToolStripMenuItem.Name = "quayLạiVideoGốcToolStripMenuItem";
            quayLạiVideoGốcToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            quayLạiVideoGốcToolStripMenuItem.Size = new Size(375, 26);
            quayLạiVideoGốcToolStripMenuItem.Text = "Quay lại Video gốc";
            quayLạiVideoGốcToolStripMenuItem.Click += quayLạiVideoGốcToolStripMenuItem_Click;
            // 
            // lưuVideoToolStripMenuItem
            // 
            lưuVideoToolStripMenuItem.Enabled = false;
            lưuVideoToolStripMenuItem.Name = "lưuVideoToolStripMenuItem";
            lưuVideoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            lưuVideoToolStripMenuItem.Size = new Size(375, 26);
            lưuVideoToolStripMenuItem.Text = "Lưu Video";
            lưuVideoToolStripMenuItem.Click += lưuVideoToolStripMenuItem_Click;
            // 
            // đóngVideoToolStripMenuItem
            // 
            đóngVideoToolStripMenuItem.Enabled = false;
            đóngVideoToolStripMenuItem.Name = "đóngVideoToolStripMenuItem";
            đóngVideoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            đóngVideoToolStripMenuItem.Size = new Size(375, 26);
            đóngVideoToolStripMenuItem.Text = "Đóng Video";
            đóngVideoToolStripMenuItem.Click += đóngVideoToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(372, 6);
            // 
            // thayĐổiĐộSángToolStripMenuItem
            // 
            thayĐổiĐộSángToolStripMenuItem.Enabled = false;
            thayĐổiĐộSángToolStripMenuItem.Name = "thayĐổiĐộSángToolStripMenuItem";
            thayĐổiĐộSángToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.B;
            thayĐổiĐộSángToolStripMenuItem.Size = new Size(375, 26);
            thayĐổiĐộSángToolStripMenuItem.Text = "Thay đổi độ sáng";
            thayĐổiĐộSángToolStripMenuItem.Click += thayĐổiĐộSángToolStripMenuItem_Click;
            // 
            // thayĐổiĐộTươngPhảnToolStripMenuItem
            // 
            thayĐổiĐộTươngPhảnToolStripMenuItem.Enabled = false;
            thayĐổiĐộTươngPhảnToolStripMenuItem.Name = "thayĐổiĐộTươngPhảnToolStripMenuItem";
            thayĐổiĐộTươngPhảnToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.C;
            thayĐổiĐộTươngPhảnToolStripMenuItem.Size = new Size(375, 26);
            thayĐổiĐộTươngPhảnToolStripMenuItem.Text = "Thay đổi độ tương phản";
            thayĐổiĐộTươngPhảnToolStripMenuItem.Click += thayĐổiĐộTươngPhảnToolStripMenuItem_Click;
            // 
            // cânBằngHistogramToolStripMenuItem
            // 
            cânBằngHistogramToolStripMenuItem.Enabled = false;
            cânBằngHistogramToolStripMenuItem.Name = "cânBằngHistogramToolStripMenuItem";
            cânBằngHistogramToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.H;
            cânBằngHistogramToolStripMenuItem.Size = new Size(375, 26);
            cânBằngHistogramToolStripMenuItem.Text = "Cân bằng Histogram";
            cânBằngHistogramToolStripMenuItem.Click += cânBằngHistogramToolStripMenuItem_Click;
            // 
            // làmMờToolStripMenuItem
            // 
            làmMờToolStripMenuItem.Enabled = false;
            làmMờToolStripMenuItem.Name = "làmMờToolStripMenuItem";
            làmMờToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            làmMờToolStripMenuItem.Size = new Size(375, 26);
            làmMờToolStripMenuItem.Text = "Làm mờ";
            làmMờToolStripMenuItem.Click += làmMờToolStripMenuItem_Click;
            // 
            // làmXóiMònLàmGiãnToolStripMenuItem
            // 
            làmXóiMònLàmGiãnToolStripMenuItem.Enabled = false;
            làmXóiMònLàmGiãnToolStripMenuItem.Name = "làmXóiMònLàmGiãnToolStripMenuItem";
            làmXóiMònLàmGiãnToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            làmXóiMònLàmGiãnToolStripMenuItem.Size = new Size(375, 26);
            làmXóiMònLàmGiãnToolStripMenuItem.Text = "Làm xói mòn, làm giãn";
            làmXóiMònLàmGiãnToolStripMenuItem.Click += làmXóiMònLàmGiãnToolStripMenuItem_Click;
            // 
            // phátHiệnMàuSắcToolStripMenuItem
            // 
            phátHiệnMàuSắcToolStripMenuItem.Enabled = false;
            phátHiệnMàuSắcToolStripMenuItem.Name = "phátHiệnMàuSắcToolStripMenuItem";
            phátHiệnMàuSắcToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            phátHiệnMàuSắcToolStripMenuItem.Size = new Size(375, 26);
            phátHiệnMàuSắcToolStripMenuItem.Text = "Phát hiện màu sắc";
            phátHiệnMàuSắcToolStripMenuItem.Click += phátHiệnMàuSắcToolStripMenuItem_Click;
            // 
            // phátHiệnCạnhVớiCannyToolStripMenuItem
            // 
            phátHiệnCạnhVớiCannyToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiCannyToolStripMenuItem.Name = "phátHiệnCạnhVớiCannyToolStripMenuItem";
            phátHiệnCạnhVớiCannyToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            phátHiệnCạnhVớiCannyToolStripMenuItem.Size = new Size(375, 26);
            phátHiệnCạnhVớiCannyToolStripMenuItem.Text = "Phát hiện cạnh với Canny";
            phátHiệnCạnhVớiCannyToolStripMenuItem.Click += phátHiệnCạnhVớiCannyToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(372, 6);
            // 
            // lưuThaoTácToolStripMenuItem
            // 
            lưuThaoTácToolStripMenuItem.Enabled = false;
            lưuThaoTácToolStripMenuItem.Name = "lưuThaoTácToolStripMenuItem";
            lưuThaoTácToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D1;
            lưuThaoTácToolStripMenuItem.Size = new Size(375, 26);
            lưuThaoTácToolStripMenuItem.Text = "Lưu thao tác";
            // 
            // xóaThaoTácVừaThựcHiệnToolStripMenuItem
            // 
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Enabled = false;
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Name = "xóaThaoTácVừaThựcHiệnToolStripMenuItem";
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Size = new Size(375, 26);
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Text = "Xóa thao tác vừa thực hiện";
            xóaThaoTácVừaThựcHiệnToolStripMenuItem.Click += xóaThaoTácVừaThựcHiệnToolStripMenuItem_Click;
            // 
            // phátVideoToolStripMenuItem
            // 
            phátVideoToolStripMenuItem.Enabled = false;
            phátVideoToolStripMenuItem.Name = "phátVideoToolStripMenuItem";
            phátVideoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            phátVideoToolStripMenuItem.Size = new Size(375, 26);
            phátVideoToolStripMenuItem.Text = "Phát Video";
            phátVideoToolStripMenuItem.Click += phátVideoToolStripMenuItem_Click;
            // 
            // lưuKhungHìnhĐangHiểnThịToolStripMenuItem
            // 
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Enabled = false;
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Name = "lưuKhungHìnhĐangHiểnThịToolStripMenuItem";
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Size = new Size(375, 26);
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Text = "Lưu khung hình đang hiển thị";
            lưuKhungHìnhĐangHiểnThịToolStripMenuItem.Click += lưuKhungHìnhĐangHiểnThịToolStripMenuItem_Click;
            // 
            // cácThayĐổiHiệnTạiToolStripMenuItem
            // 
            cácThayĐổiHiệnTạiToolStripMenuItem.Enabled = false;
            cácThayĐổiHiệnTạiToolStripMenuItem.Name = "cácThayĐổiHiệnTạiToolStripMenuItem";
            cácThayĐổiHiệnTạiToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            cácThayĐổiHiệnTạiToolStripMenuItem.Size = new Size(375, 26);
            cácThayĐổiHiệnTạiToolStripMenuItem.Text = "Các thay đổi hiện tại ";
            cácThayĐổiHiệnTạiToolStripMenuItem.Click += cácThayĐổiHiệnTạiToolStripMenuItem_Click;
            // 
            // chọnChứcNăngToolStripMenuItem
            // 
            chọnChứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chứcNăng1ToolStripMenuItem1 });
            chọnChứcNăngToolStripMenuItem.Enabled = false;
            chọnChứcNăngToolStripMenuItem.Name = "chọnChứcNăngToolStripMenuItem";
            chọnChứcNăngToolStripMenuItem.Size = new Size(149, 26);
            chọnChứcNăngToolStripMenuItem.Text = "Chọn chức năng";
            // 
            // chứcNăng1ToolStripMenuItem1
            // 
            chứcNăng1ToolStripMenuItem1.Enabled = false;
            chứcNăng1ToolStripMenuItem1.Name = "chứcNăng1ToolStripMenuItem1";
            chứcNăng1ToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.D1;
            chứcNăng1ToolStripMenuItem1.Size = new Size(254, 26);
            chứcNăng1ToolStripMenuItem1.Text = "Chức năng 1";
            chứcNăng1ToolStripMenuItem1.Click += chứcNăng1ToolStripMenuItem1_Click;
            // 
            // chứcNăng1ToolStripMenuItem
            // 
            chứcNăng1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { phátHiệnCạnhVớiLoGToolStripMenuItem, phátHiệnCạnhVớiDoGToolStripMenuItem, phátHiệnGócVớiHarrisToolStripMenuItem, phátHiệnGócVớiShiTomasiToolStripMenuItem, phátHiệnGócVớiFASTToolStripMenuItem });
            chứcNăng1ToolStripMenuItem.Enabled = false;
            chứcNăng1ToolStripMenuItem.Name = "chứcNăng1ToolStripMenuItem";
            chứcNăng1ToolStripMenuItem.ShortcutKeys = Keys.F1;
            chứcNăng1ToolStripMenuItem.Size = new Size(239, 26);
            chứcNăng1ToolStripMenuItem.Text = "Chức năng 1: Tìm góc cạnh";
            // 
            // phátHiệnCạnhVớiLoGToolStripMenuItem
            // 
            phátHiệnCạnhVớiLoGToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiLoGToolStripMenuItem.Name = "phátHiệnCạnhVớiLoGToolStripMenuItem";
            phátHiệnCạnhVớiLoGToolStripMenuItem.ShortcutKeys = Keys.F1;
            phátHiệnCạnhVớiLoGToolStripMenuItem.Size = new Size(358, 26);
            phátHiệnCạnhVớiLoGToolStripMenuItem.Text = "Phát hiện cạnh với LoG";
            phátHiệnCạnhVớiLoGToolStripMenuItem.Click += phátHiệnCạnhVớiLoGToolStripMenuItem_Click;
            // 
            // phátHiệnCạnhVớiDoGToolStripMenuItem
            // 
            phátHiệnCạnhVớiDoGToolStripMenuItem.Enabled = false;
            phátHiệnCạnhVớiDoGToolStripMenuItem.Name = "phátHiệnCạnhVớiDoGToolStripMenuItem";
            phátHiệnCạnhVớiDoGToolStripMenuItem.ShortcutKeys = Keys.F2;
            phátHiệnCạnhVớiDoGToolStripMenuItem.Size = new Size(358, 26);
            phátHiệnCạnhVớiDoGToolStripMenuItem.Text = "Phát hiện cạnh với DoG";
            phátHiệnCạnhVớiDoGToolStripMenuItem.Click += phátHiệnCạnhVớiDoGToolStripMenuItem_Click;
            // 
            // phátHiệnGócVớiHarrisToolStripMenuItem
            // 
            phátHiệnGócVớiHarrisToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiHarrisToolStripMenuItem.Name = "phátHiệnGócVớiHarrisToolStripMenuItem";
            phátHiệnGócVớiHarrisToolStripMenuItem.ShortcutKeys = Keys.F3;
            phátHiệnGócVớiHarrisToolStripMenuItem.Size = new Size(358, 26);
            phátHiệnGócVớiHarrisToolStripMenuItem.Text = "Phát hiện góc với Harris";
            phátHiệnGócVớiHarrisToolStripMenuItem.Click += phátHiệnGócVớiHarrisToolStripMenuItem_Click;
            // 
            // phátHiệnGócVớiShiTomasiToolStripMenuItem
            // 
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Name = "phátHiệnGócVớiShiTomasiToolStripMenuItem";
            phátHiệnGócVớiShiTomasiToolStripMenuItem.ShortcutKeys = Keys.F4;
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Size = new Size(358, 26);
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Text = "Phát hiện góc với Shi-Tomasi";
            phátHiệnGócVớiShiTomasiToolStripMenuItem.Click += phátHiệnGócVớiShiTomasiToolStripMenuItem_Click;
            // 
            // phátHiệnGócVớiFASTToolStripMenuItem
            // 
            phátHiệnGócVớiFASTToolStripMenuItem.Enabled = false;
            phátHiệnGócVớiFASTToolStripMenuItem.Name = "phátHiệnGócVớiFASTToolStripMenuItem";
            phátHiệnGócVớiFASTToolStripMenuItem.ShortcutKeys = Keys.F5;
            phátHiệnGócVớiFASTToolStripMenuItem.Size = new Size(358, 26);
            phátHiệnGócVớiFASTToolStripMenuItem.Text = "Phát hiện góc với FAST";
            phátHiệnGócVớiFASTToolStripMenuItem.Click += phátHiệnGócVớiFASTToolStripMenuItem_Click;
            // 
            // chứcNăng2ToolStripMenuItem
            // 
            chứcNăng2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thuậtTuánHornSchunckToolStripMenuItem, thuậtToánLucasKanadeToolStripMenuItem });
            chứcNăng2ToolStripMenuItem.Name = "chứcNăng2ToolStripMenuItem";
            chứcNăng2ToolStripMenuItem.Size = new Size(297, 26);
            chứcNăng2ToolStripMenuItem.Text = "Chức năng 2: Tìm luồng quang học";
            // 
            // thuậtTuánHornSchunckToolStripMenuItem
            // 
            thuậtTuánHornSchunckToolStripMenuItem.Name = "thuậtTuánHornSchunckToolStripMenuItem";
            thuậtTuánHornSchunckToolStripMenuItem.Size = new Size(294, 26);
            thuậtTuánHornSchunckToolStripMenuItem.Text = "Thuật tóan Horn-Schunck";
            thuậtTuánHornSchunckToolStripMenuItem.Click += thuậtTuánHornSchunckToolStripMenuItem_Click;
            // 
            // thuậtToánLucasKanadeToolStripMenuItem
            // 
            thuậtToánLucasKanadeToolStripMenuItem.Name = "thuậtToánLucasKanadeToolStripMenuItem";
            thuậtToánLucasKanadeToolStripMenuItem.Size = new Size(294, 26);
            thuậtToánLucasKanadeToolStripMenuItem.Text = "Thuật toán Lucas-Kanade";
            thuậtToánLucasKanadeToolStripMenuItem.Click += thuậtToánLucasKanadeToolStripMenuItem_Click;
            // 
            // càiĐặtToolStripMenuItem
            // 
            càiĐặtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tắtThôngBáoToolStripMenuItem });
            càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
            càiĐặtToolStripMenuItem.Size = new Size(81, 26);
            càiĐặtToolStripMenuItem.Text = "Cài đặt";
            // 
            // tắtThôngBáoToolStripMenuItem
            // 
            tắtThôngBáoToolStripMenuItem.Name = "tắtThôngBáoToolStripMenuItem";
            tắtThôngBáoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            tắtThôngBáoToolStripMenuItem.Size = new Size(267, 26);
            tắtThôngBáoToolStripMenuItem.Text = "Tắt thông báo";
            tắtThôngBáoToolStripMenuItem.Click += tắtThôngBáoToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(466, 455);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(Message);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 455);
            panel2.Name = "panel2";
            panel2.Size = new Size(466, 167);
            panel2.TabIndex = 2;
            // 
            // Message
            // 
            Message.Dock = DockStyle.Fill;
            Message.Location = new Point(0, 0);
            Message.Name = "Message";
            Message.Size = new Size(462, 163);
            Message.TabIndex = 0;
            Message.Text = "Thông báo:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(progressBar1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(930, 622);
            panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(926, 589);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 589);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(926, 29);
            progressBar1.TabIndex = 1;
            progressBar1.MouseClick += progressBar1_MouseClick;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 30);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Size = new Size(1400, 622);
            splitContainer1.SplitterDistance = 466;
            splitContainer1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 652);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "OpenCV Stimulation Video";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem thaoTácCơBảnToolStripMenuItem;
        private ToolStripMenuItem mởVideoToolStripMenuItem;
        private ToolStripMenuItem quayLạiVideoGốcToolStripMenuItem;
        private ToolStripMenuItem lưuVideoToolStripMenuItem;
        private ToolStripMenuItem đóngVideoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem thayĐổiĐộSángToolStripMenuItem;
        private ToolStripMenuItem thayĐổiĐộTươngPhảnToolStripMenuItem;
        private ToolStripMenuItem cânBằngHistogramToolStripMenuItem;
        private ToolStripMenuItem làmMờToolStripMenuItem;
        private ToolStripMenuItem làmXóiMònLàmGiãnToolStripMenuItem;
        private ToolStripMenuItem phátHiệnMàuSắcToolStripMenuItem;
        private ToolStripMenuItem phátHiệnCạnhVớiCannyToolStripMenuItem;
        private ToolStripMenuItem chọnChứcNăngToolStripMenuItem;
        private ToolStripMenuItem chứcNăng1ToolStripMenuItem1;
        private ToolStripMenuItem chứcNăng1ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem phátVideoToolStripMenuItem;
        private ToolStripMenuItem cácThayĐổiHiệnTạiToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label Message;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private ToolStripMenuItem phátHiệnCạnhVớiLoGToolStripMenuItem;
        private ToolStripMenuItem phátHiệnCạnhVớiDoGToolStripMenuItem;
        private ToolStripMenuItem phátHiệnGócVớiHarrisToolStripMenuItem;
        private ToolStripMenuItem phátHiệnGócVớiShiTomasiToolStripMenuItem;
        private ToolStripMenuItem phátHiệnGócVớiFASTToolStripMenuItem;
        private ToolStripMenuItem lưuKhungHìnhĐangHiểnThịToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem xóaThaoTácVừaThựcHiệnToolStripMenuItem;
        private ToolStripMenuItem lưuThaoTácToolStripMenuItem;
        private ToolStripMenuItem chứcNăng2ToolStripMenuItem;
        private ToolStripMenuItem thuậtTuánHornSchunckToolStripMenuItem;
        private ToolStripMenuItem thuậtToánLucasKanadeToolStripMenuItem;
        private ToolStripMenuItem càiĐặtToolStripMenuItem;
        private ToolStripMenuItem tắtThôngBáoToolStripMenuItem;
    }
}
