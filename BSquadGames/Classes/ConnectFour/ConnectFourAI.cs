using Microsoft.AspNetCore.Routing.Constraints;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourAI
    {
        private ConnectFourGameManager GameManager;

        public ConnectFourAI(ConnectFourGameManager gameManager)
        {
            GameManager = gameManager;
        }

        public void MakeAnAIMove()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 6);

            (int, int) moveToMake = GameManager.ValidMoves[randomNumber];
            GameManager.MakeMove(moveToMake);
        }

        public void MakeAnAIMove2()
        {
            (int, int) moveToMake = FindBestMove();
            GameManager.MakeMove(moveToMake);
        }


        public (int, int) FindBestMove()
        {
            int alpha = int.MinValue;
            int beta = int.MaxValue;
            int bestScore = int.MinValue;
            (int, int) bestMove = (-1, -1);

            // If the AI can win in 1 move it will
            foreach (var move in GameManager.ValidMoves)
            {
                var copy = GameManager.DeepCopyManager();
                copy.MakeMove(move);

                if (copy.GameWon && copy.GameWinner == 2) 
                {
                    return move; 
                }
            }

            // Else does the minmax Algorithm
            foreach (var move in GameManager.ValidMoves)
            {
                ConnectFourGameManager copy = GameManager.DeepCopyManager();
                copy.MakeMove(move);

                int score = MinMaxAlgorithm(copy, 1, alpha, beta, 2);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        // Not writing this ever again lol ~Pascalvk
        public int MinMaxAlgorithm(ConnectFourGameManager copyManager, int currentPlayer, int alpha, int beta, int depth)
        {
            if (depth == 0 || copyManager.GameWon)
            {
                if (copyManager.GameWon)
                {
                    // Ai win
                    if (copyManager.GameWinner == 2) 
                        return 1000000;
                    // Human win
                    else if (copyManager.GameWinner == 1) 
                        return -1000000;
                    else
                        return 0;
                }
                else
                {
                    return EvaluateBoard(copyManager.Grid, 2); 
                }
            }

            // MAX AI player ; player 2
            if (currentPlayer == 2) 
            {
                int maxEval = int.MinValue;
                foreach (var move in copyManager.ValidMoves)
                {
                    var childCopy = copyManager.DeepCopyManager();
                    childCopy.MakeMove(move);
                    int eval = MinMaxAlgorithm(childCopy, 1, alpha, beta, depth - 1);
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha) break;
                }
                return maxEval;
            }
            // MIN Human player ; player 1
            else 
            {
                int minEval = int.MaxValue;
                foreach (var move in copyManager.ValidMoves)
                {
                    var childCopy = copyManager.DeepCopyManager();
                    childCopy.MakeMove(move);
                    int eval = MinMaxAlgorithm(childCopy, 2, alpha, beta, depth - 1);
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha) break;
                }
                return minEval;
            }
        }

        public int EvaluateBoard(int[,] grid, int currentPlayer)
        {
            int score = 0;
            int opponent = currentPlayer == 1 ? 2 : 1;
            int Rows = grid.GetLength(0);
            int Columns = grid.GetLength(1);

            // Horizontal
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j <= Columns - 4; j++)
                {
                    int[] window = new int[4];
                    for (int k = 0; k < 4; k++)
                    {
                        window[k] = grid[i, j + k];
                    }
                    score += EvaluateWindow(window, currentPlayer, opponent);
                }
            }

            // Vertical
            for (int i = 0; i <= Rows - 4; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int[] window = new int[4];
                    for (int k = 0; k < 4; k++)
                        window[k] = grid[i + k, j];
                    score += EvaluateWindow(window, currentPlayer, opponent);
                }
            }

            // Diagonal /
            for (int i = 0; i <= Rows - 4; i++)
            {
                for (int j = 0; j <= Columns - 4; j++)
                {
                    int[] window = new int[4];
                    for (int k = 0; k < 4; k++)
                        window[k] = grid[i + k, j + k];
                    score += EvaluateWindow(window, currentPlayer, opponent);
                }
            }

            // Diagonal \
            for (int i = 0; i <= Rows - 4; i++)
            {
                for (int j = 3; j < Columns; j++)
                {
                    int[] window = new int[4];
                    for (int k = 0; k < 4; k++)
                        window[k] = grid[i + k, j - k];
                    score += EvaluateWindow(window, currentPlayer, opponent);
                }
            }

            // Central Column bonus points = better?
            int centerColumn = Columns / 2;
            int centerCount = 0;
            for (int i = 0; i < Rows; i++)
            {
                if (grid[i, centerColumn] == currentPlayer)
                    centerCount++;
            }
            score += centerCount * 6;

            return score;
        }

        // Evaluateion points based on the amount of disc a player has in a row of 4.
        private int EvaluateWindow(int[] window, int currentPlayer, int opponent)
        {
            int playerCount = window.Count(cell => cell == currentPlayer);
            int opponentCount = window.Count(cell => cell == opponent);
            int emptyCount = window.Count(cell => cell == 0);

            if (playerCount == 4)
                return 10000;
            else if (playerCount == 3 && emptyCount == 1)
                return 100;
            else if (playerCount == 2 && emptyCount == 2)
                return 10;
            else if (opponentCount == 3 && emptyCount == 1)
                return -80;
            else if (opponentCount == 4)
                return -10000;

            return 0;
        }
    }
}
