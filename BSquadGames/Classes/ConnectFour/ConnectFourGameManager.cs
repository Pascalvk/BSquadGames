using BSquadGames.Classes.Common;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourGameManager
    {
        
        private ConnectFourBoard ConnectFourBoard;
        private ConnectFourAI ConnectFourAI;

        public bool GameWon = false;
        public int GameWinner;
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
            CheckWinner();
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

                CheckWinner();

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


        /// <summary>
        /// Checks if either player has won the game.
        /// Updates the GameWon and GameWinner properties accordingly.
        /// </summary>
        public void CheckWinner()
        {
            // Check if player 1 has a winning combination
            if (ConnectFourBoard.CheckWin(1) == true)
            {
                GameWon = true;
                GameWinner = 1;
                Player.player1Score++;

            }
            // If not, check if player 2 has won
            else if (ConnectFourBoard.CheckWin(2) == true)
            {
                GameWon = true;
                GameWinner = 2;
                Player.player2Score++;

            }
            // If neither player has won, the game is still ongoing or a draw
            else
            {
                GameWon = false;
                GameWinner = 0;

            }

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
