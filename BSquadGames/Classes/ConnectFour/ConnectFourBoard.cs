namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourBoard
    {
        public int Rows = 6;
        public int Columns = 7;
        const int WinLenght = 4;

        private int[,] grid;

        public ConnectFourBoard()
        {


            // Create 6x7 grid
            grid = new int[Rows, Columns];
        }

        // Check for 4 in a row, based on player number. empty = 0; player 1 = 1; player 2 = 2
        public bool CheckWin(int player)
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


            // Check diagonal


            return false;
        }

        public void SetDiscAt(int row, int col, int player)
        {
            grid[row, col] = player;
        }
    }
}
