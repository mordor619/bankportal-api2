using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterationAPI.BankingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BankingContext db;
        public LoginController(BankingContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("Signin")]
        public IActionResult Signin(string AccountNumber, string Password)
        {
            List<UserAccount> users = db.UserAccounts.ToList();

            foreach(UserAccount user in users)
            {
                if(user.AccountNumber.Equals(AccountNumber) && user.Password == Password)
                {
                    return Ok(new { status = 200, isSuccess = true, message = "User Login successfully!" });
                }
            }
            
            return Ok(new { status = 401, isSuccess = false, message = "Invalid User!" });
        }

    }
}
