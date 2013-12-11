using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Stufkan.Game
{
    public partial class GenericBoard : UserControl
    {
        /// <summary>
        /// The grid currently shown in the board
        /// </summary>
        public Piece[,] grid;
        /// <summary>
        /// The grid containing the background
        /// </summary>
        public Piece[,] bgGrid;
        int rows = 5;
        bool border = true;

        Color Background = Color.White;


        #region Properties
        /// <summary>
        /// The color to draw dead cells
        /// </summary>
        [Category("Cellcolors")]
        [Description("The color of dead cells")]
        public Color BackgroundColor
        {
            get { return Background; }
            set { Background = value; }
        }


        /// <summary>
        /// If the control should draw a border around the cells
        /// </summary>
        [Category()]
        [Description("If the control should draw the border")]
        public bool Border
        {
            get { return border; }
            set { border = value; }
        }

        /// <summary>
        /// The number of rows in to show
        /// </summary>
        [Category()]
        [Description("The number of rows in the game of board")]
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Creates a standard board with an empty grid with 5x5 rows
        /// </summary>
        public GenericBoard()
        {

            grid = new Piece[rows, rows];

            InitializeComponent();
            
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint,
                true);
        }

        /// <summary>
        /// Creates a board with the specified grid
        /// </summary>
        /// <param name="grid">The grid to show in the board</param>
        public GenericBoard(Piece[,] grid)
            : this()
        {
            this.grid = grid;
            this.rows = grid.GetLength(1);
        }

        /// <summary>
        /// Creates a board with the specified grid and the specified colors for the dead and live cells
        /// </summary>
        /// <param name="grid">The grid to show in the board</param>
        /// <param name="background">The color to paint the background</param>
        public GenericBoard(Piece[,] grid, Color background)
            : this(grid)
        {
            this.Background = background;
        }

        /// <summary>
        /// Creates a board with the specified grid and the specified colors for the dead and live cells as well as the bgGrid as background
        /// </summary>
        /// <param name="grid">The grid to show in the board</param>
        /// <param name="background">The color to paint the background</param>
        /// <param name="bgGrid">The grid depicting the background</param>
        public GenericBoard(Piece[,] grid, Color background, Piece[,] bgGrid)
            : this(grid, background)
        {
            this.Background = background;
            this.bgGrid = bgGrid;
        }
        #endregion

        /// <summary>
        /// /// Sets the cell at the point cell in the current grid
        /// </summary>
        /// <param name="cell">The cell to set the value</param>
        /// <param name="piece">The piece to place at the cell</param>
        public void SetCell(Point cell, Piece piece)
        {
            grid[cell.X, cell.Y] = piece;
        }

        /// <summary>
        /// Removes the Piece from the cell
        /// </summary>
        /// <param name="cell"></param>
        public void ResetSetCell(Point cell)
        {
            grid[cell.X, cell.Y] = default(Piece);
        }

        /// <summary>
        /// Draws the current grid
        /// </summary>
        /// <param name="gfx">The Graphics instance to draw</param>
        /// <param name="height">The height of the board</param>
        private void DrawBoard(Graphics gfx, int height)
        {

            SolidBrush bgBrush = new SolidBrush(Background);

            int rectSize = (height / rows);

            int pensize = 1;

            if (rectSize == 1) pensize = 0;

            Pen pborder = new Pen(Color.Black, pensize);

            //Draws the background in the background color
            DrawBackground(gfx, pensize);

            //Draws the background grid
            if (bgGrid != null)
                DrawGrid(gfx, bgGrid, bgBrush, pensize);

            //Draws the pieces on the board
            DrawGrid(gfx, grid, new SolidBrush(Color.Empty), pensize);

            if (border)
            {
                DrawBorder(gfx, pborder);
            }
        }

        /// <summary>
        /// Draws a 
        /// </summary>
        /// <param name="gfx"></param>
        /// <param name="grid"></param>
        /// <param name="bgBrush"></param>
        /// <param name="pensize"></param>
        public void DrawGrid(Graphics gfx, Piece[,] grid, SolidBrush bgBrush, int pensize)
        {
            int rectSize = (this.Height / rows);
            int rest = this.Height % rows;

            int x = 0, y = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (grid[j, i] == null)
                    {
                        if (bgBrush.Color.Name != "0")
                            gfx.FillRectangle(bgBrush, x, y, rectSize, rectSize);
                    }
                    else
                    {
                        gfx.DrawImage((grid[j, i]).Model, x, y, rectSize, rectSize);
                    }
                    x += rectSize;
                }
                x = 0;
                y += rectSize;
            }
        }

        /// <summary>
        /// Draws the background color in all cells
        /// </summary>
        /// <param name="gfx">The graphic to draw the background on</param>
        /// <param name="pensize">The size of the pen</param>
        public void DrawBackground(Graphics gfx, int pensize)
        {
            int rectSize = (this.Height / rows);

            int x = 0, y = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    gfx.FillRectangle(new SolidBrush(Background), x , y, rectSize, rectSize);
                    x += rectSize;
                }
                x = 0;
                y += rectSize;
            }

        }

        /// <summary>
        /// Draws the border in an appropriate size to the area.
        /// </summary>
        /// <param name="gfx">The graphic to draw the border on</param>
        /// <param name="border">The pen to draw the border with</param>
        public void DrawBorder(Graphics gfx, Pen border)
        {
            int rectSize = (this.Height / rows);
            int rest = this.Height % rows;

            for (int k = 0; k <= rows; k++)
                gfx.DrawLine(border, 0, k * rectSize, this.Width - rest, k * rectSize);

            for (int l = 0; l <= rows; l++)
                gfx.DrawLine(border, l * rectSize, 0, l * rectSize, this.Width - rest);
        }

        /// <summary>
        /// Gets the coordinates to the cell at the pixel p
        /// </summary>
        /// <param name="p">The coordinates to the pixel in question</param>
        /// <returns>A Point representing the coordinates to the cell where p exists</returns>
        public Point getCellFromPoint(Point p)
        {
            int rectSize = this.Width / rows;
            int x = p.X / rectSize;
            int y = p.Y / rectSize;
            Point coordinates = new Point(x, y);
            if (CellExists(coordinates))
                return coordinates;
            else return new Point(-1, -1);

        }

        /// <summary>
        /// Returns if the cell at p exists
        /// </summary>
        /// <param name="p">A point containing the coordinates to the cell</param>
        /// <returns></returns>
        public bool CellExists(Point p)
        {
            int y = grid.GetLength(0);
            if (p.X > y || p.Y > grid.GetLength(0))
                return false;
            else return true;
        }

        /// <summary>
        /// Resets the grid so every cell is dead
        /// </summary>
        public void Reset()
        {
            grid = new Piece[rows, rows];
            this.Invalidate();
        }

        /// <summary>
        /// Paints the control with the grid
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;

            if (grid.GetLength(1) != rows)
            {
                grid = new Piece[rows, rows];
                //temp = new IT[rows, rows];
            }

            DrawBoard(gfx, this.Width);
        }

        /// <summary>
        /// Changes the pattern shown by the board to the specified pattern
        /// </summary>
        /// <param name="pattern">The pattern to show</param>
        public void changePattern(BoardPattern pattern)
        {
            this.grid = pattern.Grid;
            this.rows = pattern.Grid.GetLength(1);
            //this.temp = new IT[rows, rows];
        }

        /// <summary>
        /// Returns a bitmap of a solid canvas with the assigned color
        /// </summary>
        /// <param name="color">The color to fill the bitmap</param>
        /// <returns>A single colored bitmap</returns>
        public Bitmap solidModel(Color color)
        {
            Bitmap bmp = new Bitmap(30, 30);
            SolidBrush brush = new SolidBrush(color);
            using (Graphics g = Graphics.FromImage(bmp))
                g.FillRectangle(brush, 0, 0, 30, 30);

            return bmp;
        }

        /// <summary>
        /// Forces the board to be square when the control is resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Board_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            // Force the Form to square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }
        }
    }
}
