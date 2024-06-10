namespace EmguCV_C_
{
    partial class EdgeDetection
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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(459, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 36);
            textBox1.TabIndex = 5;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.White;
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(153, 0);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(300, 56);
            trackBar1.TabIndex = 4;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 29);
            label1.TabIndex = 3;
            label1.Text = "Ngưỡng thấp";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(459, 65);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 36);
            textBox2.TabIndex = 8;
            textBox2.Text = "0";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.White;
            trackBar2.LargeChange = 10;
            trackBar2.Location = new Point(153, 62);
            trackBar2.Maximum = 255;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(300, 56);
            trackBar2.TabIndex = 7;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 62);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(142, 29);
            label2.TabIndex = 6;
            label2.Text = "Ngưỡng cao ";
            // 
            // button1
            // 
            button1.Location = new Point(153, 124);
            button1.Name = "button1";
            button1.Size = new Size(200, 35);
            button1.TabIndex = 9;
            button1.Text = "Hiện ảnh biên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EdgeDetection
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(trackBar2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "EdgeDetection";
            Size = new Size(536, 167);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
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
        private Button button1;
    }
}
