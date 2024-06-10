namespace OpenCVSharp_Video
{
    partial class InteractiveDoubleTrackBar
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
            ValueLow = new TextBox();
            TbLow = new TrackBar();
            TextLow = new Label();
            ValueHigh = new TextBox();
            TbHigh = new TrackBar();
            TextHigh = new Label();
            ((System.ComponentModel.ISupportInitialize)TbLow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TbHigh).BeginInit();
            SuspendLayout();
            // 
            // ValueLow
            // 
            ValueLow.Location = new Point(506, 3);
            ValueLow.Name = "ValueLow";
            ValueLow.Size = new Size(100, 36);
            ValueLow.TabIndex = 5;
            ValueLow.Text = "0";
            ValueLow.TextAlign = HorizontalAlignment.Center;
            ValueLow.TextChanged += ValueLow_TextChanged;
            // 
            // TbLow
            // 
            TbLow.AutoSize = false;
            TbLow.BackColor = Color.White;
            TbLow.Location = new Point(200, 0);
            TbLow.Name = "TbLow";
            TbLow.Size = new Size(300, 60);
            TbLow.TabIndex = 4;
            TbLow.ValueChanged += TbLow_ValueChanged;
            // 
            // TextLow
            // 
            TextLow.Location = new Point(0, 0);
            TextLow.Name = "TextLow";
            TextLow.Size = new Size(200, 60);
            TextLow.TabIndex = 3;
            // 
            // ValueHigh
            // 
            ValueHigh.Location = new Point(506, 69);
            ValueHigh.Name = "ValueHigh";
            ValueHigh.Size = new Size(100, 36);
            ValueHigh.TabIndex = 8;
            ValueHigh.Text = "0";
            ValueHigh.TextAlign = HorizontalAlignment.Center;
            ValueHigh.TextChanged += ValueHigh_TextChanged;
            // 
            // TbHigh
            // 
            TbHigh.AutoSize = false;
            TbHigh.BackColor = Color.White;
            TbHigh.Location = new Point(200, 66);
            TbHigh.Name = "TbHigh";
            TbHigh.Size = new Size(300, 60);
            TbHigh.TabIndex = 7;
            TbHigh.ValueChanged += TbHigh_ValueChanged;
            // 
            // TextHigh
            // 
            TextHigh.Location = new Point(0, 66);
            TextHigh.Name = "TextHigh";
            TextHigh.Size = new Size(200, 60);
            TextHigh.TabIndex = 6;
            // 
            // InteractiveDoubleTrackBar
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ValueHigh);
            Controls.Add(TbHigh);
            Controls.Add(TextHigh);
            Controls.Add(ValueLow);
            Controls.Add(TbLow);
            Controls.Add(TextLow);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "InteractiveDoubleTrackBar";
            Size = new Size(613, 130);
            ((System.ComponentModel.ISupportInitialize)TbLow).EndInit();
            ((System.ComponentModel.ISupportInitialize)TbHigh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ValueLow;
        private TrackBar TbLow;
        private Label TextLow;
        private TextBox ValueHigh;
        private TrackBar TbHigh;
        private Label TextHigh;
    }
}
