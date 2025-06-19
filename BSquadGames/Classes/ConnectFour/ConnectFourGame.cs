using BSquadGames.Classes.Common;

namespace BSquadGames.Classes.ConnectFour
{
    public class ConnectFourGame
    {
        public string GameID { get; set; }
        public string LobbyID { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public ConnectFourGameManager Manager { get; set; }

        public ConnectFourGame(string lobbyID, Player player1, Player player2)
        {
            LobbyID = lobbyID;
            Player1 = player1;
            Player2 = player2;
            Manager = new(player1, player2);

            string GUID = Guid.NewGuid().ToString();
            if (player2.Name == "AI_BOT_DONT_CHANGE_THIS_NAME")
            {
                GameID = "BOT_GAME_" + GUID;
            }
            else
            {
                GameID = GUID;
            }

        }
    }
}
