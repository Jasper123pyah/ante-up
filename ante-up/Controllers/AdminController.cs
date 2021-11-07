using System;
using ante_up.Common.ApiModels.Admin;
using ante_up.Common.Interfaces.Data;
using ante_up.Data;
using ante_up.Logic;
using ante_up.Logic.JWT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly AccountLogic _accountLogic;
        private readonly FriendLogic _friendLogic;
        private readonly ChatLogic _chatLogic;
        private readonly WagerLogic _wagerLogic;
        private readonly GameLogic _gameLogic;
        
        public AdminController(IAnteUpContext context)
        {
            _accountLogic = new AccountLogic(new AccountData(context));
            _friendLogic = new FriendLogic(new AccountData(context), new FriendData(context));
            _chatLogic = new ChatLogic(new WagerData(context), new AccountData(context), new ChatData(context),
                new FriendData(context));
            _gameLogic = new GameLogic(new GameData(context));
            _wagerLogic = new WagerLogic(new WagerData(context), new AccountData(context));
        }
        
        [HttpGet("/admin")]
        public IActionResult CheckAdminToken()
        {
            return StatusCode(200, JWTLogic.CheckAdminToken(Request.Headers["Authorization"]));
        }

        [HttpGet("/admin/accounts")]
        public IActionResult GetAllAccounts()
        {
            return StatusCode(200, _accountLogic.GetAllAccounts(Request.Headers["Authorization"]));
        }

        [HttpPost("/admin/game")]
        public IActionResult CreateGame(ApiAdminGame adminGame)
        {
            _gameLogic.CreateGame(adminGame, Request.Headers["Authorization"]);
            return StatusCode(200);
        }

        [HttpDelete("/admin/game")]
        public IActionResult DeleteGame(string gameName)
        {
            _gameLogic.DeleteGame(gameName, Request.Headers["Authorization"]);
            return StatusCode(200);
        }
    }
}