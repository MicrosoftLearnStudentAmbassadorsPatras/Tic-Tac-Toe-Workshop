using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            turn = 2;
            board = new String[3, 3] { { "1", "2", "3" },
                                       { "4", "5", "6",},
                                       { "7", "8", "9" }
                                     };
            /* The Board:
            *   [0,0] [0,1] [0,2]   ||  [b1] [b2] [b3]
            *   [1,0] [1,1] [1,2]   ||  [b4] [b5] [b6]
            *   [2,0] [2,1] [2,2]   ||  [b7] [b8] [b9]
            */
            symbol = "X";
            gameOver = false;
            
        }

        private void Start_New_Game(object sender, EventArgs e)
        {
            // Reset text on buttons
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";

            // Reset Board
            board = new String[3, 3] { { "1", "2", "3" },
                                       { "4", "5", "6",},
                                       { "7", "8", "9" }
                                     };

            label1.Text = "Next Turn: Player 1"; // Reset label
            turn = 2; // Reset counter
            symbol = "X"; // Reset symbol 
            gameOver = false;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                Button b = sender as Button;
                // Determine symbol to place on button
                if (turn % 2 == 0) // Player 1
                {
                    b.Text = "X";
                    symbol = "X";
                }
                else  // Player 2
                {
                    b.Text = "O";
                    symbol = "O";
                }

                updateBoard(b.Name);

                turn++; // Next Player
                label1.Text = "Next Turn: Player " + (turn % 2 + 1); // Update label
            }

            checkWin();

            
        }

        private void updateBoard(string name)
        {
            // Update board
            switch (name)
            {
                case "b1":
                    board[0,0] = symbol;
                    break;
                case "b2":
                    board[0,1] = symbol;
                    break;
                case "b3":
                    board[0,2] = symbol;
                    break;
                case "b4":
                    board[1,0] = symbol;
                    break;
                case "b5":
                    board[1,1] = symbol;
                    break;
                case "b6":
                    board[1,2] = symbol;
                    break;
                case "b7":
                    board[2,0] = symbol;
                    break;
                case "b8":
                    board[2,1] = symbol;
                    break;
                case "b9":
                    board[2,2] = symbol;
                    break;
                default:
                    break;
            }

        }

        private void checkColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if ( (board[0,i] == board[1,i])&&(board[1,i] == board[2,i]) )
                {
                    showWinMessage();
                    break;
                }
            }
        }

        private void checkRows()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i,0] == board[i,1]) && (board[i,1] == board[i,2]))
                {
                    showWinMessage();
                    break;
                }
            }
        }

        private void checkDiag()
        {
            if ((board[0,0] == board[1,1]) && (board[1,1] == board[2,2]))
            {
                showWinMessage();
            }else if ((board[0,2] == board[1,1]) && (board[1,1] == board[2,0]))
            {
                showWinMessage();
            }
        }

        private void showWinMessage()
        {
            if(symbol == "X")
            {
                label1.Text = "Player 1 WINS!";
            }else
            {
                label1.Text = "Player 2 WINS";
            }

            gameOver = true;
        }

        private void checkWin()
        {
            checkColumns();
            checkRows();
            checkDiag();
        }

    }
}
