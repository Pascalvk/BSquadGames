namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourBoard
    {
        public int Rows = 6;
        public int Columns = 7;
        const int WinLenght = 4;
        public bool GameWon = false;
        public int GameWinner;
        public List<(int, int)> DiscPlacement = new();

        public int[,] grid;

        public ConnectFourBoard()
        {
            // Create 6x7 grid
            grid = new int[Rows, Columns];
        }

        /// <summary>
        /// Checks if the given player has four discs in a row.
        /// Returns true if the player has won; otherwise, false.
        /// Values in the grid: 0 = empty, 1 = player 1, 2 = player 2
        /// </summary>
        /// <param name="player"></param>
        /// <returns>bool</returns>
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

            // Check diagonal left up \
            for (int i = 0; i <= Rows - WinLenght; i++)
            {
                for (int j = 0; j <= Columns - WinLenght; j++)
                {
                    if (grid[i, j] == player && grid[i + 1, j + 1] == player && grid[i + 2, j + 2] == player && grid[i + 3, j + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal richt up /
            for (int i = 0; i <= Rows - WinLenght; i++)
            {
                for (int j = WinLenght - 1; j < Columns ; j++)
                {
                    if (grid[i, j] == player && grid[i + 1, j - 1] == player && grid[i + 2, j - 2] == player && grid[i + 3, j - 3] == player)
                    {
                        return true;
                    }
                }
            }

            // No winning pattern found
            return false;
        }

        public void SetDiscAt(int row, int col, int player)
        {
            if (grid[row, col] == 0)
            {
                grid[row, col] = player;
            }
            
            
        }

        public void StartNewGame()
        {
            grid = new int[Rows, Columns];
        }

        /// <summary>
        /// Checks if either player has won the game.
        /// Updates the GameWon and GameWinner properties accordingly.
        /// </summary>
        public void CheckWinner()
        {
            // Check if player 1 has a winning combination
            if (CheckWin(1) == true)
            {
                GameWon = true;
                GameWinner = 1;
            }
            // If not, check if player 2 has won
            else if (CheckWin(2) == true)
            {
                GameWon = true;
                GameWinner = 2;
            }
            // If neither player has won, the game is still ongoing or a draw
            else
            {
                GameWon = false;
                GameWinner = 0;

            }
            
        }


        /// <summary>
        /// Determines all valid cells where a new disc can legally be placed,
        /// following gravity rules in Connect Four.
        /// </summary>
        public void GetListPossibleCellsToPlaceDiscAt()
        {
            // Clear the current list of possible disc placements
            DiscPlacement.Clear();

            // Loop through all rows and columns of the grid
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {

                    // Check if it's the bottom row (discs can always be placed there if empty)
                    if (i == Rows - 1)
                    {
                        if(grid[i, j] == 0)
                        {
                            // Add cell to list if it's empty
                            DiscPlacement.Add((i, j));
                        }
                        
                    }
                    else
                    {
                        // Check if the cell below is filled and the current cell is empty
                        // (This is where a disc would land)
                        if (grid[i + 1, j] != 0 && grid[i, j] == 0)
                        {
                            // Add valid placement cell
                            DiscPlacement.Add((i, j));
                        }
                    }

                }
            }

        }

    }
}
