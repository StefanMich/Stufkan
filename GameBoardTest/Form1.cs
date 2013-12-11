using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stufkan.Game;

namespace GameBoardTest
{
    public partial class Form1 : Form
    {
        Team Red;
        Team Black;

        Piece redPiece;
        Piece blackPiece;
        Piece black;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameBoard1_Load(object sender, EventArgs e)
        {
            Red = new Team("Red", 1);
            Black = new Team("Black", 2);

            redPiece = new Piece("Check", Red, Properties.Resources.red);
            blackPiece = new Piece("Check", Black, Properties.Resources.black);

            Red.Add(redPiece);
            Black.Add(blackPiece);

            black = new Piece("wat", Black, Properties.Resources.life);
            gameBoard1.grid[0, 0] = blackPiece;
            gameBoard1.bgGrid = chessBoard();
            //gameBoard1.grid[3, 2] = black;
            //gameBoard1.grid[2, 3] = blackPiece;
            
        }

        private void gameBoard1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point toggle = gameBoard1.getCellFromPoint(e.Location);
                if (!toggle.Equals(new Point(-1, -1)))
                {
                    gameBoard1.SetCell(toggle, blackPiece);
                }
                gameBoard1.Invalidate();
            }

        }

        private Piece[,] chessBoard()
        {
            Piece[,] chess = new Piece[8, 8];

            Piece black = new Piece("black", null, gameBoard1.solidModel(Color.Black));

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                        chess[i, j] = black;
                }
            }

            return chess;
        }
    }
}
