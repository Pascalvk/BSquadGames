using BSquadGames.Classes.Common;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourGameManager
    {
        
        private ConnectFourBoard ConnectFourBoard;
        private ConnectFourAI ConnectFourAI;

        public int GameWinner => ConnectFourBoard.GameWinner;
        public bool GameWon => ConnectFourBoard.GameWon;
        public int[,] Grid => ConnectFourBoard.Grid;
        public List<(int, int)> ValidMoves => ConnectFourBoard.DiscPlacement;
        public Player player1;
        public Player player2;

        public bool IsAIActive = false;
        public bool IsAIStartActive = false;

        public int CurrentPlayer { get; set; }

        public ConnectFourGameManager() 
        {
             
            ConnectFourBoard = new ConnectFourBoard();
            ConnectFourAI = new ConnectFourAI(this);
            CurrentPlayer = 1;
            
        }

        public void StartNewGame()
        {
                     
            ConnectFourBoard.CreateNewBoard();
            ConnectFourBoard.CheckWinner();
            ConnectFourBoard.GetListPossibleCellsToPlaceDiscAt();

            if (IsAIStartActive)
            {
                CurrentPlayer = 2;
                MakeAIMove();
            }
            else
            {
                CurrentPlayer = 1;
            }


        }

        public void MakeMove((int, int) clickCords)
        {
                               
            if (ConnectFourBoard.DiscPlacement.Contains((clickCords.Item1, clickCords.Item2)))
            {
                // Place disc for current player
                ConnectFourBoard.SetDiscAt(clickCords.Item1, clickCords.Item2, CurrentPlayer);

                ConnectFourBoard.CheckWinner();

                // Switch to next player
                if (CurrentPlayer == 1)
                {
                    CurrentPlayer = 2;
                }
                else
                {
                    CurrentPlayer = 1;
                }

            }

            // Update list of available placements
            ConnectFourBoard.GetListPossibleCellsToPlaceDiscAt();
        }

        public void MakeAIMove()
        {
            
            (int, int) bestMove = ConnectFourAI.FindBestMove();
            
            if (IsAIActive)
            {
                MakeMove(bestMove);
            }
        }

        public int GetCellValue(int row, int col)
        {
            return Grid[row, col];
        }

        public ConnectFourGameManager DeepCopyManager()
        {
            ConnectFourGameManager copy = new ConnectFourGameManager();

            copy.CurrentPlayer = CurrentPlayer;

            copy.ConnectFourBoard = ConnectFourBoard.DeepCopy();

            return copy;
        }

    }
}
