using System;
using System.Threading.Tasks;
using ante_up.Common.Interfaces.Data.Context;
using ante_up.Data.DataClasses;
using ante_up.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly BalanceLogic _balanceLogic;

        public BalanceController(IAnteUpContext context)
        {
            _balanceLogic = new BalanceLogic(new AccountData(context), new BalanceData(context));
        }

        [HttpPost("/balance/deposit/{id}")]
        public async Task<IActionResult> GetGames(string id)
        {
            await _balanceLogic.UpdateAccountBalance(Request.Headers["Authorization"], id);
            return StatusCode(200);
        }
    }
}