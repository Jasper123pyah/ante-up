using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.HubModels;
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
        private readonly AnteUpContext _anteUpContext;
        private readonly WagerLogic _wagerLogic;
        private readonly JWTLogic _jwtLogic;
        public WagerController(AnteUpContext context)
        {
            _anteUpContext = context;
            _wagerLogic = new WagerLogic(context);
            _jwtLogic = new JWTLogic();
        }

        [HttpGet("/wager/game/{gameName}")]
        public List<ViewWager> GetWagerByGame(string gameName)
        {
            return _wagerLogic.GetWagersInGame(gameName);
        }

        [HttpGet("/wager/{id}")]
        public ViewWager GetWagerById(string id)
        {
            ViewWager viewWager =_wagerLogic.GetWagerById(id);
            return viewWager;
        }

        [HttpPost("/wager")]
        public LobbyUser NewWager(ApiWager newWager)
        {
            newWager.CreatorId = _jwtLogic.GetId(newWager.CreatorId);
            return _wagerLogic.AddNewWager(newWager);
        }

        [HttpGet("/wager/chat")]
        public Chat GetWagerChat(string id)
        {
            Chat chat = new ChatData(_anteUpContext).GetWagerChat(id);
            chat.SortByTime();
            return chat;
        }

        [HttpPost("/wager/leave")]
        public void LeaveTeam(ApiLobby apiLobby)
        {
            _wagerLogic.LeaveWager(apiLobby);
        }
    }
}