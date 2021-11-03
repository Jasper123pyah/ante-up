using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;
using ante_up.Data;
using ante_up.Logic;
using ante_up.Logic.JWT;
using Microsoft.AspNetCore.SignalR;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ante_up.Hubs
{
    public class AnteHub : Hub
    {
        private readonly AnteUpContext _anteUpContext;
        private readonly JWTLogic _jwtLogic;
        private readonly AccountData _accountData;
        private readonly WagerData _wagerData;
        private readonly ChatData _chatData;
        private readonly FriendData _friendData;
        public AnteHub(AnteUpContext context)
        {
            _anteUpContext = context;
            _jwtLogic = new JWTLogic();
            _accountData = new AccountData(context);
            _wagerData = new WagerData(context);
            _chatData = new ChatData(context);
            _friendData = new FriendData(context);
        }
        public async Task CreateLobby(LobbyUser lobbyJoiner)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyJoiner.Lobby);
        }

        public async Task Login(string token)
        {
            string accountId = _jwtLogic.GetId(token);
            _accountData.SaveConnectionId(Context.ConnectionId, accountId);
        }
        public async Task Logout(string token)
        {
            string accountId = _jwtLogic.GetId(token);
            _accountData.RemoveConnectionId(Context.ConnectionId, accountId);
        }
        public async Task JoinLobby(LobbyUser lobbyJoiner)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,  lobbyJoiner.Lobby);
            
            _wagerData.JoinTeam(lobbyJoiner.Lobby, lobbyJoiner.User, lobbyJoiner.Team);
            LobbyResponse lobbyJoin = new()
            {
                Player = _accountData.GetAccountById(lobbyJoiner.User)?.Username,
                Team = lobbyJoiner.Team
            };
            
            await Clients.Group(lobbyJoiner.Lobby).SendAsync("LobbyJoined", lobbyJoin);
        }

        public async Task LeaveLobby(LobbyUser lobbyLeaver)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyLeaver.Lobby);
            
            _wagerData.LeaveWager(lobbyLeaver.Lobby, lobbyLeaver.User);
            
            if (new WagerLogic(_anteUpContext).GetWagerById(lobbyLeaver.Lobby) == null)
            {
                await Clients.Caller.SendAsync("LobbyGone");
            }
            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = _accountData.GetAccountById(lobbyLeaver.User)?.Username
                };
                await Clients.Group(lobbyLeaver.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }
        public async Task SendFriendRequest(HubFriend hubFriend)
        {
            string accountId = _jwtLogic.GetId(hubFriend.Token);
            string result = _friendData.FriendRequest(hubFriend.FriendName, accountId);
            
            if (result == "Person not found" ||
                result == "Already friends" ||
                result == "Person already added" ||
                result == "Can't add yourself as friend")
                await Clients.Caller.SendAsync("AddFriendError", result);
            else
            {
                await Clients.Caller.SendAsync("Friendrequest Sent", hubFriend.FriendName);
                foreach (string id in _accountData.GetConnectionIds(result))
                {
                    await Clients.User(id).SendAsync("Friendrequest Received");
                }
            }
        }
        public async Task SendFriendMessage(FriendMessage friendMessage)
        {
            string senderId = _jwtLogic.GetId(friendMessage.Sender);
            
            _chatData.SendFriendMessage(friendMessage.Receiver, senderId, friendMessage.Message);
            await Clients.Caller.SendAsync("NewFriendMessage");
            foreach (string id in _accountData.GetConnectionIds(_accountData.GetAccountIdByUsername(friendMessage.Receiver)!))
            {
                await Clients.User(id).SendAsync("NewFriendMessage");
            }
        }
        public async Task SendLobbyMessage(LobbyMessage lobbyMessage)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyMessage.LobbyId);
            _chatData.SendLobbyMessage(lobbyMessage);

            await Clients.Group(lobbyMessage.LobbyId).SendAsync("NewLobbyMessage");
        }
    }
}