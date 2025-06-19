using BSquadGames.Classes.Common;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourBoard
    {
        public int Rows = 6;
        public int Columns = 7;
        const int WinLenght = 4;
        public List<(int, int)> DiscPlacement = new();

        public int[,] Grid;

        public ConnectFourBoard()
        {
            // Create 6x7 grid
            Grid = new int[Rows, Columns];
        }

        /// <summary>
        /// Checks if the given player has four discs in a row.
        /// Returns true if the player has won; otherwise, false.
        /// Values in the grid: 0 = empty, 1 = player 1, 2 = player 2
        /// </summary>
        /// <param name="player"></param>
        /// <returns>bool</returns>
        public bool CheckWin(int player)
        {
            // Check horizontal
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j <= Columns - WinLenght; j++)
                {
                    if (Grid[i, j] == player && Grid[i, j + 1] == player && Grid[i, j + 2] == player && Grid[i, j + 3] == player)
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
                    if (Grid[i, j] == player && Grid[i + 1, j] == player && Grid[i + 2, j] == player && Grid[i + 3, j] == player)
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
                    if (Grid[i, j] == player && Grid[i + 1, j + 1] == player && Grid[i + 2, j + 2] == player && Grid[i + 3, j + 3] == player)
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
                    if (Grid[i, j] == player && Grid[i + 1, j - 1] == player && Grid[i + 2, j - 2] == player && Grid[i + 3, j - 3] == player)
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
            if (Grid[row, col] == 0)
            {
                Grid[row, col] = player;
            }
            
            
        }

        public void CreateNewBoard()
        {
            Grid = new int[Rows, Columns];
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
                        if(Grid[i, j] == 0)
                        {
                            // Add cell to list if it's empty
                            DiscPlacement.Add((i, j));
                        }
                        
                    }
                    else
                    {
                        // Check if the cell below is filled and the current cell is empty
                        // (This is where a disc would land)
                        if (Grid[i + 1, j] != 0 && Grid[i, j] == 0)
                        {
                            // Add valid placement cell
                            DiscPlacement.Add((i, j));
                        }
                    }

                }
            }

        }

        public ConnectFourBoard DeepCopy()
        {
            ConnectFourBoard copy = new ConnectFourBoard();
            copy.Rows = Rows;
            copy.Columns = Columns;

            copy.Grid = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    copy.Grid[i, j] = Grid[i, j];

            copy.DiscPlacement = new List<(int, int)>(DiscPlacement);

            return copy;
        }

    }
}
