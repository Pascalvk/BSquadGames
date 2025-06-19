namespace BSquadGames.Classes.Common
{
    public class Lobby
    {
        public Guid LobbyHostPlayerID {  get; set; }
        public string LobbyID { get; set; }
        public List<Player> Players {  get; set; }
        public bool GameStarted { get; set; }
        public int MaxPlayers { get; set; }


        public Lobby(Guid lobbyHostPlayerID, int maxPlayers)
        {
            LobbyHostPlayerID = lobbyHostPlayerID;
            LobbyID = Guid.NewGuid().ToString();
            Players = new();
            GameStarted = false;
            MaxPlayers = maxPlayers;
        }


        public bool AddPlayer(Player player)
        {
            
            if (Players.Count >= MaxPlayers)
            {
                return false;
            }

            if (Players.Any(p => p.ID == player.ID))
            {
                return false;
            }

            Players.Add(player);
            return true;
        }

        public bool RemovePlayer(Guid playerId)
        {
            if (Players.Count() != 0)
            {
                Player player = Players.FirstOrDefault(p => p.ID == playerId);
                if (player != null)
                {
                    Players.Remove(player);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAllPlayers()
        {
            if (Players.Count() != 0)
            {
                Players.Clear();
                return true;
            }
            return false;
        }

        public bool CheckIsFull()
        {
            return Players.Count >= MaxPlayers;
        }

        public bool ContainsPlayer(Guid playerId)
        {
            return Players.Any(p => p.ID == playerId);
        }

    }
}
