using System;
using System.Collections.Generic;
using System.Drawing;
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


    // Subject    
    public interface IImageRepository
    {
        Image Get(int personId);
    }

    // Real Subject
    public class FileImageRepository : IImageRepository
    {
        public Image Get(int personId)
        {
            return Image.FromFile($@"Images\Image{personId}.jpg");
        }
    }


    public class ProxyRedisImageRepository : IImageRepository
    {
        // dotnet add package StackExchange.Redis


        public Image Get(int personId)
        {
            throw new NotImplementedException();
        }
    }

    // Proxy
    public class ProxyImageRepository : IImageRepository
    {
        // Real Subject
        private readonly IImageRepository imageRepository;

        private IDictionary<int, Image> images;

        public ProxyImageRepository(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;

            images = new Dictionary<int, Image>();
        }

        public Image Get(int personId)
        {
            if (images.TryGetValue(personId, out Image image))
            {
                return image;
            }
            else
            {
                image = imageRepository.Get(personId);

                if (image!=null)
                {
                    images.Add(personId, image);
                }

                return image;
            }

        }
    }



    public class DbPersonRepository
    {
        private readonly IImageRepository _imageRepository;

        public DbPersonRepository(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Person Get(int id)
        {
            var people = new Dictionary<int, Person>()
            {
                { 1, new Person(1, "John") },
                { 2, new Person(2, "Ann") },
                { 3, new Person(3, "Bob") },
            };

            if (people.TryGetValue(id, out Person person))
            {
                person.Image = _imageRepository.Get(id);

                return person;
            }
            else
                return null;


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
