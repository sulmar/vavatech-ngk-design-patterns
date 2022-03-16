using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProxyPattern.UnitTests
{
    [TestClass]
    public class MemoryCacheImageRepositoryTests
    {

        [TestMethod]
        public void Get_ById_ShouldReturnPerson()
        {
            // Arrange
            DbPersonRepository personRepository = new DbPersonRepository(new MemoryCacheImageRepository(new FileImageRepository()));

            // Act
            Person person = personRepository.Get(1);
            personRepository.Get(1);
            personRepository.Get(1);

            // Asserts
            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("John", person.FirstName);
            Assert.IsNotNull(person.Image);
        }
    }
}
