using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data;
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
        private readonly JWTLogic _jwtLogic;
        private readonly AccountLogic _accountLogic;
        private readonly FriendLogic _friendLogic;
        private readonly ChatLogic _chatLogic;

        public AccountController(IAnteUpContext context)
        {
            _jwtLogic = new JWTLogic();
            _accountLogic = new AccountLogic(new AccountData(context));
            _friendLogic = new FriendLogic(new AccountData(context), new FriendData(context));
            _chatLogic = new ChatLogic(new WagerData(context), new AccountData(context), new ChatData(context),
                new FriendData(context));
        }

        [HttpPost("/account/register")]
        public IActionResult Register(ApiAccount newAccount)
        {
            _accountLogic.Register(newAccount);
            return StatusCode(200);
        }

        [HttpPost("/account/login")]
        public IActionResult Login(ApiAccount login)
        { 
            ApiLogin apiLogin = _accountLogic.LoginCheck(login.Email, login.Password);
            return StatusCode(200, apiLogin);
        }
        [HttpGet("/account/friends/{token}")]
        public List<string> GetFriends(string token)
        {
            string id = _jwtLogic.GetId(token);
            return _friendLogic.GetFriendNames(id);
        }

        [HttpGet("/account/friend/chat")]
        public Chat GetFriendChat(ApiFriendChat apiFriendChat)
        {
            string accountId = _jwtLogic.GetId(apiFriendChat.Token);
            Chat chat = _chatLogic.GetFriendChat(apiFriendChat.FriendName, accountId);
            chat.SortByTime();
            return chat;
        }

        [HttpGet("/account/friendrequests/{token}")]
        public List<string> GetFriendRequests(string token)
        {
            string id = _jwtLogic.GetId(token);
            return _friendLogic.GetFriendRequestNames(id);
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

    }
}