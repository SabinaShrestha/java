using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char player = 'X';
            bool gameEnd = false;
            int movesPlayed = 0;
            char[,] board = new char[3, 3];
            initialize(board);
            print(board);

            while (gameEnd == false)
            {
                Console.Clear();
                print(board);

                Console.WriteLine("Please choose the position.");
                Console.WriteLine("Please enter row.");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter column.");
                int col = Convert.ToInt32(Console.ReadLine());

                board[row, col] = player;
                checkWin(player, board, gameEnd);
                movesPlayed = movesPlayed + 1;
                clearPosition(movesPlayed, board);
                player = changeTurn(player);
            }
        }

        static void clearPosition(int movesPlayed, char[,] board)
        {
            if (movesPlayed >= 8)
            {
                Random num = new Random();
                int rownum = num.Next(0, 3);
                int colnum = num.Next(0, 3);
                board[rownum, colnum] = ' ';
            }
        }

        static void checkWin(char player, char[,] board, bool gameEnd)
        {
            if ((player == board[0,0] && player == board[0,1] && player == board[0,2]) ||
                (player == board[1,0] && player == board[1,1] && player == board[1,2]) ||
                (player == board[2,0] && player == board[2,1] && player == board[2,2]) ||
                (player == board[0,0] && player == board[1,0] && player == board[2,0]) ||
                (player == board[0,1] && player == board[1,1] && player == board[2,1]) ||
                (player == board[0,2] && player == board[1,2] && player == board[2,2]) ||
                (player == board[0,0] && player == board[1,1] && player == board[2,2]) ||
                (player == board[0,2] && player == board[1,1] && player == board[2,0]))
            {
                Console.WriteLine(player + " has won the game!");
                Console.ReadKey();
                gameEnd = true;
            }
        }

        static char changeTurn(char currentPlayer)
        {
            if (currentPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }

        static void initialize(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void print(char[,] board)
        {
            Console.WriteLine("  | 0 | 1 | 2 |");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " | ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}
