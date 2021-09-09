using System;
using ante_up.Common.ApiModels;
using ante_up.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ante_up.Controllers
{
    [EnableCors("AllowCORS")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AnteUpContext antecontext;

        public AccountController(AnteUpContext context)
        {
            antecontext = context;
        }
        [HttpPost("/register")]
        public bool NewGame(ApiAccount newAccount)
        {
            return new AccountData(antecontext).Register(newAccount);;
        }
    }
}