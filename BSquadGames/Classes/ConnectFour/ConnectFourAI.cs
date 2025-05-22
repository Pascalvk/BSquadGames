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
    }
}
