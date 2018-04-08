using System;

namespace MoneyLender
{
    /// <summary>   
    /// Bank Account demo class.   
    /// </summary>   
    public class BankAccount
    {
        private string m_customerName;

        private double m_balance;

        private bool m_frozen = false;
        public static string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public static string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        public static string CreditAmountLessThanZeroMessage = "Credit amount less than zero";

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > m_balance)
            {
                
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            }

            m_balance = m_balance - amount; // intentionally incorrect code, is correct now.
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        public void FreezeAccount()
        {
            m_frozen = true;
        }

        public void UnfreezeAccount()
        {
            m_frozen = false;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

    }
}
