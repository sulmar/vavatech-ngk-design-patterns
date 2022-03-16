using System;

namespace StrategyPattern
{
    // Abstract Strategy
    public interface IDiscountStrategy
    {
        decimal Discount(Order order);
        decimal NoDiscount();
    }

    public class ATMTest
    {
        public void Test()
        {
            IWplatomat atm = new SecondATM();

            atm.Wplac(100);

            if (atm is IWyplatomat)
            {

            }
        }

       
    }

    public interface IATM
    {          
        decimal SprawdzSaldo(); 
    }

    public interface IWplatomat
    {
        void Wplac(decimal amount);
    }

    public interface IWyplatomat
    {
        void Wyplac(decimal amount);
    }


    public class MyATM : IATM, IWyplatomat
    {
        private decimal saldo;

        public decimal SprawdzSaldo()
        {
            return saldo;
        }

        public void Wyplac(decimal amount)
        {
            saldo -= amount;
        }
    }

    public class SecondATM : IATM, IWplatomat, IWyplatomat
    {
        private decimal saldo;

        public decimal SprawdzSaldo()
        {
            return saldo;
        }

        public void Wplac(decimal amount)
        {
            saldo += amount;
        }

        public void Wyplac(decimal amount)
        {
            saldo -= amount;
        }
    }
}
