using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo18.Model;

namespace Demo18.Service
{
    public class AccountService
    {
        private readonly IRepository repository;

        public AccountService(IRepository repo)
        {
            repository = repo;
        }

        public void SaveAccount(string accountnumber)
        {
            Account account = new Account();
            account.AccountNumber = accountnumber;
            account.AccountBalance = 0m;

            repository.SaveAccount(account);

        }

        public List <string> GetAccountNumbersForComboBox()
        {
            List<Account> accounts = repository.GetAccount();
            return accounts.Select(a => a.AccountNumber).ToList<string>();
        }

        public void SaveDepositToAccount(string amountAsStream, string selectedaccount)
        {
            Transaction transaction = new Transaction();
            transaction.TransactionAmount = decimal.Parse(amountAsStream);
            transaction.TransactionDateTime = DateTime.Now;

            repository.SaveTransactionToAccounts(transaction, selectedaccount);

        }
        public decimal Balance(string accountNumber)
        {
            decimal balance = repository.Balance(accountNumber);
            return balance;
        }
    }
}
