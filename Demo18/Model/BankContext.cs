namespace Demo18.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankContext : DbContext
    {
       
        public BankContext()
            : base("name=Bank")
        {
        }


        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
    }


}