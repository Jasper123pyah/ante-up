using System;
using System.Collections.Generic;
using System.Linq;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
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
        private readonly AnteUpContext antecontext;

        public WagerController(AnteUpContext context)
        {
            antecontext = context;
        }
            
        [HttpGet]
        public List<Wager> GetWagers()
        {
            return new List<Wager>();
        }
        
        [HttpGet("/wager/getbygame")]
        public List<ViewWager> GetWagerByGame(string gameName)
        {
            return new WagerLogic(antecontext).GetWagersInGame(gameName);
        }

        [HttpGet("/wager/getbyid")]
        public ViewWager GetWagerById(string id)
        {
            ViewWager viewWager = new WagerLogic(antecontext).GetWagerById(id);
            return viewWager;
        }
        [HttpPost("/wager/create")]
        public string NewWager(ApiWager newWager)
        {
            return new WagerLogic(antecontext).AddNewWager(newWager);
        } 
        [HttpPost("/wager/jointeam")]
        public int JoinTeam(ApiLobby apiLobby)
        {
            return new WagerData(antecontext).JoinTeam(apiLobby.WagerId, apiLobby.PlayerId, apiLobby.TeamNumber);
        }

        [HttpPost("/wager/leave")]
        public void LeaveTeam(ApiLobby apiLobby)
        {
            new WagerData(antecontext).LeaveWager(apiLobby.WagerId, apiLobby.PlayerId);
        }
    }
}