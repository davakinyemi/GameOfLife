using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Diagnostics;


namespace GameOfLife
{
    public partial class MainFormGameOfLife : Form
    {
        // pixel size of cell
        private int cellSize = Defaults.CellSize;

        private Cell[,] currentFigure;

        private Cell[,] area;
        private Point   areaPixelLocation;
        private Size    areaPixelSize;
        private Size    areaSize;

        private Color liveColor           = Defaults.LiveColor;
        private Color deadColor           = Defaults.DeadColor;
        private Color areaBackgroundColor = Defaults.AreaBackgroundColor;
        private Color gridColor           = Defaults.GridColor;

        public static Timer timer1 = new System.Windows.Forms.Timer();
        long roundCount = 0;


        private Size GetAreaSizeFromPixelSize(Size areaSizeInPixels)
        {
            return new Size(areaSizeInPixels.Width / cellSize, areaSizeInPixels.Height / cellSize);
        }

        // initialize animation area
        public void InitializeArea()
        {
            area = new Cell[areaSize.Width, areaSize.Height];
           
            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    area[i, l] = new Cell(Cell.Status.Empty, 0);                    
                }
            }
        }

        public void SetAreaSize(int width, int height)
        {
            areaSize            = new Size(width, height);
            areaPixelSize       = new Size(width * cellSize, height * cellSize);
            this.areaField.Size = areaPixelSize;
            InitializeArea();
        }

        // Method to set width and height of game area
        public void SetAreaSize(Size newSize)
        {
            SetAreaSize(newSize.Width, newSize.Height);
        }

        public void ReadLocationFromArea()
        {
            areaPixelLocation = this.areaField.Location;
        }

        public MainFormGameOfLife()
        {
            InitializeComponent();

            // Initialize area
            ReadLocationFromArea();
            SetAreaSize(Defaults.AreaHeight, Defaults.AreaHeight);
            InitializeArea();
                        
            // Initialize color fields by using the default values.
            this.areaBackgroundColorField.BackColor = areaBackgroundColor;
            
            this.liveColorField.BackColor           = liveColor;
            this.deadColorField.BackColor           = deadColor;

            // Select default figure.
            foreach(KeyValuePair<string, byte[]> entry in Defaults.Figures)
            {
                this.comboBox1.Items.Add(entry.Key.ToString());
            }
            // set initial default figure
            this.comboBox1.SelectedIndex = Defaults.FigureIndex;

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawCell);
            this.Invalidate();
            timer1.Tick += new EventHandler(timer_1_Tick);

            //MessageBox.Show("Welcome to the amazing Game of Life");
        }

        // set LiveArea state from mouse click event
        private void areaField_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            Point p = GetAreaPositionFromMouse(mouseEvent.Location);

            if (mouseEvent.Button == MouseButtons.Left)
            {
                int width = currentFigure.GetLength(0);
                int height = currentFigure.GetLength(1);

                int xOffset = (width + 1) / 2 - 1;
                int yOffset = (height + 1) / 2 - 1;

                if (p.X - xOffset + (width - 1) >= areaSize.Width ||
                    p.Y - yOffset + (height - 1) >= areaSize.Height ||
                    p.X - xOffset < 0 ||
                    p.Y - yOffset < 0)
                {
                    return;
                }

                for (int i = 0; i < width; ++i)
                {
                    for (int j = 0; j < height; ++j)
                    {
                        area[p.X - xOffset + i, p.Y - yOffset + j] = currentFigure[i, j];
                    }
                }
            }
            else if (mouseEvent.Button == MouseButtons.Right)
            {
                area[p.X, p.Y].status = Cell.Status.Empty;
            }

            this.Invalidate();
        }

        // Event method to enable "drawing" on game area
        private void areaField_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = GetAreaPositionFromMouse(e.Location);
                area[p.X, p.Y].status = Cell.Status.Alive;
                this.Invalidate();
                this.Update();
            }
        }

        public int Clamp(int value, int low, int high)
        {
            return value < low ? low : (value > high ? high : value);
        }

        // get mouseposition on drawpanel
        public Point GetAreaPositionFromMouse(Point p)
        {
            int newX = p.X / cellSize;
            int newY = p.Y / cellSize;

            newX = Clamp(newX, 0, areaSize.Width - 1);
            newY = Clamp(newY, 0, areaSize.Height - 1);

            return new Point(newX, newY);
        }
        
        // Event method to paint game area
        public void DrawCell(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics draw = e.Graphics;            
            draw.Clear(System.Drawing.SystemColors.Control);

            for (int i = 0; i < areaSize.Width; i++)
            {
                for(int l = 0; l < areaSize.Height; l++)
                {
                    SolidBrush brush; 
                    Cell cell = area[i, l];
                    if(cell.status == Cell.Status.Alive)
                    {
                        brush = new SolidBrush(liveColor);
                    }
                    else if (cell.status == Cell.Status.Dead)
                    {
                        brush = new SolidBrush(deadColor);
                    }
                    else
                    {
                        brush = new SolidBrush(areaBackgroundColor);
                    }                                
                    draw.FillRectangle(brush, i * cellSize + areaPixelLocation.X, l * cellSize + areaPixelLocation.Y, cellSize, cellSize);
                    
                }
            }

            /* implement Grid
             * improve loading Speed
             */ 
            /*for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    Pen gridPen = new Pen(Color.Black);
                    draw.DrawRectangle(gridPen, i * CellSize + areaPixelLocation.X, l * CellSize + areaPixelLocation.Y, CellSize, CellSize);
                }
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Event method to start timer
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
                timer1.Start();
                buttonStart.Text = "Stopp";
            }
            else
            {
                timer1.Enabled = false;
                timer1.Stop();
                buttonStart.Text = "Go";
            }
        }

        // run animation method while timer is ticking
        private void timer_1_Tick(object sender, EventArgs e)
        {
            animation();
        }

        // animation method
        private void animation()
        {
            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    Cell cell = area[i, l];
                    int x, y;
                    uint count = 0;
                    for (int a = -1; a <= 1; a++)
                    {
                        for (int b = -1; b <= 1; b++)
                        {
                            x = (i + areaSize.Width + a) % areaSize.Width;
                            y = (l + areaSize.Height + b) % areaSize.Height;
                            if (!(a == 0 && b == 0))
                            {
                                if (area[x, y].status == Cell.Status.Alive)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    area[i, l].neighbors = count;
                }
            }

            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    Cell cell = area[i, l];

                    // Game rules
                    if ((cell.neighbors == Cell.MaxNeighbors) && cell.status != Cell.Status.Alive)
                    {
                        area[i, l].status = Cell.Status.Alive;
                    }
                    else
                    {
                        if (cell.status == Cell.Status.Alive && (cell.neighbors < Cell.MinNeighbors || cell.neighbors > Cell.MaxNeighbors))
                        {
                            area[i, l].status = Cell.Status.Dead;
                        }
                    }
                }
                this.Invalidate();
            }
            roundCount++;
            this.displayRound.Text = roundCount.ToString();
        }

        // Event method to reset timer and clear game area
        private void buttonReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            buttonStart.Text = "Go";
            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    area[i, l].status = Cell.Status.Empty;
                }
                this.Invalidate();
            }
            roundCount = 0;
            this.displayRound.Text = roundCount.ToString();
        }

        // Event method to start timer and animation
        private void buttonState_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            buttonStart.Text = "Go";
            animation();
        }

        // Event method to increase timer speed (by 10 milliseconds)
        private void buttonTincrease_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval -= 10;
            timer1.Enabled = true;
        }

        // Event method to decrease timer speed (by 10 milliseconds)
        private void buttonTdecrease_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval += 10;
            timer1.Enabled = true;
        }
        
        // color picker method
        private void PickColor(ref Color color)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
            }
        }

        // Event method to set the color of live cells
        private void liveColorField_Click(object sender, EventArgs e)
        {
            PickColor(ref liveColor);
            this.liveColorField.BackColor = liveColor;
            this.Invalidate();
        }

        // Event method to set the color of dead cells
        private void deadColorField_Click(object sender, EventArgs e)
        {
            PickColor(ref deadColor);
            this.deadColorField.BackColor = deadColor;
            this.Invalidate();
        }

        // Event method to set the color of empty cells
        private void areaBackgroundColorField_Click(object sender, EventArgs e)
        {
            PickColor(ref areaBackgroundColor);
            this.areaBackgroundColorField.BackColor = areaBackgroundColor;
            this.Invalidate();
        }
        
        // Event method to fill the game field randomly        
        private void randomFillButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            // get a random number between 5 and 20
            int upperLimit = rnd.Next(5, 20); 

            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {
                    // if random number below upperLimit is 0, make cell status alive
                    if (rnd.Next(upperLimit) == 0)
                    {
                        area[i, l].status = Cell.Status.Alive;
                    }
                    else
                    {
                        area[i, l].status = Cell.Status.Empty;
                    }
                }
            }
            this.Invalidate();
        }

        // Event method to switch to "anti-world." Dead cells become alive and live cells die  
        private void switchState_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < areaSize.Width; i++)
            {
                for (int l = 0; l < areaSize.Height; l++)
                {                    
                    Cell cell = area[i, l];
                    if (cell.status == Cell.Status.Alive)
                    {
                        area[i, l].status = Cell.Status.Dead;
                    }
                    else if (cell.status == Cell.Status.Dead)
                    {
                        area[i, l].status = Cell.Status.Alive;
                    }
                }
            }
            this.Invalidate();
        }

        // Event method to save (serialize) file
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream stream = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, area);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        // Event method to load (deserialize) saved valid file to game field
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream stream = File.Open(openFileDialog.FileName, FileMode.Open))
                    {
                        Cell[,] newArea;
                        BinaryFormatter bf = new BinaryFormatter();
                        newArea = (Cell[,])bf.Deserialize(stream);

                        if (newArea.Rank != 2)
                        {
                            MessageBox.Show("Invalid file format: Dimension mismatch");
                            throw new Exception("Invalid file format: Dimension mismatch");
                        }

                        int width = newArea.GetLength(0);
                        int height = newArea.GetLength(1);

                        SetAreaSize(width, height);
                        area = newArea;

                        this.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        // method to deserialize byte data from file and assign it to currentfigure 
        public void loadFigureFromResources(ref byte[] data)
        {
            try
            {
                using (Stream stream = new MemoryStream(data))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Cell[,] newFigure = (Cell[,])bf.Deserialize(stream);

                    Debug.Assert(newFigure.Rank == 2, "Resource file has wrong number of dimensions");

                    currentFigure = newFigure;
                    Console.WriteLine("Loaded figure");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Event method for choosing default figure from combo box
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            var selected = comboBox.SelectedItem.ToString();
  
            byte[] resourcePath;
            bool foundValue = Defaults.Figures.TryGetValue(selected, out resourcePath);

            Debug.Assert(foundValue, "Oops found an invalid figure: " + selected);

            loadFigureFromResources(ref resourcePath);
        }
        
        // Event method to change pixel size
        private void pixelSizeButton_Click(object sender, EventArgs e)
        {
            ColorChoiceForm2 pixelsizeChange = new ColorChoiceForm2();
            if (pixelsizeChange.ShowDialog() == DialogResult.OK)
            {
                cellSize = (int)pixelsizeChange.pixelSize;
                SetAreaSize(areaSize.Width, areaSize.Height);
                this.Invalidate();
            }
        }

        // Event method to change field size
        private void buttonAreaFieldSize_Click(object sender, EventArgs e)
        {
            AreaSizeForm areaSizeForm = new AreaSizeForm();
            areaSizeForm.AreaWidth = areaSize.Width;
            areaSizeForm.AreaHeight = areaSize.Height;

            if (areaSizeForm.ShowDialog() == DialogResult.OK)
            {
                SetAreaSize(areaSizeForm.AreaWidth, areaSizeForm.AreaHeight);
                this.Invalidate();
            }
        }
        
    }
}
