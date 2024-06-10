namespace EmguCV_C_
{
    partial class BlackAndWhiteImageProcessing
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            ObjectCount = new Label();
            label4 = new Label();
            label5 = new Label();
            Area = new Label();
            Perimeter = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(521, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 36);
            textBox1.TabIndex = 32;
            textBox1.Text = "127";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.White;
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(215, 0);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(300, 56);
            trackBar1.TabIndex = 31;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(195, 29);
            label1.TabIndex = 30;
            label1.Text = "Ngưỡng đen trắng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 62);
            label2.Name = "label2";
            label2.Size = new Size(135, 29);
            label2.TabIndex = 33;
            label2.Text = "Màu ưu tiên";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Đen", "Trắng" });
            comboBox1.Location = new Point(215, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(300, 37);
            comboBox1.TabIndex = 34;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 124);
            label3.Name = "label3";
            label3.Size = new Size(183, 29);
            label3.TabIndex = 35;
            label3.Text = "Số lượng vật thể ";
            // 
            // ObjectCount
            // 
            ObjectCount.AutoSize = true;
            ObjectCount.Location = new Point(215, 124);
            ObjectCount.Name = "ObjectCount";
            ObjectCount.Size = new Size(0, 29);
            ObjectCount.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 186);
            label4.Name = "label4";
            label4.Size = new Size(105, 29);
            label4.TabIndex = 37;
            label4.Text = "Diện tích";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 248);
            label5.Name = "label5";
            label5.Size = new Size(80, 29);
            label5.TabIndex = 38;
            label5.Text = "Chu vi";
            // 
            // Area
            // 
            Area.AutoSize = true;
            Area.Location = new Point(215, 186);
            Area.Name = "Area";
            Area.Size = new Size(0, 29);
            Area.TabIndex = 39;
            // 
            // Perimeter
            // 
            Perimeter.AutoSize = true;
            Perimeter.Location = new Point(215, 248);
            Perimeter.Name = "Perimeter";
            Perimeter.Size = new Size(0, 29);
            Perimeter.TabIndex = 40;
            // 
            // BlackAndWhiteImageProcessing
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(Perimeter);
            Controls.Add(Area);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ObjectCount);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "BlackAndWhiteImageProcessing";
            Size = new Size(896, 404);
            Load += BlackAndWhiteImageProcessing_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Label ObjectCount;
        private Label label4;
        private Label label5;
        private Label Area;
        private Label Perimeter;
    }
}
