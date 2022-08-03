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
    public class RegisterController : ControllerBase
    {
        private readonly BankingContext db;
        public RegisterController(BankingContext _db)
        {
            db = _db;
        }
        List<string> AccnoList = new List<string>();

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup(UserAccount user)
        {
            Random random = new Random();
            int pinnum = random.Next(1000, 9999);
            user.Pin = pinnum;
            Repeat:
            string acc = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                acc += random.Next(0, 9).ToString();
            }
            AccnoList.Add(acc);
            if (AccnoList.Count != AccnoList.Distinct().Count())
            {
                AccnoList.Remove(acc);
                goto Repeat;
            }
            user.AccountNumber = "";
            user.AccountNumber = string.Concat(user.AccountNumber,acc);
            
            db.UserAccounts.Add(user);
            await db.SaveChangesAsync();
            return Ok();

        }
    }
}

