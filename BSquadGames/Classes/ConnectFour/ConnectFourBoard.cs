namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourBoard
    {
        public int Rows = 6;
        public int Columns = 7;
        const int WinLenght = 4;
        public bool GameWon = false;
        public int GameWinner;

        public int[,] grid;

        public ConnectFourBoard()
        {
            // Create 6x7 grid
            grid = new int[Rows, Columns];
        }

        // Check for 4 in a row, based on player number. empty = 0; player 1 = 1; player 2 = 2
        private bool CheckWin(int player)
        {
            // Check horizontal
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j <= Columns - WinLenght; j++)
                {
                    if (grid[i, j] == player && grid[i, j + 1] == player && grid[i, j + 2] == player && grid[i, j + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check vertical
            for (int i = 0; i <= Rows - WinLenght; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (grid[i, j] == player && grid[i + 1, j] == player && grid[i + 2, j] == player && grid[i + 3, j] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal


            return false;
        }

        public void SetDiscAt(int row, int col, int player)
        {
            grid[row, col] = player;
        }

        public void StartNewGame()
        {
            grid = new int[Rows, Columns];
        }

        public void CheckWinner()
        {
            if (CheckWin(1) == true)
            {
                GameWon = true;
                GameWinner = 1;
            }
            else if (CheckWin(2) == true)
            {
                GameWon = true;
                GameWinner = 2;
            }
            else
            {
                GameWon = false;
                GameWinner = 0;
            }
        }

    }
}
