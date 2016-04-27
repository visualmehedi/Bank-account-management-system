using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo18.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal TransactionAmount { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
