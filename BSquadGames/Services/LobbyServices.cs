using BSquadGames.Classes.Common;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;


namespace BSquadGames.Services
{
    public class LobbyServices
    {
        private readonly Dictionary<string, Lobby> activeLobbies = new();
        private readonly IHubContext<LobbyHub> hubContext;

        public LobbyServices(IHubContext<LobbyHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        /*
        public Lobby CreateLobby(Guid lobbyHostID, Player player, int maxPlayers)
        {
            Lobby lobby = new Lobby(lobbyHostID, maxPlayers);
            if (lobby.AddPlayerToLobby(player))
            {
                activeLobbies[lobby.LobbyID] = lobby;
            }
            else
            {
                // To do
            }

            return lobby;
        }
        */
        public Lobby CreateLobby(Guid lobbyHostID, Player player, int maxPlayers)
        {
            Lobby lobby = new Lobby(lobbyHostID, maxPlayers);

            if (lobby.AddPlayer(player))
            {
                activeLobbies[lobby.LobbyID] = lobby;
            }
            else
            {
                return null;
            }

            return lobby;
        }

        public Lobby? GetLobby(string lobbyID)
        {

            activeLobbies.TryGetValue(lobbyID, out var lobby);
            return lobby;
            
        }

        public async Task<bool> JoinLobbyAsync(string lobbyID, Player player)
        {
            if (activeLobbies.TryGetValue(lobbyID, out var lobby))
            {
                if (lobby.AddPlayer(player))
                {
                    await hubContext.Clients.Group(lobbyID).SendAsync("LobbyUpdate");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;           
        }

        /*
        public async Task<bool> LeaveLobbyAsync(string lobbyId, Guid playerID)
        {
            if (activeLobbies.TryGetValue(lobbyId, out var lobby))
            {
                var removed = lobby.RemovePlayerFromLobby(playerID);

                // Als lobby leeg is, opruimen
                if (lobby.Players.Count == 0 || playerID == lobby.LobbyHostPlayerID)
                {
                    lobby.Players.Clear();
                    activeLobbies.Remove(lobbyId);
                }

                if (removed)
                {
                    // Stuur update naar alle clients in deze lobbygroep
                    await hubContext.Clients.Group(lobbyId).SendAsync("ReceiveLobbyUpdate");
                }

                return removed;
            }

            return false;
        }
        */

        public async Task<bool> LeaveLobbyAsync(string lobbyID, Guid playerID)
        {
            if (activeLobbies.TryGetValue(lobbyID, out Lobby lobby))
            {
                // If the lobby is empty or host leaves
                if (lobby.Players.Count == 0 || playerID == lobby.LobbyHostPlayerID)
                {
                    lobby.RemoveAllPlayers();
                    activeLobbies.Remove(lobbyID);
                    await hubContext.Clients.Group(lobbyID).SendAsync("LobbyUpdate");
                }
                else
                {
                    if (lobby.RemovePlayer(playerID))
                    {
                        // Send a message to all clients in the group someone left
                        await hubContext.Clients.Group(lobbyID).SendAsync("LobbyUpdate");
                    }
                }

                return true;
            }

            return false;
        }

        public bool StartGame(string lobbyId)
        {

            if (activeLobbies.TryGetValue(lobbyId, out var lobby))
            {
                if (lobby.CheckIsFull() && !lobby.GameStarted)
                {
                    lobby.GameStarted = true;
                    return true;
                }
            }

            return false;
            
        }

        public List<Lobby> GetAllLobbies()
        {

            return activeLobbies.Values.ToList();
            
        }

        public bool LobbyExists(string lobbyId)
        {

            return activeLobbies.ContainsKey(lobbyId);
            
        }

        public Lobby? GetLobbyForPlayer(Guid playerID)
        {
            return activeLobbies.Values.FirstOrDefault(lobby => lobby.ContainsPlayer(playerID));
        }

        public bool IsHostStillInLobby(string lobbyID)
        {
            if (activeLobbies.TryGetValue(lobbyID, out var lobby))
            {
                return lobby.Players.Any(p => p.ID == lobby.LobbyHostPlayerID);
            }

            return false;
        }
    }
}
