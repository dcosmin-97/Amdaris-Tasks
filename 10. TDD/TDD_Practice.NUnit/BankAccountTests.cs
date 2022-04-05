using NUnit.Framework;
using System;

namespace TDD_Practice.NUnit
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            // here we can add arrange
            // this will run before all tests
            account = new BankAccount(500);
        }

        // NUnit use [TEST] for tests
        // naming convention -> UnitOfWork_StateUnderTest_ExpectedBehavior
        [Test]
        public void Add_AmountPositive_BalanceUpdates()
        {
            // Arrange -> set up everything to be ready

            // Act -> execute the test 
            account.Add(100);

            // Assert -> verify the actions
            Assert.AreEqual(600, account.Balance);
        }
        [Test]
        public void Add_AmountNegative_BalanceNotUpdatedWithException()
        {
            // Assert + ACT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
        }


        [Test]
        public void Withdraw_AmountPositive_BalanceUpdates()
        {
            // Act -> execute the test 
            account.Withdraw(100);

            // Assert -> verify the actions
            Assert.AreEqual(400, account.Balance);
        }
        [Test]
        public void Withdraw_AmountNegative_BalanceNotUpdatedWithException()
        {
            // Assert + ACT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }
        [Test]
        public void Withdraw_AmountHigherThanBalance_BalanceNotUpdatedWithException()
        {
            // Assert + ACT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(600));
        }

        [Test]
        public void TransferFunds_OtherAccNotNull_BalanceUpdatesForBothAccounts()
        {
            // Arrange -> set up everything to be ready
            var otherAcc = new BankAccount();

            // Act -> execute the test 
            account.TransferFundsTo(otherAcc, 100);

            // Assert -> verify the actions
            Assert.AreEqual(400, account.Balance);
            Assert.AreEqual(100, otherAcc.Balance);
        }
        [Test]
        public void TransferFunds_OtherAccNull_BalanceNotUpdatedThrows()
        {
            // Assert + ACT
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 500));
        }


    }
}