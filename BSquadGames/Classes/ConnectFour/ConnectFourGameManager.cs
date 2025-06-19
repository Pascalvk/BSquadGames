using BSquadGames.Classes.Common;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourGameManager
    {
        
        public ConnectFourBoard ConnectFourBoard;
        private ConnectFourAI ConnectFourAI;

        public bool GameWon = false;
        public int GameWinner;
        public int[,] Grid => ConnectFourBoard.Grid;
        public List<(int, int)> ValidMoves => ConnectFourBoard.DiscPlacement;
        public Player Player1;
        public Player Player2;

        public bool IsAIActive = false;
        public bool IsAIStartActive = false;
        private bool LockGame = false;
        private int GameCount = 0;


        public int CurrentPlayer { get; set; }
        private int StartingPlayer = 1;

        public ConnectFourGameManager(Player player1, Player player2) 
        {
            ConnectFourBoard = new ConnectFourBoard();
            ConnectFourAI = new ConnectFourAI(this);
            CurrentPlayer = 1;
            Player1 = player1;
            Player2 = player2;
        }

        public void StartNewGame()
        {
            GameCount++;
            ConnectFourBoard.CreateNewBoard();
            CheckWinner(false);
            LockGame = false;
            ConnectFourBoard.GetListPossibleCellsToPlaceDiscAt();

            // Wissel startende speler
            if (StartingPlayer == 1)
            {
                StartingPlayer = 2;
            }
            else
            {
                StartingPlayer = 1;
            }

            CurrentPlayer = StartingPlayer;

            // Laat AI starten indien AI actief is én hij mag beginnen
            if (IsAIActive && CurrentPlayer == 2)
            {
                MakeAIMove();
            }


        }

        public void MakeMove((int, int) clickCords, bool isAIMove)
        {

            if (!LockGame)
            {
                if (ConnectFourBoard.DiscPlacement.Contains((clickCords.Item1, clickCords.Item2)))
                {
                    // Place disc for current player
                    ConnectFourBoard.SetDiscAt(clickCords.Item1, clickCords.Item2, CurrentPlayer);

                    CheckWinner(isAIMove);

                    if (!GameWon)
                    {
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
                    else
                    {
                        LockGame = true;
                    }
                }



            }

            // Update list of available placements
            ConnectFourBoard.GetListPossibleCellsToPlaceDiscAt();
        }


        /// <summary>
        /// Checks if either player has won the game.
        /// Updates the GameWon and GameWinner properties accordingly.
        /// </summary>
        public void CheckWinner(bool isAIMove)
        {
            // Check if player 1 has a winning combination
            if (ConnectFourBoard.CheckWin(1) == true)
            {
                GameWon = true;
                GameWinner = 1;
                if(!isAIMove)
                {
                    Player1.Score++;
                }
                

            }
            // If not, check if player 2 has won
            else if (ConnectFourBoard.CheckWin(2) == true)
            {
                GameWon = true;
                GameWinner = 2;

                if (!isAIMove)
                {
                    Player2.Score++;
                }

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
                MakeMove(bestMove, false);
            }
        }

        public int GetCellValue(int row, int col)
        {
            return Grid[row, col];
        }

        public ConnectFourGameManager DeepCopyManager()
        {
            ConnectFourGameManager copy = new ConnectFourGameManager(Player1, Player2);

            copy.CurrentPlayer = CurrentPlayer;

            copy.ConnectFourBoard = ConnectFourBoard.DeepCopy();

            return copy;
        }

    }
}
