namespace OpenCVSharp_Video
{
    public partial class InteractiveDoubleTrackBar : UserControl
    {
        Form1.Operation operation;
        Form1.TbValueChange tbValueChange;
        Form1.ValueChange valueChange;

        public string ValueLowText
        {
            get { return ValueLow.Text; }
        }
        public string ValueHighText
        {
            get { return ValueHigh.Text; }
        }

        public int DefaultValueLow
        {
            set 
            { 
                TbLow.Value = value; 
                ValueLow.Text = tbValueChange(value);
            }
        }
        public int DefaultValueHigh
        {
            set 
            { 
                TbHigh.Value = value; 
                ValueHigh.Text = tbValueChange(value);
            }
        }

        public InteractiveDoubleTrackBar(string[] Text, Form1.Operation? Operation = null, Form1.TbValueChange? TbValueChange = null, Form1.ValueChange? ValueChange = null, int[]? TrackBarMinimun = null, int[]? TrackBarMaxium = null, int[]? TrackBarLargeChange = null)
        {
            InitializeComponent();
            this.TextLow.Text = Text[0];
            this.TextHigh.Text = Text[1];
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
            if (TrackBarMinimun == null)
            {
                TbLow.Minimum = 0;
                TbHigh.Minimum = 0;
            }
            else
            {
                TbLow.Minimum = TrackBarMinimun[0];
                TbHigh.Minimum = TrackBarMinimun[1];
            }
            if (TrackBarMaxium == null)
            {
                TbLow.Maximum = 255;
                TbHigh.Maximum = 255;
            }
            else
            {
                TbLow.Maximum = TrackBarMaxium[0];
                TbHigh.Maximum = TrackBarMaxium[1];
            }
            if (TrackBarLargeChange == null)
            {
                TbLow.LargeChange = 10;
                TbHigh.LargeChange = 10;
            }
            else
            {
                TbLow.LargeChange = TrackBarLargeChange[0];
                TbHigh.LargeChange = TrackBarLargeChange[1];
            }
        }

        private string TbValueChangeDefaut(int value)
        {
            if (value < TbLow.Minimum)
                value = TbLow.Minimum;
            if (value > TbLow.Maximum)
                value = TbLow.Maximum;
            return value.ToString();
        }

        private int ValueChangeDefaut(string value)
        {
            if (int.TryParse(value, out int result))
            {
                if (result < TbLow.Minimum)
                    result = TbLow.Minimum;
                if (result > TbLow.Maximum)
                    result = TbLow.Maximum;
                return result;
            }
            return TbLow.Minimum - 1;
        }

        private void TbLow_ValueChanged(object sender, EventArgs e)
        {
            ValueLow.Text = tbValueChange(TbLow.Value);
            if (TbLow.Value > TbHigh.Value)
                TbHigh.Value = TbLow.Value;
            operation();
        }

        private void TbHigh_ValueChanged(object sender, EventArgs e)
        {
            ValueHigh.Text = tbValueChange(TbHigh.Value);
            if (TbHigh.Value < TbLow.Value)
                TbLow.Value = TbHigh.Value;
            operation();
        }

        private void ValueLow_TextChanged(object sender, EventArgs e)
        {
            int value = valueChange(ValueLow.Text);
            if (value < TbLow.Minimum)
                return;
            TbLow.Value = value;
        }

        private void ValueHigh_TextChanged(object sender, EventArgs e)
        {
            int value = valueChange(ValueHigh.Text);
            if (value < TbHigh.Minimum)
                return;
            TbHigh.Value = value;
        }
    }
}
