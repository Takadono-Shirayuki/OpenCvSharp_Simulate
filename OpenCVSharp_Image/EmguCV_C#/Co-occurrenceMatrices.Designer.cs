namespace EmguCV_C_
{
    partial class Co_occurrenceMatrices
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            UniformityMeasure = new Label();
            label3 = new Label();
            HomogeneityMeaSure = new Label();
            label2 = new Label();
            Sum = new Label();
            Value = new Label();
            Y = new Label();
            X = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(5, 4, 5, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(UniformityMeasure);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(HomogeneityMeaSure);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(Sum);
            splitContainer1.Panel1.Controls.Add(Value);
            splitContainer1.Panel1.Controls.Add(Y);
            splitContainer1.Panel1.Controls.Add(X);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(988, 593);
            splitContainer1.SplitterDistance = 329;
            splitContainer1.TabIndex = 0;
            // 
            // UniformityMeasure
            // 
            UniformityMeasure.AutoSize = true;
            UniformityMeasure.Location = new Point(10, 287);
            UniformityMeasure.Name = "UniformityMeasure";
            UniformityMeasure.Size = new Size(0, 29);
            UniformityMeasure.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 247);
            label3.Name = "label3";
            label3.Size = new Size(216, 29);
            label3.TabIndex = 7;
            label3.Text = "Uniformity Measure";
            // 
            // HomogeneityMeaSure
            // 
            HomogeneityMeaSure.AutoSize = true;
            HomogeneityMeaSure.Location = new Point(10, 207);
            HomogeneityMeaSure.Name = "HomogeneityMeaSure";
            HomogeneityMeaSure.Size = new Size(0, 29);
            HomogeneityMeaSure.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 167);
            label2.Name = "label2";
            label2.Size = new Size(242, 29);
            label2.TabIndex = 5;
            label2.Text = "Homogeneity Measure";
            // 
            // Sum
            // 
            Sum.AutoSize = true;
            Sum.Location = new Point(10, 127);
            Sum.Name = "Sum";
            Sum.Size = new Size(178, 29);
            Sum.TabIndex = 4;
            Sum.Text = "Tổng các giá trị: ";
            // 
            // Value
            // 
            Value.AutoSize = true;
            Value.Location = new Point(10, 87);
            Value.Name = "Value";
            Value.Size = new Size(87, 29);
            Value.TabIndex = 3;
            Value.Text = "Giá trị: ";
            // 
            // Y
            // 
            Y.AutoSize = true;
            Y.Location = new Point(120, 47);
            Y.Name = "Y";
            Y.Size = new Size(34, 29);
            Y.TabIndex = 2;
            Y.Text = "Y:";
            // 
            // X
            // 
            X.AutoSize = true;
            X.Location = new Point(10, 47);
            X.Name = "X";
            X.Size = new Size(37, 29);
            X.TabIndex = 1;
            X.Text = "X:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(83, 29);
            label1.TabIndex = 0;
            label1.Text = "Tọa độ";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(651, 589);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // Co_occurrenceMatrices
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 593);
            Controls.Add(splitContainer1);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Co_occurrenceMatrices";
            Text = "Ma trận đồng xuất hiện";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label Sum;
        private Label Value;
        private Label Y;
        private Label X;
        private Label HomogeneityMeaSure;
        private Label label2;
        private Label label3;
        private Label UniformityMeasure;
    }
}