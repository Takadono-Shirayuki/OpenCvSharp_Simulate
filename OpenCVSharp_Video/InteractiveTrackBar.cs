namespace OpenCVSharp_Video
{
    public partial class InteractiveTrackBar : UserControl
    {
        Form1.Operation operation;
        Form1.TbValueChange tbValueChange;
        Form1.ValueChange valueChange;

        public string ValueText
        {
            get { return Value.Text; }
        }
        public int DefaultValue
        {
            set 
            { 
                Tb.Value = value; 
                Value.Text = tbValueChange(value);
            }
        }
        public InteractiveTrackBar(string Text, Form1.Operation? Operation = null, Form1.TbValueChange? TbValueChange = null, Form1.ValueChange? ValueChange = null, int TrackBarMinimun = 0, int TrackBarMaxium = 255, int TrackBarLargeChange = 10)
        {
            InitializeComponent();
            this.Text.Text = Text;
            if (Operation == null)
                operation = delegate { };
            else
                operation = Operation;
            if (TbValueChange == null)
                tbValueChange = TbValueChangeDefaut;
            else
                tbValueChange = TbValueChange;
            if (ValueChange == null)
                valueChange = ValueChangeDefaut;
            else
                valueChange = ValueChange;
            Tb.Minimum = TrackBarMinimun;
            Tb.Maximum = TrackBarMaxium;
            Tb.LargeChange = TrackBarLargeChange;
        }

        private string TbValueChangeDefaut(int value)
        {
            if (value < Tb.Minimum)
                value = Tb.Minimum;
            if (value > Tb.Maximum)
                value = Tb.Maximum;
            return value.ToString();
        }

        private int ValueChangeDefaut(string value)
        {
            if (int.TryParse(value, out int result))
            {
                if (result < Tb.Minimum)
                    result = Tb.Minimum;
                if (result > Tb.Maximum)
                    result = Tb.Maximum;
                return result;
            }
            return Tb.Minimum - 1;
        }

        private void Tb_ValueChanged(object sender, EventArgs e)
        {
            Value.Text = tbValueChange(Tb.Value);
            operation();
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {
            int value = valueChange(Value.Text);
            if (value < Tb.Minimum)
                return;
            Tb.Value = value;
        }
    }
}
