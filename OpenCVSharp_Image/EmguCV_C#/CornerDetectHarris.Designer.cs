namespace EmguCV_C_
{
    partial class CornerDetectHarris
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
            button1 = new Button();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            textBox2 = new TextBox();
            trackBar2 = new TrackBar();
            label2 = new Label();
            textBox3 = new TextBox();
            trackBar3 = new TrackBar();
            label3 = new Label();
            textBox4 = new TextBox();
            trackBar4 = new TrackBar();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(202, 251);
            button1.Name = "button1";
            button1.Size = new Size(200, 35);
            button1.TabIndex = 30;
            button1.Text = "Hiện ảnh góc";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(508, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 36);
            textBox1.TabIndex = 19;
            textBox1.Text = "1";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.White;
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(202, 3);
            trackBar1.Maximum = 20;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(300, 56);
            trackBar1.TabIndex = 18;
            trackBar1.Value = 1;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 29);
            label1.TabIndex = 17;
            label1.Text = "Kích thước khối";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(508, 68);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 36);
            textBox2.TabIndex = 23;
            textBox2.Text = "1";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.White;
            trackBar2.LargeChange = 1;
            trackBar2.Location = new Point(202, 65);
            trackBar2.Maximum = 12;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(300, 56);
            trackBar2.TabIndex = 22;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 65);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(194, 29);
            label2.TabIndex = 21;
            label2.Text = "Kích thước bộ lọc";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(508, 130);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(67, 36);
            textBox3.TabIndex = 26;
            textBox3.Text = "0";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // trackBar3
            // 
            trackBar3.BackColor = Color.White;
            trackBar3.LargeChange = 10;
            trackBar3.Location = new Point(202, 127);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(300, 56);
            trackBar3.TabIndex = 25;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 124);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 29);
            label3.TabIndex = 24;
            label3.Text = "Tham số ";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(508, 192);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(67, 36);
            textBox4.TabIndex = 29;
            textBox4.Text = "100";
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // trackBar4
            // 
            trackBar4.BackColor = Color.White;
            trackBar4.LargeChange = 10;
            trackBar4.Location = new Point(202, 189);
            trackBar4.Maximum = 255;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(300, 56);
            trackBar4.TabIndex = 28;
            trackBar4.Value = 100;
            trackBar4.ValueChanged += trackBar4_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 186);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(127, 29);
            label4.TabIndex = 27;
            label4.Text = "Ngưỡng trễ";
            // 
            // CornerDetectHarris
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox4);
            Controls.Add(trackBar4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(trackBar3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(trackBar2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CornerDetectHarris";
            Size = new Size(590, 297);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TrackBar trackBar1;
        private Label label1;
        private TextBox textBox2;
        private TrackBar trackBar2;
        private Label label2;
        private TextBox textBox3;
        private TrackBar trackBar3;
        private Label label3;
        private TextBox textBox4;
        private TrackBar trackBar4;
        private Label label4;
    }
}
