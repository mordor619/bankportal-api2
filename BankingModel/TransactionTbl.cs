using System;
using System.Collections.Generic;

#nullable disable

namespace RegisterationAPI.BankingModel
{
    public partial class TransactionTbl
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
