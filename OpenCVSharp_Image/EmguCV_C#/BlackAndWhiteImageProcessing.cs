using OpenCvSharp;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace EmguCV_C_
{
    public partial class BlackAndWhiteImageProcessing : UserControl
    {
        Mat Image = new Mat();
        BasicOperations BasicOperations;
        public BlackAndWhiteImageProcessing(BasicOperations basicOperations)
        {
            InitializeComponent();
            BasicOperations = basicOperations;
        }

        private void BlackAndWhiteImageProcessing_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 127;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            objectCount();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            Cv2.CvtColor(BasicOperations.GetShowingImage(), Image, ColorConversionCodes.BGR2GRAY);
            for (int i = 0; i < Image.Cols; i++)
            {
                for (int j = 0; j < Image.Rows; j++)
                {
                    if (Image.At<byte>(j, i) <= trackBar1.Value)
                        Image.Set<byte>(j, i, 0);
                    else
                        Image.Set<byte>(j, i, 255);
                }
            }
            Mat Temp = new Mat();
            Cv2.CvtColor(Image, Temp, ColorConversionCodes.GRAY2BGR);
            BasicOperations.UsingPictureBox.Image = BasicOperations.MatToBitmap(Temp);
            objectCount();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                if (value > 255)
                    value = 255;
                if (value < 0)
                    value = 0;
                trackBar1.Value = value;
            }
        }

        private void objectCount()
        {
            int count = 0;
            int Color;
            Boolean[,] Visited = new Boolean[Image.Cols, Image.Rows];
            for (int i = 0; i < Image.Cols; i++)
            {
                for (int j = 0; j < Image.Rows; j++)
                {
                    Visited[i, j] = false;
                }
            }

            if (comboBox1.SelectedIndex == 0)
                Color = 0;
            else
                Color = 255;
            for (int i = 0; i < Image.Cols; i++)
            {
                for (int j = 0; j < Image.Rows; j++)
                {
                    if (!Visited[i, j])
                    {
                        if (Image.At<byte>(j, i) == Color)
                        {
                            count++;
                            BFS8K(i, j, Color, Visited);
                        }
                        else
                        {
                            count++;
                            BFS4K(i, j, 255 - Color, Visited);
                        }    
                    }
                }
            }
            ObjectCount.Text = count.ToString();
        }

        struct Location
        {
            public int x;
            public int y;
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public static Location operator +(Location a, Location b)
            {
                return new Location(a.x + b.x, a.y + b.y);
            }
            
            public static Boolean operator ==(Location a, Location b)
            {
                return a.x == b.x && a.y == b.y;
            }

            public static Boolean operator !=(Location a, Location b)
            {
                return a.x != b.x || a.y != b.y;
            }
        }

        private void BFS8K(int i, int j, int Color, Boolean[,] Visited)
        {
            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(new Location(i, j));
            while (queue.Count > 0)
            {
                Location point = queue.Dequeue();
                int x = point.x;
                int y = point.y;
                if (x < 0 || x >= Image.Cols || y < 0 || y >= Image.Rows)
                    continue;
                if (Visited[x, y])
                    continue;

                if (Image.At<byte>(y, x) == Color)
                    Visited[x, y] = true;
                else
                    continue;
                queue.Enqueue(new Location(x - 1, y));
                queue.Enqueue(new Location(x + 1, y));
                queue.Enqueue(new Location(x, y - 1));
                queue.Enqueue(new Location(x, y + 1));
                queue.Enqueue(new Location(x - 1, y - 1));
                queue.Enqueue(new Location(x + 1, y + 1));
                queue.Enqueue(new Location(x + 1, y - 1));
                queue.Enqueue(new Location(x - 1, y + 1));
            }
        }

        private void BFS4K(int i, int j, int Color, Boolean[,] Visited)
        {
            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(new Location(i, j));
            while (queue.Count > 0)
            {
                Location point = queue.Dequeue();
                int x = point.x;
                int y = point.y;
                if (x < 0 || x >= Image.Cols || y < 0 || y >= Image.Rows)
                    continue;
                if (Visited[x, y])
                    continue;
                int c = Image.At<byte>(y, x);
                if (Image.At<byte>(y, x) == Color)
                    Visited[x, y] = true;
                else
                    continue;

                queue.Enqueue(new Location(x - 1, y));
                queue.Enqueue(new Location(x + 1, y));
                queue.Enqueue(new Location(x, y - 1));
                queue.Enqueue(new Location(x, y + 1));
            }
        }

        public void MME(int[] PixcelLocation)
        {
            int Color = Image.At<byte>(PixcelLocation[1], PixcelLocation[0]);
            int area = 0;
            double perimeter = 0;
            Location NorthernEndLocation = new Location(PixcelLocation[0], PixcelLocation[1]);

            Boolean[,] Visited = new Boolean[Image.Cols, Image.Rows];
            for (int i = 0; i < Image.Cols; i++)
            {
                for (int j = 0; j < Image.Rows; j++)
                {
                    Visited[i, j] = false;
                }
            }

            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(new Location(PixcelLocation[0], PixcelLocation[1]));
            while (queue.Count > 0)
            {
                Location point = queue.Dequeue();
                int x = point.x;
                int y = point.y;
                if (x < 0 || x >= Image.Cols || y < 0 || y >= Image.Rows)
                    continue;
                if (Visited[x, y])
                    continue;
                if (Image.At<byte>(y, x) == Color)
                    area += 1;
                else
                    continue;
                Visited[x, y] = true;
                if (y < NorthernEndLocation.y)
                    NorthernEndLocation = point;
                queue.Enqueue(new Location(x - 1, y));
                queue.Enqueue(new Location(x + 1, y));
                queue.Enqueue(new Location(x, y - 1));
                queue.Enqueue(new Location(x, y + 1));
                queue.Enqueue(new Location(x - 1, y - 1));
                queue.Enqueue(new Location(x + 1, y + 1));
                queue.Enqueue(new Location(x + 1, y - 1));
                queue.Enqueue(new Location(x - 1, y + 1));
            }

            Location[] A8 = { new Location(-1, 0), new Location(-1, 1), new Location(0, 1), new Location(1, 1), new Location(1, 0), new Location(1, -1), new Location(0, -1), new Location(-1, -1) };
            Location Current = NorthernEndLocation;
            int NextDirection = 0;
            do
            {
                int d = 0;
                while (true)
                {
                    Location Temp = Current + A8[NextDirection];
                    if (Temp.x < 0 || Temp.x >= Image.Cols || Temp.y < 0 || Temp.y >= Image.Rows)
                    {
                        NextDirection = (NextDirection + 1) % 8;
                        continue;
                    }
                    Boolean V = Visited[Temp.x, Temp.y];
                    if (Visited[Temp.x, Temp.y])
                    {
                        Current = Temp;
                        if (NextDirection % 2 == 0)
                            perimeter += 1;
                        else
                            perimeter += Math.Sqrt(2);
                        NextDirection = (NextDirection + 5) % 8;
                        break; 
                    }
                    else
                    {
                        NextDirection = (NextDirection + 1) % 8;
                    }
                    d++;
                    if (d == 8)
                        break;
                }
            }
            while (Current != NorthernEndLocation);

            Area.Text = area.ToString();
            Perimeter.Text = Math.Round(perimeter, 2).ToString();
        }
    }
}
