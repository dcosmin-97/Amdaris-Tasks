using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Practice
{
    public class BankAccount
    {
        private double _balance;

        public BankAccount()
        {

        }

        public BankAccount(double balance)
        {
            this._balance = balance;
        }

        public double Balance { get { return _balance; }  }

        public void Add(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > _balance)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _balance -= amount;
        }
        public void TransferFundsTo(BankAccount otherAcc, double amount)
        {
            if (otherAcc is null)
                throw new ArgumentNullException(nameof(otherAcc));

            Withdraw(amount);
            otherAcc.Add(amount);
        }
    }
}
