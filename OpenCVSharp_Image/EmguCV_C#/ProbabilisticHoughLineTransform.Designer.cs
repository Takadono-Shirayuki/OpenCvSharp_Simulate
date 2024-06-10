namespace EmguCV_C_
{
    partial class ProbabilisticHoughLineTransform
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
            textBox2 = new TextBox();
            trackBar2 = new TrackBar();
            label2 = new Label();
            textBox3 = new TextBox();
            trackBar3 = new TrackBar();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(521, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 36);
            textBox1.TabIndex = 19;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.White;
            trackBar1.LargeChange = 100;
            trackBar1.Location = new Point(215, 0);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(300, 56);
            trackBar1.TabIndex = 18;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 29);
            label1.TabIndex = 17;
            label1.Text = "Ngưỡng trễ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(521, 65);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 36);
            textBox2.TabIndex = 22;
            textBox2.Text = "0";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.White;
            trackBar2.LargeChange = 100;
            trackBar2.Location = new Point(215, 62);
            trackBar2.Maximum = 1000;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(300, 56);
            trackBar2.TabIndex = 21;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 62);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(184, 29);
            label2.TabIndex = 20;
            label2.Text = "Số điểm tối thiểu";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(521, 127);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(67, 36);
            textBox3.TabIndex = 25;
            textBox3.Text = "0";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // trackBar3
            // 
            trackBar3.BackColor = Color.White;
            trackBar3.LargeChange = 10;
            trackBar3.Location = new Point(215, 124);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(300, 56);
            trackBar3.TabIndex = 24;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 124);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(207, 29);
            label3.TabIndex = 23;
            label3.Text = "Khoảng cách tối đa";
            // 
            // button1
            // 
            button1.Location = new Point(215, 186);
            button1.Name = "button1";
            button1.Size = new Size(200, 35);
            button1.TabIndex = 26;
            button1.Text = "Hiện ảnh đường";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProbabilisticHoughLineTransform
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(trackBar3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(trackBar2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ProbabilisticHoughLineTransform";
            Size = new Size(599, 229);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TrackBar trackBar1;
        private Label label1;
        private TextBox textBox2;
        private TrackBar trackBar2;
        private Label label2;
        private TextBox textBox3;
        private TrackBar trackBar3;
        private Label label3;
        private Button button1;
    }
}
