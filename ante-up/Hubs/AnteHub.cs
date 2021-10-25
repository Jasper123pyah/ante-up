using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;
using ante_up.Data;
using ante_up.Logic;
using Microsoft.AspNetCore.SignalR;

namespace ante_up.Hubs
{
    public class AnteHub : Hub
    {
        private readonly AnteUpContext _anteUpContext;
        
        public AnteHub(AnteUpContext context)
        {
            _anteUpContext = context;
        }
        public async Task CreateLobby(LobbyUser lobbyJoiner)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyJoiner.Lobby);
        }
        
        public async Task JoinLobby(LobbyUser lobbyJoiner)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,  lobbyJoiner.Lobby);
            
            new WagerData(_anteUpContext).JoinTeam(lobbyJoiner.Lobby, lobbyJoiner.User, lobbyJoiner.Team);
            LobbyResponse lobbyJoin = new()
            {
                Player = new AccountData(_anteUpContext).GetAccountById(lobbyJoiner.User).Username,
                Team = lobbyJoiner.Team
            };
            
            await Clients.Group(lobbyJoiner.Lobby).SendAsync("LobbyJoined", lobbyJoin);
        }

        public async Task LeaveLobby(LobbyUser lobbyLeaver)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyLeaver.Lobby);
            
            new WagerData(_anteUpContext).LeaveWager(lobbyLeaver.Lobby, lobbyLeaver.User);
            
            if (new WagerLogic(_anteUpContext).GetWagerById(lobbyLeaver.Lobby) == null)
            {
                await Clients.Caller.SendAsync("LobbyGone");
            }
            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = new AccountData(_anteUpContext).GetAccountById(lobbyLeaver.User).Username
                };
                await Clients.Group(lobbyLeaver.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }
        
        public async Task SendMessage(LobbyMessage lobbyMessage)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyMessage.LobbyId);
            new ChatData(_anteUpContext).SendMessage(lobbyMessage);

            await Clients.Group(lobbyMessage.LobbyId).SendAsync("NewMessage");
        }
    }
}