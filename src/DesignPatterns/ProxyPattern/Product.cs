using System;
using System.IO;

namespace ProxyPattern
{

    // PM> Install-Package System.Drawing.Common
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime EntryDate { get; set; } 
        public System.Drawing.Image Image { get; set; }

        public Person(int id, string firstName)
        {
            Id = id;
            FirstName = firstName;

            EntryDate = DateTime.Now;
        }
    }

    public class Product
    {
        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CacheHit { get; set; }
    }

    public class ProxyOrder : Order
    {
        public override Customer Customer
        {
            get
            {  // TODO: select * from Customers where customerId = CustomerId
                return base.Customer;
            }

            set
            {
                base.Customer = value;
            }
        }
    }

    public class Order
    {
        public virtual Customer Customer { get; set; }


    }

    public class Customer
    {
        public string Name { get; set; }
        public virtual byte[] Photo { get; set; }
    }


}
