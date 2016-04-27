using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo18.Model
{
    public class Repository : IRepository
    {
        public void SaveAccount(Account account)
        {
            using (var db = new BankContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public List<Account> GetAccount()
        {
            using (var db = new BankContext())
            {
                return db.Accounts.ToList<Account>();
            }
        }

        public void SaveTransactionToAccounts(Transaction transaction, string selectedaccount)
        {
            using (var db = new BankContext())
            {
                //skapa account
                Account account = db.Accounts.Where(a => a.AccountNumber == selectedaccount).First();
                //spara transaction
                account.Transactions.Add(transaction);

                Account newacc = account;
                newacc.AccountBalance = transaction.TransactionAmount + newacc.AccountBalance;

                db.Entry(account).CurrentValues.SetValues(newacc);
                db.SaveChanges();
            }
        }

        public decimal Balance(string accountNumber)
        {
            using (var db = new BankContext())
            {
                Account account = db.Accounts.Where(a => a.AccountNumber == accountNumber).First();

                return account.AccountBalance;
            }
        }
    }
}
