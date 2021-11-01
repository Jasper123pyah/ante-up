using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.DataModels;
using ante_up.Common.ViewModels;
using ante_up.Data;
using ante_up.Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class WagerController : ControllerBase
    {
        private readonly AnteUpContext _antecontext;

        public WagerController(AnteUpContext context)
        {
            _antecontext = context;
        }
            
        [HttpGet]
        public List<Wager> GetWagers()
        {
            return new List<Wager>();
        }
        
        [HttpGet("/wager/game/{gameName}")]
        public List<ViewWager> GetWagerByGame(string gameName)
        {
            return new WagerLogic(_antecontext).GetWagersInGame(gameName);
        }

        [HttpGet("/wager/{id}")]
        public ViewWager GetWagerById(string id)
        {
            ViewWager viewWager = new WagerLogic(_antecontext).GetWagerById(id);
            return viewWager;
        }

        [HttpPost("/wager")]
        public string NewWager(ApiWager newWager)
        {
            WagerLogic logic = new(_antecontext);
            logic.AddNewWager(newWager);
            
            return new WagerLogic(_antecontext).AddNewWager(newWager);
        }

        [HttpGet("/wager/chat")]
        public Chat GetWagerChat(string id)
        {
            Chat chat = new ChatData(_antecontext).GetWagerChat(id);
            return new ChatLogic().SortChat(chat);
        }
        

        [HttpPost("/wager/leave")]
        public void LeaveTeam(ApiLobby apiLobby)
        {
            new WagerData(_antecontext).LeaveWager(apiLobby.WagerId, apiLobby.PlayerId);
        }
    }
}