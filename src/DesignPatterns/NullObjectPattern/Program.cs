using System;
using System.Collections.Generic;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Null Object Pattern!");

            IProductRepository productRepository = new FakeProductRepository();

            ProductBase product = productRepository.Get(2);

            // Problem: Zawsze musimy sprawdzać czy obiekt nie jest pusty (null).
            product.RateId(3);

        }
    }

    public interface IProductRepository
    {
        ProductBase Get(int id);
    }

    public class FakeProductRepository : IProductRepository
    {
        private readonly IDictionary<int, Product> products = new Dictionary<int, Product>();

        public FakeProductRepository()
        {
            products.Add(2, new Product());
            products.Add(3, new Product());
        }

        public ProductBase Get(int id)
        {
            if (products.TryGetValue(id, out Product product))
            {
                return product;
            }
            else
                return new NullProduct();
        }
    }

    // Abstract Object
    public abstract class ProductBase
    {
        protected int rate;
        public abstract void RateId(int rate);
    }

    // Real Object
    public class Product : ProductBase
    {
        public override void RateId(int rate)
        {
            this.rate = rate;
        }
    }

    // Null Object
    public class NullProduct : ProductBase
    {
        public override void RateId(int rate)
        {
            // nic nie rób
        }

    }
}
