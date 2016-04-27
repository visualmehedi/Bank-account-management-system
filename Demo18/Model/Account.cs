using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo18.Model
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }

        public virtual List<Transaction> Transactions { get; set; }


    }
}
