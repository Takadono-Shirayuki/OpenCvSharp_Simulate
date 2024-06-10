namespace OpenCVSharp_Video
{
    partial class InteractiveTrackBar
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
            Text = new Label();
            Tb = new TrackBar();
            Value = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Tb).BeginInit();
            SuspendLayout();
            // 
            // Text
            // 
            Text.Location = new Point(0, 0);
            Text.Name = "Text";
            Text.Size = new Size(200, 60);
            Text.TabIndex = 0;
            // 
            // Tb
            // 
            Tb.AutoSize = false;
            Tb.BackColor = Color.White;
            Tb.Location = new Point(200, 0);
            Tb.Name = "Tb";
            Tb.Size = new Size(300, 60);
            Tb.TabIndex = 1;
            Tb.ValueChanged += Tb_ValueChanged;
            // 
            // Value
            // 
            Value.Location = new Point(506, 3);
            Value.Name = "Value";
            Value.Size = new Size(100, 36);
            Value.TabIndex = 2;
            Value.Text = "0";
            Value.TextAlign = HorizontalAlignment.Center;
            Value.TextChanged += Value_TextChanged;
            // 
            // InteractiveTrackBar
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(Value);
            Controls.Add(Tb);
            Controls.Add(Text);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "InteractiveTrackBar";
            Size = new Size(613, 60);
            ((System.ComponentModel.ISupportInitialize)Tb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Text;
        private TrackBar Tb;
        private TextBox Value;
    }
}
