using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Data;
using ante_up.Logic;
using ante_up.Logic.JWT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AnteUpContext _anteUpContext;
        private readonly JWTLogic _jwtLogic;
        private readonly AccountData _accountData;
        private readonly AccountLogic _accountLogic;
        private readonly FriendData _friendData;
        private readonly FriendLogic _friendLogic;
        public AccountController(AnteUpContext context)
        {
            _anteUpContext = context;
            _jwtLogic = new JWTLogic();
            _accountData = new AccountData(context);
            _accountLogic = new AccountLogic(context);
            _friendData = new FriendData(context);
            _friendLogic = new FriendLogic(context);
        }
        
        [HttpPost("/account/register")]
        public string Register(ApiAccount newAccount)
        {
            return _accountLogic.Register(newAccount);;
        }

        [HttpGet("/account/friends/{token}")]
        public List<string> GetFriends(string token)
        {
            string id = _jwtLogic.GetId(token);
            return _friendData.GetFriends(id);
        }
        [HttpGet("/account/friend/chat")]
        public Chat GetFriendChat(ApiFriendChat apiFriendChat)
        {
            string accountId = _jwtLogic.GetId(apiFriendChat.Token);
            Chat chat = new ChatData(_anteUpContext).GetFriendChat(apiFriendChat.FriendName, accountId);
            chat.SortByTime();
            return chat;
        }
        [HttpGet("/account/friendrequests/{token}")]
        public List<string> GetFriendRequests(string token)
        {
            string id = _jwtLogic.GetId(token);
            return _friendData.GetFriendRequests(id);
        }


        [HttpGet("/account/info")]
        public ApiAccountInfo GetAccountInfo(string token)
        {
            if (token == null)
                return new ApiAccountInfo();
            
            string id = _jwtLogic.GetId(token);
            ApiAccountInfo accountInfo = _accountLogic.GetAccountInfo(id);
            return accountInfo;
        }

        [HttpPost("/account/friendrequest")]
        public void RespondToFriendRequest(ApiFriendRequestResponse response)
        {
            string accountId = _jwtLogic.GetId(response.Token);
            _friendLogic.FriendRequestResponse(accountId, response.Accepted, response.FriendName);
        }
        
        [HttpPost("/account/login")]
        public ApiLogin Login(ApiAccount login)
        {
            Account account = _accountData.GetAccountById(_accountData.GetAccountIdByEmail(login.Email)!);
            return _accountLogic.LoginCheck(account, login.Password);
        }
  
    }
}