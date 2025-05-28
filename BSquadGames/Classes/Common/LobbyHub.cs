using Microsoft.AspNetCore.SignalR;

namespace BSquadGames.Classes.Common
{
    public class LobbyHub : Hub
    {

        public async Task UpdateLobby(string lobbyID)
        {
            await Clients.Group(lobbyID).SendAsync("LobbyUpdate");
        }

        public async Task JoinLobbyGroup(string lobbyID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyID);
        }

        public async Task LeaveLobbyGroup(string lobbyID)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyID);
        }


    }
}
