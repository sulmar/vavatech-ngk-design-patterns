using System.IO;

namespace MementoPattern
{
    // Concrete Repository
    public class FileConfigurationRepository : IConfigurationRepository
    {
        private string filename = "config.txt";

        public void Add(byte[] content)
        {
            File.WriteAllBytes(filename, content);
        }

        public byte[] Get()
        {
            return File.ReadAllBytes(filename);
        }
    }


}
