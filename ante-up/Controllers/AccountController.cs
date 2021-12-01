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
        private readonly AccountLogic _accountLogic;
        private readonly FriendLogic _friendLogic;
        private readonly ChatLogic _chatLogic;

        public AccountController(IAnteUpContext context)
        {
            _accountLogic = new AccountLogic(new AccountData(context));
            _friendLogic = new FriendLogic(new AccountData(context), new FriendData(context));
            _chatLogic = new ChatLogic(new WagerData(context), new AccountData(context), new ChatData(context),
                new FriendData(context));
        }

        [HttpPost("/account/{token}")]
        public IActionResult CheckToken(string token)
        {
            JWTLogic.CheckToken(token);
            return StatusCode(200);
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
        
        [HttpGet("/account/friends")]
        public IActionResult GetFriends()
        {
            string accountId = JWTLogic.GetId(Request.Headers["Authorization"]);

            return StatusCode(200, _friendLogic.GetFriendNames(accountId));
        }
        

        [HttpGet("/account/friend/chat/{friendName}")]
        public IActionResult GetFriendChat(string friendName)
        {
            string accountId = JWTLogic.GetId(Request.Headers["Authorization"]);
            string friendId = _accountLogic.GetAccountByUserName(friendName).Id.ToString();
            Chat chat = _chatLogic.GetFriendChat(friendId, accountId);
            return StatusCode(200, chat);
        }

        [HttpGet("/account/friendrequests")]
        public IActionResult GetFriendRequests()
        {
            return StatusCode(200, _friendLogic.GetFriendRequestNames(Request.Headers["Authorization"]));
        }

        [HttpGet("/account/info")]
        public IActionResult GetAccountInfo()
        {
            string id = JWTLogic.GetId(Request.Headers["Authorization"]);

            ApiAccountInfo accountInfo = _accountLogic.GetAccountInfo(id);
            return StatusCode(200, accountInfo);
        }

        [HttpPost("/account/friendrequest")]
        public IActionResult RespondToFriendRequest(ApiFriendRequestResponse response)
        {
            _friendLogic.FriendRequestResponse(Request.Headers["Authorization"], response.Accepted,
                response.FriendName);
            return StatusCode(200);
        }
    }
}