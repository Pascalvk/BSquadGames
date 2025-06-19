using BSquadGames.Classes.Common;
using BSquadGames.Classes.ConnectFour;

namespace BSquadGames.Services
{
    public class ConnectFourGameServices
    {
        private readonly Dictionary<string, ConnectFourGame> activeGames = new();

        public ConnectFourGame CreateGame(string lobbyID,Player player1, Player player2)
        {
            ConnectFourGame game = new(lobbyID, player1, player2);
            activeGames[game.GameID] = game;

            return game;
        }

        public ConnectFourGame? GetGame(string gameID)
        {
            activeGames.TryGetValue(gameID, out ConnectFourGame game);
            return game;
        }

        public List<ConnectFourGame> GetAllGames()
        {
            return activeGames.Values.ToList();
        }

    }
}
