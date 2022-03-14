using System;

namespace AbstractFactoryPattern
{
    // Concrete Factory
    public class PaymentViewFactory : IPaymentViewFactory
    {
        public PaymentView Create(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Cash:
                    return new CashPaymentView();

                case PaymentType.CreditCard:
                    return new CreditCardPaymentView();

                case PaymentType.BankTransfer:
                    return new BankTransferPaymentView();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
