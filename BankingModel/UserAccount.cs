using System;
using System.Collections.Generic;

#nullable disable

namespace RegisterationAPI.BankingModel
{
    public partial class UserAccount
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
    }
}
