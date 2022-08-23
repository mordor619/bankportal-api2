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
    public class TransactionController : ControllerBase
    {
        private readonly BankingContext db;
        public TransactionController(BankingContext _db)
        {
            db = _db;
        }
        public static List<TransactionTbl> atc = new List<TransactionTbl>();
        [HttpGet]
        [Route("GetTransactionByAccno")]
        public async Task<IActionResult> GetTransactionByAccno(string Accno)
        {
            List<TransactionTbl> a = new List<TransactionTbl>();
            a = (from i in db.TransactionTbls
                 where i.AccountNumber == Accno  
                 select i).ToList();
            return Ok(a);
        }
    }
}
