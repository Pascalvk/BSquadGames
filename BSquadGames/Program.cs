using BSquadGames.Classes.Common;
using BSquadGames.Components;
using BSquadGames.Services;

namespace BSquadGames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSignalR();
            builder.Services.AddSingleton<ConnectFourGameServices>();
            builder.Services.AddSingleton<LobbyServices>();
            builder.Services.AddScoped<PlayerStateServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapHub<ChatHub>("/chathub");
            app.MapHub<LobbyHub>("/lobbyhub");

            app.Run();
        }
    }
}
