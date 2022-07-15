using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonPattern.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Create_CallTwice_ShouldBeTheSameInstance()
        {
            // Arrange

            // Act
            MessageService messageService = new MessageService(Logger.Instance);
            PrintService printService = new PrintService(Logger.Instance);

            // Assert
            Assert.AreSame(messageService.logger, printService.logger, "Different instances");

        }

        [TestMethod]
        public void Create_CallTwiceIoC_ShouldBeTheSameInstance()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<MessageService>();
            services.AddTransient<PrintService>();
            services.AddSingleton<Logger>();

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var messageService = serviceProvider.GetRequiredService<MessageService>();
            var printService = serviceProvider.GetRequiredService<PrintService>();

            // Assert
            Assert.AreSame(messageService.logger, printService.logger, "Different instances");

        }

        [TestMethod]
        public void Create_SingletonMessageService_ShouldBeTheSameInstance()
        {
            // Arrange 

            // Act
            MessageService messageService1 = SingletonMessageService.Instance;
            MessageService messageService2 = SingletonMessageService.Instance;

            // Assert
            Assert.AreSame(messageService1, messageService2);


        }
    }
}
