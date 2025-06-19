using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BSquadGames.Classes.Common
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
