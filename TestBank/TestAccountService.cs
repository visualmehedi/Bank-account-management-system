using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo18.Service;
using Moq;
using Demo18.Model;
using System.Collections.Generic;
using System.Linq;

namespace TestBank
{
    [TestClass]
    public class TestAccountService
    {
        [TestMethod]
        public void TestSaveAccount()
        {
            //Arrange
            
            List <Account> accounts = new List <Account>();


            var mock = new Mock<IRepository>();
            mock.Setup(r => r.SaveAccount(It.IsAny<Account>())).Callback((Account acc) => accounts.Add(acc));


            //skapa objekt av mock
            IRepository repo = mock.Object;


            AccountService accountservice = new AccountService(repo);

            //Act
            accountservice.SaveAccount("9999-999");

            //Assert
            Assert.AreEqual(1, accounts.Count);
            Assert.AreEqual("9999-999", accounts.Where(a => a.AccountNumber == "9999-999").Select(a => a.AccountNumber).First());

        }

        [TestMethod]
        public void TestGetAccountNumbersForComboBox()
        {
            //Arrange
            List<Account> accounts = new List<Account>() { 
                new Account() { AccountNumber = "5555-555" }, 
                new Account() { AccountNumber = "6666-666" } 
            };

            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAccount()).Returns(accounts);
            IRepository repo = mock.Object;

            AccountService accountservice = new AccountService(repo);

            //Act
            List<string> accountnumber = accountservice.GetAccountNumbersForComboBox();
            
            //Assert
            Assert.AreEqual(2, accountnumber.Count);
            Assert.AreEqual("5555-555", accountnumber.First());
        }
    [TestMethod]
        public void TestSaveDepositToAccount()
        {
        //Arrange
            Account selectedaccount = new Account();
            selectedaccount.AccountNumber = "9999-999";
            selectedaccount.Transactions = new List<Transaction>();

            selectedaccount.Transactions.Add(new Transaction() 
            { TransactionAmount = 500m, TransactionDateTime = DateTime.Now });

            var mock = new Mock<IRepository>();
            mock.Setup(r => r.SaveTransactionToAccounts
                (It.IsAny<Transaction>(), It.IsAny<string>())).Callback
                ((Transaction transaction, string selectedacc) 
                    => selectedaccount.Transactions.Add(transaction));

            IRepository repo = mock.Object;


            AccountService accountservice = new AccountService(repo);

        //Act
            accountservice.SaveDepositToAccount("800", "9999-999");


        //Assert
        Assert.AreEqual(800, selectedaccount.Transactions.
            Select(t => t.TransactionAmount).Last());
        Assert.AreEqual(2, selectedaccount.Transactions.Count);
        }
    }
}
