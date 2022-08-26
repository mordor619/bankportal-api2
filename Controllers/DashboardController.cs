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
    public class DashboardController : ControllerBase
    {
        private readonly BankingContext db;
        public DashboardController(BankingContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("TotalCredit")]
        public async Task<IActionResult> TotalCredit(string Accno)
        {
            var totalCredit = 0;
            List<TransactionTbl> a = new List<TransactionTbl>();
            a = (from i in db.TransactionTbls
                 where i.AccountNumber == Accno
                 select i).ToList();
            foreach(var i in a)
            {
                if(i.Type=="Credit")
                {
                    totalCredit += i.Amount;
                }
            }
            return Ok(totalCredit);
        }

        [HttpGet]
        [Route("TotalBalance")]
        public async Task<IActionResult> TotalBalance(string Accno)
        {
            var totalCredit = 0;
            var totalDebit = 0;
            var totalBalance = 0;
            List<TransactionTbl> a = new List<TransactionTbl>();
            a = (from i in db.TransactionTbls
                 where i.AccountNumber == Accno
                 select i).ToList();
            foreach (var i in a)
            {
                if (i.Type == "Credit")
                {
                    totalCredit += i.Amount;
                }
                else
                {
                    totalDebit += i.Amount;
                }
            }
            totalBalance = totalCredit - totalDebit;
            return Ok(totalBalance);
        }
        [HttpGet]
        [Route("TotalDebit")]
        public async Task<IActionResult> TotalDebit(string Accno)
        {
            var totalDebit = 0;
            List<TransactionTbl> a = new List<TransactionTbl>();
            a = (from i in db.TransactionTbls
                 where i.AccountNumber == Accno
                 select i).ToList();
            foreach (var i in a)
            {
                if (i.Type == "Debit")
                {
                    totalDebit += i.Amount;
                }
            }
            return Ok(totalDebit);
        }

        [HttpGet]
        [Route("RecentTransaction")]
        public async Task<IActionResult> RecentTransaction(string Accno)
        {
            //var productlatestreleases = x(from p in visualsproduct
            //                             from pf in p.domainobjectfields
            //                             select p).distinct().orderbydescending(d => d.datecreated).take(10);

            List<TransactionTbl> a = new List<TransactionTbl>();
            a = (from i in db.TransactionTbls
                 where i.AccountNumber == Accno
                 select i).ToList();

            return Ok(a.OrderByDescending(x => x.Date).Take(5).ToList());


        }
    }
}
