using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ante_up.Common.HubModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Data;
using ante_up.Logic;
using ante_up.Logic.JWT;
using Microsoft.AspNetCore.SignalR;

namespace ante_up.Hubs
{
    public class AnteHub : Hub
    {
        private readonly FriendLogic _friendLogic;
        private readonly AccountLogic _accountLogic;
        private readonly WagerLogic _wagerLogic;
        private readonly ChatLogic _chatLogic;

        public AnteHub(IAnteUpContext context)
        {
            _friendLogic = new FriendLogic(new AccountData(context), new FriendData(context));
            _accountLogic = new AccountLogic(new AccountData(context));
            _wagerLogic = new WagerLogic(new WagerData(context), new AccountData(context));
            _chatLogic = new ChatLogic(new WagerData(context), new AccountData(context), new ChatData(context),
                new FriendData(context));
        }

        public async Task CreateLobby(string lobbyId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyId);
        }

        public async Task Login(string token)
        {
            string accountId = JWTLogic.GetId(token);
            _accountLogic.SaveConnectionId(accountId, Context.ConnectionId);
        }

        public async Task Logout(string token)
        {
            string accountId = JWTLogic.GetId(token);
            _accountLogic.RemoveConnectionId(accountId, Context.ConnectionId);
        }

        public async Task JoinLobby(LobbyUser lobbyJoiner)
        {
            string userId = JWTLogic.GetId(lobbyJoiner.Token);
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyJoiner.Lobby);

            _wagerLogic.JoinTeam(userId,lobbyJoiner.Lobby, lobbyJoiner.Team);
            LobbyResponse lobbyJoin = new()
            {
                Player = _accountLogic.GetAccountById(userId)?.Username,
                Team = lobbyJoiner.Team
            };

            await Clients.Group(lobbyJoiner.Lobby).SendAsync("LobbyJoined", lobbyJoin);
        }

        public async Task LeaveLobby(LobbyUser lobbyLeaver)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyLeaver.Lobby);

            string userId = JWTLogic.GetId(lobbyLeaver.Token);
            Wager wager = _wagerLogic.GetWagerById(lobbyLeaver.Lobby);

            int wagerCount =  _wagerLogic.LeaveWager(wager.Id.ToString(), userId);

            if (wagerCount == 0)
            {
                await Clients.Caller.SendAsync("LobbyGone");
            }
            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = _accountLogic.GetAccountById(userId)?.Username
                };
                await Clients.Group(lobbyLeaver.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }

        public async Task KickPlayer(LobbyKick lobbyKick)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyKick.Lobby);
            Wager wager = _wagerLogic.GetWagerById(lobbyKick.Lobby);

            if (JWTLogic.GetId(lobbyKick.HostToken) == wager.HostId)
                _wagerLogic.LeaveWager(wager.Id.ToString(), lobbyKick.User);

            else
            {
                LobbyResponse lobbyLeave = new()
                {
                    Player = _accountLogic.GetAccountById(lobbyKick.User)?.Username
                };
                await Clients.Group(lobbyKick.Lobby).SendAsync("LobbyLeft", lobbyLeave);
                await Clients.Caller.SendAsync("YouLeft");
            }
        }

        public async Task SendFriendRequest(HubFriend hubFriend)
        {
            string accountId = JWTLogic.GetId(hubFriend.Token);
            string result = _friendLogic.FriendRequest(hubFriend.FriendName, accountId);

            if (result != FriendRequestResponses.Success.GetDescription())
                await Clients.Caller.SendAsync("AddFriendError", result);
            else
            {
                await Clients.Caller.SendAsync("Friendrequest Sent", hubFriend.FriendName);

                Account friend = _accountLogic.GetAccountByUserName(hubFriend.FriendName);
                foreach (string id in friend.GetConnectionIds())
                {
                    await Clients.User(id).SendAsync("Friendrequest Received");
                }
            }
        }

        public async Task SendFriendMessage(FriendMessage friendMessage)
        {
            string senderId = JWTLogic.GetId(friendMessage.Sender);

            _chatLogic.SendFriendMessage(friendMessage.Receiver, senderId, friendMessage.Message);
            await Clients.Caller.SendAsync("NewFriendMessage");
            foreach (string id in _accountLogic.GetAccountByUserName(friendMessage.Receiver).GetConnectionIds()!)
            {
                await Clients.User(id).SendAsync("NewFriendMessage");
            }
        }

        public async Task SendLobbyMessage(LobbyMessage lobbyMessage)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, lobbyMessage.LobbyId);
            _chatLogic.SendWagerMessage(lobbyMessage);
        
            await Clients.Group(lobbyMessage.LobbyId).SendAsync("NewLobbyMessage");
        }
    }
}