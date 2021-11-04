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

namespace ante_up.Hubs
{
    public class AnteHub : Hub
    {
        private readonly AnteUpContext _anteUpContext;
        private readonly JWTLogic _jwtLogic;
        private readonly AccountData _accountData;
        private readonly WagerData _wagerData;
        private readonly ChatData _chatData;
        private readonly FriendLogic _friendLogic;
        public AnteHub(AnteUpContext context)
        {
            _anteUpContext = context;
            _jwtLogic = new JWTLogic();
            _accountData = new AccountData(context);
            _wagerData = new WagerData(context);
            _chatData = new ChatData(context);
            _friendLogic = new FriendLogic(context);
        }
        public async Task CreateLobby(string lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId);
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
            string userId = _jwtLogic.GetId(lobbyJoiner.Token);
            await Groups.AddToGroupAsync(Context.ConnectionId,  lobbyJoiner.Lobby);
            
            _wagerData.JoinTeam(lobbyJoiner.Lobby, userId, lobbyJoiner.Team);
            LobbyResponse lobbyJoin = new()
            {
                Player = _accountData.GetAccountById(userId)?.Username,
                Team = lobbyJoiner.Team
            };
            
            await Clients.Group(lobbyJoiner.Lobby).SendAsync("LobbyJoined", lobbyJoin);
        }

        public async Task LeaveLobby(LobbyUser lobbyLeaver)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyLeaver.Lobby);

            string userId = _jwtLogic.GetId(lobbyLeaver.Token);
            _wagerData.LeaveWager(_wagerData.GetById(lobbyLeaver.Lobby),userId);
            
            if (_wagerData.GetById(lobbyLeaver.Lobby) == null)
            {
                await Clients.Caller.SendAsync("LobbyGone");
            }
            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = _accountData.GetAccountById(userId)?.Username
                };
                await Clients.Group(lobbyLeaver.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }
        public async Task KickPlayer(LobbyKick lobbyKick)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyKick.Lobby);
            Wager wager = _wagerData.GetById(lobbyKick.Lobby);
            
            if(_jwtLogic.GetId(lobbyKick.HostToken) == wager.HostId)
                 _wagerData.LeaveWager(wager, lobbyKick.User);
            
            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = _accountData.GetAccountById(lobbyKick.User)?.Username
                };
                await Clients.Group(lobbyKick.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }
        public async Task SendFriendRequest(HubFriend hubFriend)
        {
            string accountId = _jwtLogic.GetId(hubFriend.Token);
            string result = _friendLogic.FriendRequest(hubFriend.FriendName, accountId);
            
            if (result != FriendRequestResponses.Success.GetDescription())
                await Clients.Caller.SendAsync("AddFriendError", result);
            else
            {
                await Clients.Caller.SendAsync("Friendrequest Sent", hubFriend.FriendName);
                string friendId = _accountData.GetAccountIdByUsername(hubFriend.FriendName);
                Account friend = _accountData.GetAccountById(friendId);
                foreach (string id in friend.GetConnectionIds())
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
            foreach (string id in _accountData.GetAccountById(_accountData.GetAccountIdByUsername(friendMessage.Receiver))?.GetConnectionIds()!)
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