using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PrototypePattern.UnitTests
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void CreateCopy_Phone_ShouldBeDeepCopyOfPhone()
        {
            // Arrange
            Batery batery = new Batery { Capacity = 3000, Level = 0.5f };
            Phone phone = new Phone { Name = "Phone1", Batery = batery };

            // Act
            Phone copyPhone = (Phone) phone.Clone();

            // Assert
            Assert.IsFalse(ReferenceEquals(phone, copyPhone));
            Assert.IsFalse(ReferenceEquals(phone.Batery, copyPhone.Batery));
        }

    }

    // PM> Install-Package FluentAssertions

    [TestClass]
    public class InvoiceServiceTests
    {
        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeCopyOfInvoice()
        {
            // Arrange
            InvoiceService invoiceService = new InvoiceService();
            Invoice invoice = CreateInvoice();

            // Act
            var copyInvoice = (Invoice) invoice.Clone();
            copyInvoice.Number = "FA 2";

            // Assert
            copyInvoice.Should().NotBeSameAs(invoice);

            copyInvoice.Should().BeEquivalentTo(invoice,
                options => options
                .Excluding(i=>i.CreateDate)
                .Excluding(i=>i.Number));

            var detailsReferenceEquals = invoice.Details.Zip(copyInvoice.Details, (original, copy) => ReferenceEquals(original, copy));

            var productsReferenceEquals = invoice.Details.Zip(copyInvoice.Details, (original, copy) => ReferenceEquals(original.Product, copy.Product));

            detailsReferenceEquals.All(x => x).Should().BeFalse();

            productsReferenceEquals.All(x => x).Should().BeTrue();

            copyInvoice.Number.Should().Be("FA 2");


        }

        private static Invoice CreateInvoice()
        {
            Customer customer = new Customer("John", "Smith");
            Product product1 = new Product("Keyboard", 250);
            Product product2 = new Product("Mouse", 150);

            Invoice invoice = new Invoice("FA 1", DateTime.Parse("2022-03-01"), PaymentType.Transfer, customer);
            invoice.Details.Add(new InvoiceDetail(product1));
            invoice.Details.Add(new InvoiceDetail(product2, 3));

            return invoice;
        }
    }
}
