namespace BSquadGames.Classes.Common
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public static int player1Score { get; set; }
        public static int player2Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            player1Score = 0;
            player2Score = 0;
        }

    }
}
