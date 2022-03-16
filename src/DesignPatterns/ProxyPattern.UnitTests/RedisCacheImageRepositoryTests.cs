using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;

namespace ProxyPattern.UnitTests
{
    [TestClass]
    public class RedisCacheImageRepositoryTests
    {

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Get_ById_ShouldReturnPerson(int personId)
        {
            // Arrange
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            DbPersonRepository personRepository = new DbPersonRepository( new RedisCacheImageRepository( redis, new FileImageRepository()));

            // Act
            Person person = personRepository.Get(personId);
            personRepository.Get(personId);
            personRepository.Get(personId);            

            // Asserts
            Assert.AreEqual(personId, person.Id);
            Assert.IsNotNull(person.Image);
        }
    }
}
