using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
using ante_up.Common.Interfaces.Data;
using ante_up.Common.ViewModels;
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
    public class WagerController : ControllerBase
    {
        private readonly WagerLogic _wagerLogic;
        private readonly ChatLogic _chatLogic;

        public WagerController(IAnteUpContext context)
        {
            _wagerLogic = new WagerLogic(new WagerData(context), new AccountData(context));
            _chatLogic = new ChatLogic(new WagerData(context), new AccountData(context), new ChatData(context),
                new FriendData(context));
        }

        [HttpGet("/wager/game/{gameName}")]
        public List<ViewWager> GetWagerByGame(string gameName)
        {
            return _wagerLogic.GetWagersInGame(gameName);
        }

        [HttpGet("/wager/{id}")]
        public IActionResult GetWagerById(string id)
        {
            ViewWager viewWager = _wagerLogic.CreateViewWager(id);
            return StatusCode(200, viewWager);
        }

        [HttpPost("/wager")]
        public string NewWager(ApiWager newWager)
        {
            string creatorId = JWTLogic.GetId(Request.Headers["Authorization"]);
            return _wagerLogic.AddNewWager(newWager, creatorId);
        }

        [HttpGet("/wager/chat")]
        public Chat GetWagerChat(string id)
        {
            return _chatLogic.GetWagerChat(id);;
        }

        [HttpPost("/wager/leave")]
        public void LeaveTeam(ApiLobby apiLobby)
        {
            _wagerLogic.LeaveWager(apiLobby.WagerId, JWTLogic.GetId(Request.Headers["Authorization"]));
        }
    }
}