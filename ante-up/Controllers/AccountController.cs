using System;
using ante_up.Common.ApiModels;
using ante_up.Common.Models;
using ante_up.Data;
using ante_up.Logic;
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
        
        [HttpPost("/account/register")]
        public string Register(ApiAccount newAccount)
        {
            return new AccountLogic(antecontext).Register(newAccount);;
        }
        
        [HttpGet("/account/info")]
        public ApiAccountInfo GetAccountInfo(string id)
        {
            if (id == null)
                return new ApiAccountInfo();
            Account acc = new AccountData(antecontext).GetAccountById(id);

            ApiAccountInfo accountInfo = new()
            {
                Username = acc.Username,
                Balance = acc.Balance,
                Email = acc.Email
            };
            return accountInfo;
        }
        
        [HttpPost("/account/login")]
        public ApiLogin Login(ApiAccount login)
        {
            return new AccountLogic(antecontext).LoginCheck(login);
        }
    }
}