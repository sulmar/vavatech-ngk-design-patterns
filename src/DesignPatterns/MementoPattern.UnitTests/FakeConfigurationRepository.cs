using System.Text;

namespace MementoPattern.UnitTests
{
    internal class FakeConfigurationRepository : IConfigurationRepository
    {
        private string content = "{'port': 7000}";

        public void Add(byte[] content)
        {
            this.content = Encoding.ASCII.GetString(content);
        }

        public byte[] Get()
        {
            return Encoding.ASCII.GetBytes(content);
        }
    }
}
