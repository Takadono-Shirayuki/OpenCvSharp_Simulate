namespace OpenCVSharp_Video
{
    public partial class IButton : UserControl
    {
        Form1.ShowImage ShowImage;
        public IButton(string Text, Form1.ShowImage showImage)
        {
            InitializeComponent();
            this.button1.Text = Text;
            ShowImage = showImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowImage();
        }
    }
}
