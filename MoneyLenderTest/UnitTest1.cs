using System;
using MoneyLender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyLenderTest
{
    [TestClass]
    public class UnitTest1
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double StartingBalance = 100.00;
            double debitAmount = 100.01;
            BankAccount account = new BankAccount("Sir James of the round table", StartingBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
            
        }
        [TestMethod]
        public void AccountFrozen_ShouldThrowException()
        {
            double StartingBalance = 1000.00;
            double creditamount = 10000.00;
            BankAccount account = new BankAccount("Count Vladimir Von-Bach", StartingBalance);
            account.FreezeAccount();
            try
            {
                account.Credit(creditamount);
            }
            catch(Exception e)
            {
                return;
            }
            Assert.Fail("Now exception was thrown.");
        }

        [TestMethod]
        public void AmountNegative_ArgumentOutOfRangeExceptionShouldThrow()
        {
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            try
            {
                account.Debit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        [TestMethod]
        public void AccountGetsUpdatedAndIsHunkyDory()
        {
            double beginningBalance = 10.00;
            double creditAmount = 5.11;
            double expected = 15.11;
            BankAccount account = new BankAccount("Sir Buckinghaam", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
