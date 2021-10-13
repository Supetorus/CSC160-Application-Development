using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        
        public void Play()
        {

            char[,] board = new char[3, 3];
            int turn = 0;
            string[] players = new string[2];
            char[] symbols = { 'X', 'O' };
            int winner = -1;

            Console.WriteLine("Welcome to Tic Tac Toe.");
            Console.Write("Please enter the name of Player X: ");
            players[0] = Console.ReadLine();
            Console.Write("Please enter the name of Player O: ");
            players[1] = Console.ReadLine();
            ClearBoard(board);
            PrintBoard(board);

            bool gameOver = false;
            while (!gameOver)
            {
                int row = 0;
                int col = 0;
                bool invalidMove = true;
                while(invalidMove)
                {
                    row = Prompt(players[turn] + " please input a row: ", 1, 3) - 1;
                    col = Prompt(players[turn] + " please input a column: ", 1, 3) - 1;
                    if (board[row, col] != ' ') Console.WriteLine("That space is already taken, try again.");
                    else invalidMove = false;
                }
                board[row, col] = symbols[turn];
                PrintBoard(board);
                winner = turn;
                gameOver = IsWinGame(board) || IsCatsGame(board);
                turn = turn == 0 ? 1 : 0;
            }
            if (IsWinGame(board)) Console.WriteLine("The winner is {0}!", players[winner]);
            else Console.WriteLine("It's a cat's game.");
        }


        private void ClearBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) board[i, j] = ' ';
            }
        }

        /*private bool IsCatsGame(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ') return false;
                }
            }
            return true;
        }*/

        private bool IsCatsGame(char[,] board)
        {
            // Check for horizontal ties.
            int horizontalTies = 0;
            for (int row = 0; row < 3; row++)
            {
                bool hasX = false;
                bool hasO = false;
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == 'X') hasX = true;
                    if (board[row, col] == 'O') hasO = true;
                    if (hasX && hasO) horizontalTies++;
                }
            }

            // Check for vertical ties
            int verticalTies = 0;
            for (int col = 0; col < 3; col++)
            {
                bool hasX = false;
                bool hasO = false;
                for (int row = 0; row < 3; row++)
                {
                    if (board[col, row] == 'X') hasX = true;
                    if (board[col, row] == 'O') hasO = true;
                    if (hasX && hasO) verticalTies++;
                }
            }

            // Check descending diagonal validity
            bool descendingDiagonalInvalid = false;
            bool descendingDiagonalHasX = false;
            bool descendingDiagonalHasO = false;
            for (int i = 0; i < 3; i++)
            {
                if (board[i, i] == 'X') descendingDiagonalHasX = true;
                if (board[i, i] == 'O') descendingDiagonalHasO = true;
            }
            if (descendingDiagonalHasX && descendingDiagonalHasO) descendingDiagonalInvalid = true;

            // Check ascending diagonal validity
            bool ascendingDiagonalInvalid = false;
            bool ascendingDiagonalHasX = false;
            bool ascendingDiagonalHasO = false;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 2; col > -1; col--)
                {
                    if (board[row, col] == 'X') ascendingDiagonalHasX = true;
                    if (board[row, col] == 'O') ascendingDiagonalHasO = true;
                }
            }
            if (ascendingDiagonalHasX && ascendingDiagonalHasO) ascendingDiagonalInvalid = true;

            return (horizontalTies >= 3) || (verticalTies >= 3) || descendingDiagonalInvalid || ascendingDiagonalInvalid;
        }

        private bool IsWinGame(char[,] board)
        {
            char checkSymbol;
            // check verticals
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != ' ')
                {
                    checkSymbol = board[0, i];
                    if (board[1, i] == checkSymbol && board[2, i] == checkSymbol)
                    {
                        return true;
                    }
                }
            }
            // check horizontals
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ')
                {
                    checkSymbol = board[i, 0];
                    if (board[i, 1] == checkSymbol && board[i, 2] == checkSymbol)
                    {
                        return true;
                    }
                }
            }
            // check diagonals
            if (board[0, 0] != ' ')
            {
                checkSymbol = board[0, 0];
                if (board[1, 1] == checkSymbol && board[2, 2] == checkSymbol)
                {
                    return true;
                }
            }
            if (board[0, 2] != ' ')
            {
                checkSymbol = board[0, 2];
                if (board[1, 1] == checkSymbol && board[2, 0] == checkSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        private int Prompt(string prompt, int min, int max)
        {
            int returned = 0;
            bool invalidInput = true;
            while (invalidInput)
            {
                Console.Write(prompt);
                int.TryParse(Console.ReadLine(), out returned);
                if (returned >= min && returned <= max) invalidInput = false;
                else Console.WriteLine("Invalid input, try again.");
            }
            return returned;
        }

        private void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write(" | ");
                }
                Console.Write("\n");
                if (i < 2) Console.WriteLine("---------");
            }
        }

        public bool TestCatsGame()
        {
            char[,] board;
            /* board = new char[3, 3] 
            {
                { 'A', 'B', 'C' },
                { 'D', 'E', 'F' },
                { 'G', 'H', 'I' }
            };
            return IsCatsGame(board);*/
            bool failed = false;
            board = new char[3, 3]
                {
                    {'X', 'O', 'O'},
                    {'O', ' ', 'X'},
                    {'X', 'X', 'O'}
                };
            if (!IsCatsGame(board)) failed = true;

            board = new char[3, 3]
                {
                    {'X', ' ', 'O'},
                    {'O', ' ', 'X'},
                    {'X', ' ', 'O'}
                };

            return !failed;
        }

        public bool TestWins()
        {
            char[,] board = new char[3, 3];
            board = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { 'X', ' ', ' ' },
                { 'X', ' ', ' ' }
            };
            if (!IsWinGame(board))
            {
                Console.WriteLine("Fail on columns");
                PrintBoard(board);
                return false;
            }

            board = new char[3, 3]
            {
                { 'X', 'X', 'X' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
            if (!IsWinGame(board))
            {
                Console.WriteLine("Fail on rows");
                PrintBoard(board);
                return false;
            }

            board = new char[3, 3]
            {
                { 'X', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', 'X' }
            };
            if (!IsWinGame(board))
            {
                Console.WriteLine("Fail on descending diagonal");
                PrintBoard(board);
                return false;
            }

            board = new char[3, 3]
            {
                { ' ', ' ', 'X' },
                { ' ', 'X', ' ' },
                { 'X', ' ', ' ' }
            };
            if (!IsWinGame(board))
            {
                Console.WriteLine("Fail on ascending diagonal");
                PrintBoard(board);
                return false;
            }

            return true;
        }
    }
}