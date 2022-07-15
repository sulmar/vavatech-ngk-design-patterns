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
