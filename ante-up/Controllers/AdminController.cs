using System.Collections.Generic;
using ante_up.Common.AdminModels;
using ante_up.Common.ApiModels.Admin;
using ante_up.Common.Interfaces.Data.Context;
using ante_up.Data.DataClasses;
using ante_up.Logic.JWT;
using ante_up.Logic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly GameLogic _gameLogic;
        private readonly AdminLogic _adminLogic;
        public AdminController(IAnteUpContext context)
        {
            _gameLogic = new GameLogic(new GameData(context), new WagerData(context));
            _adminLogic = new AdminLogic(new AccountData(context), new FriendData(context), new WagerData(context));
        }
        
        [HttpGet]
        public IActionResult CheckAdminToken()
        {
            return StatusCode(200, JWTLogic.CheckAdminToken(Request.Headers["Authorization"]));
        }

        [HttpGet("/admin/accounts")]
        public IActionResult GetAllAccounts()
        {
            List<AdminAccount> accounts = _adminLogic.GetAllAdminAccounts(Request.Headers["Authorization"]);
            return StatusCode(200, accounts);
        }

        [HttpPost("/admin/game")]
        public IActionResult CreateGame(ApiAdminGame adminGame)
        {
            _gameLogic.CreateGame(adminGame, Request.Headers["Authorization"]);
            return StatusCode(200);
        }

        [HttpPut("/admin/game")]
        public IActionResult EditGame(ApiAdminGame adminGame)
        {
            _gameLogic.EditGame(adminGame,Request.Headers["Authorization"]);
            return StatusCode(200);
        }
        [HttpDelete("/admin/game/{id}")]
        public IActionResult DeleteGame(string id)
        {
            _gameLogic.DeleteGame(id, Request.Headers["Authorization"]);
            return StatusCode(200);
        }
    }
}