using MementoPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MementoPattern.UnitTests
{

    [TestClass]
    public class ConfigurationSnapshotTests
    {

        [TestMethod]
        public void Backup_Restore_ShouldReturnsPreviousConfiguration()
        {
            // Arrange
            IConfigurationRepository configurationRepository = new FakeConfigurationRepository();
            Configuration configuration = new Configuration(configurationRepository.Get());
            ConfigurationCaretaker configurationCaretaker = new ConfigurationCaretaker(configurationRepository);

            // Act
            configurationCaretaker.SetState(configuration.CreateMemento());            
            configuration.Content = System.Text.Encoding.UTF8.GetBytes("{'port': 5000}");            
            configuration.SetMemento(configurationCaretaker.GetState());

            // Assert
            Assert.AreEqual("{'port': 7000}", System.Text.Encoding.ASCII.GetString(configuration.Content));

        }
    }
}
