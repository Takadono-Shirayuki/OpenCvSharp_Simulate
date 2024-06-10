namespace EmguCV_C_
{
    partial class ErodeAndDilate
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
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            trackBar1 = new TrackBar();
            textBox2 = new TextBox();
            trackBar2 = new TrackBar();
            checkBox2 = new CheckBox();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(214, 33);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Làm xói mòn ảnh";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(420, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 36);
            textBox1.TabIndex = 7;
            textBox1.Text = "3";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.White;
            trackBar1.Location = new Point(223, 0);
            trackBar1.Maximum = 12;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(191, 56);
            trackBar1.TabIndex = 6;
            trackBar1.Value = 1;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(420, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 36);
            textBox2.TabIndex = 10;
            textBox2.Text = "3";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.White;
            trackBar2.Location = new Point(223, 60);
            trackBar2.Maximum = 12;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(191, 56);
            trackBar2.TabIndex = 9;
            trackBar2.Value = 1;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 63);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(172, 33);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Làm giãn ảnh\r\n";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 120);
            label1.Name = "label1";
            label1.Size = new Size(76, 29);
            label1.TabIndex = 11;
            label1.Text = "Số lần";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(223, 120);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(191, 36);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(223, 162);
            button1.Name = "button1";
            button1.Size = new Size(191, 35);
            button1.TabIndex = 13;
            button1.Text = "Thực hiện";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ErodeAndDilate
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(trackBar2);
            Controls.Add(checkBox2);
            Controls.Add(textBox1);
            Controls.Add(trackBar1);
            Controls.Add(checkBox1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ErodeAndDilate";
            Size = new Size(488, 203);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private TextBox textBox1;
        private TrackBar trackBar1;
        private TextBox textBox2;
        private TrackBar trackBar2;
        private CheckBox checkBox2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button button1;
    }
}
