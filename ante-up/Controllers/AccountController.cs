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
        private readonly AnteUpContext antecontext;
        private readonly JWTLogic _jwtLogic;
        public AccountController(AnteUpContext context)
        {
            antecontext = context;
            _jwtLogic = new JWTLogic();
        }
        
        [HttpPost("/account/register")]
        public string Register(ApiAccount newAccount)
        {
            return new AccountLogic(antecontext).Register(newAccount);;
        }

        [HttpGet("/account/friends/{id}")]
        public List<string> GetFriends(string id)
        {
            return new AccountData(antecontext).GetFriends(id);
        }
        [HttpGet("/account/friend/chat/{id}")]
        public Chat GetFriendCHat(ApiFriendChat apiFriendChat)
        {
            string accountId = _jwtLogic.GetId(apiFriendChat.Token);
            Chat chat = new ChatData(antecontext).GetFriendChat(apiFriendChat.FriendName, accountId);
            return new ChatLogic().SortChat(chat);
        }
        [HttpGet("/account/friendrequests/{id}")]
        public List<string> GetFriendRequests(string id)
        {
            return new AccountData(antecontext).GetFriendRequests(id);
        }


        [HttpGet("/account/info")]
        public ApiAccountInfo GetAccountInfo(string token)
        {
            if (token == null)
                return new ApiAccountInfo();
            
            string id = _jwtLogic.GetId(token);
            ApiAccountInfo accountInfo = new AccountLogic(antecontext).GetAccountInfo(id);
            return accountInfo;
        }
        
        [HttpPost("/account/login")]
        public ApiLogin Login(ApiAccount login)
        {
            Account account = new AccountData(antecontext).GetAccountByEmail(login.Email);
            return new AccountLogic(antecontext).LoginCheck(account, login.Password);
        }
  
    }
}