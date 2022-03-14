using System;

namespace AbstractFactoryPattern
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory Method Pattern!");

            // VisitCalculateAmountTest();

            PaymentTest();
        }



        private static void PaymentTest()
        {
            IPaymentViewFactory paymentViewFactory = new PaymentViewFactory();

            while (true)
            {
                Console.Write("Podaj kwotę: ");

                decimal.TryParse(Console.ReadLine(), out decimal totalAmount);

                Console.Write("Wybierz rodzaj płatności: (G)otówka (K)karta płatnicza (P)rzelew: ");

                var paymentType = Enum.Parse<PaymentType>(Console.ReadLine());

                Payment payment = new Payment(paymentType, totalAmount);

                PaymentView paymentView = paymentViewFactory.Create(paymentType);
                paymentView.Show(payment);

                string icon = GetIcon(payment);
                Console.WriteLine(icon);                
            }

        }

        private static string GetIcon(Payment payment)
        {
            switch (payment.PaymentType)
            {
                case PaymentType.Cash: return "[100]"; 
                case PaymentType.CreditCard: return "[abc]"; 
                case PaymentType.BankTransfer: return "[-->]";

                default: return string.Empty;
            }
        }

        private static void VisitCalculateAmountTest()
        {
            IVisitFactory visitFactory = new VisitFactory();
            IConsoleColorFactory consoleColorFactory = ConsoleColorFactoryFactory.Create(Theme.Dark);

            while (true)
            {
                Console.Write("Podaj rodzaj wizyty: (N)FZ (P)rywatna (F)irma: (T)eleporada");
                string kind = Console.ReadLine();

                Console.Write("Podaj czas wizyty w minutach: ");
                if (double.TryParse(Console.ReadLine(), out double minutes))
                {
                    TimeSpan duration = TimeSpan.FromMinutes(minutes);

                    Visit visit = visitFactory.Create(kind, duration, 100);

                    decimal totalAmount = visit.CalculateCost();

                    Console.ForegroundColor = consoleColorFactory.Create(totalAmount);

                   Console.WriteLine($"Total amount {totalAmount:C2}");

                    Console.ResetColor();
                }
            }

        }

        // Abstract factory
        public interface IConsoleColorFactory
        {
            ConsoleColor Create(decimal value);
        }

        public class ConsoleColorFactoryFactory
        {
            public static IConsoleColorFactory Create(Theme theme)
            {
                switch(theme)
                {
                    case Theme.Light: return new LightConsoleColorFactory();
                    case Theme.Dark: return new DarkConsoleColorFactory();

                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public enum Theme
        {
            Light,
            Dark
        }


        // Concret factory
        public class LightConsoleColorFactory : IConsoleColorFactory
        {

            // Product
            public ConsoleColor Create(decimal value)
            {
                if (value == 0) 
                    return ConsoleColor.Green; 
                else if (value >= 200) 
                    return ConsoleColor.Red;
                else 
                    return ConsoleColor.White;
            }
        }

        public class DarkConsoleColorFactory : IConsoleColorFactory
        {
            public ConsoleColor Create(decimal value)
            {
                if (value == 0)
                    return ConsoleColor.DarkGreen;
                else if (value >= 200)
                    return ConsoleColor.DarkRed;
                else
                    return ConsoleColor.White;
            }
        }
    }
}
