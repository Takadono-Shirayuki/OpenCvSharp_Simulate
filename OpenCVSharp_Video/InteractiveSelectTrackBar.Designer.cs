namespace OpenCVSharp_Video
{
    partial class InteractiveSelectTrackBar
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
            Value = new TextBox();
            Tb = new TrackBar();
            Text = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)Tb).BeginInit();
            SuspendLayout();
            // 
            // Value
            // 
            Value.Location = new Point(506, 3);
            Value.Name = "Value";
            Value.Size = new Size(100, 36);
            Value.TabIndex = 5;
            Value.Text = "0";
            Value.TextAlign = HorizontalAlignment.Center;
            Value.TextChanged += Value_TextChanged;
            // 
            // Tb
            // 
            Tb.AutoSize = false;
            Tb.BackColor = Color.White;
            Tb.Location = new Point(200, 0);
            Tb.Name = "Tb";
            Tb.Size = new Size(300, 60);
            Tb.TabIndex = 4;
            Tb.ValueChanged += Tb_ValueChanged;
            // 
            // Text
            // 
            Text.Location = new Point(0, 0);
            Text.Name = "Text";
            Text.Size = new Size(200, 60);
            Text.TabIndex = 6;
            Text.UseVisualStyleBackColor = true;
            Text.CheckedChanged += Text_CheckedChanged;
            // 
            // InteractiveSelectTrackBar
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(Text);
            Controls.Add(Value);
            Controls.Add(Tb);
            Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "InteractiveSelectTrackBar";
            Size = new Size(613, 60);
            ((System.ComponentModel.ISupportInitialize)Tb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Value;
        private TrackBar Tb;
        private CheckBox Text;
    }
}
