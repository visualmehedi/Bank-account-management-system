using System;
using System.Collections.Generic;
namespace Demo18.Model
{
    public interface IRepository
    {
        void SaveAccount(Account account);


        List<Account> GetAccount();

        void SaveTransactionToAccounts(Transaction transaction, string selectedaccount);
        decimal Balance(string accountNumber);
    }
}
