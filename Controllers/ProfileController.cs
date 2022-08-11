using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterationAPI.BankingModel;

namespace RegisterationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly BankingContext db;
        public ProfileController(BankingContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("getDetailsByAccountNo")]
        public async Task<IActionResult> ViewProfileByAccno(string accno)
        {
            UserAccount c = await db.UserAccounts.FindAsync(accno);
            return Ok(c);
        }
    }
}
