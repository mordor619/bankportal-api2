using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterationAPI.BankingModel
{
    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }

        public Response(string Status, string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }
    }
}
