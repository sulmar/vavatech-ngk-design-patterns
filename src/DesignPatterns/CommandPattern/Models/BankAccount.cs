using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class DepositCommand : ICommand
    {
        private readonly BankAccount account;
        private readonly decimal amount;

        public DepositCommand(BankAccount account, decimal amount)
        {
            this.account = account;
            this.amount = amount;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            account.Balance += amount;
        }
    }

    public class WithdrawCommand : ICommand
    {
        private readonly BankAccount account;
        private readonly decimal amount;

        public WithdrawCommand(BankAccount account, decimal amount)
        {
            this.account = account;
            this.amount = amount;
        }

        public bool CanExecute()
        {
            return account.Balance - amount >= BankAccount.OverdraftLimit;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                account.Balance -= amount;
            }
            else
            {
                throw new ApplicationException();
            }
        }
    }


    public class BankAccount
    {
        public decimal Balance { get; set; }

        public static decimal OverdraftLimit = -500;

        public decimal OdliczProwizjeGetBalance()
        {
            OdliczProwizje();

            return GetBalance();
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        private void OdliczProwizje()
        {
            Balance -= -1m;
        }




    }
}
