using System;
using System.Collections.Generic;

namespace MementoPattern.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationSnapshotTest();

        }

        private static void ConfigurationSnapshotTest()
        {
            IConfigurationRepository configurationRepository = new FileConfigurationRepository();

            Configuration configuration = new Configuration(configurationRepository.Get());

            ConfigurationCaretaker configurationCaretaker = new ConfigurationCaretaker(configurationRepository);

            // Backup 
            configurationCaretaker.SetState(configuration.CreateMemento());
            Console.WriteLine(configuration);

            // Change configuration
            configuration.Content = System.Text.Encoding.UTF8.GetBytes("{'port': 5000}");
            Console.WriteLine(configuration);

            // Restore
            configuration.SetMemento(configurationCaretaker.GetState());
            Console.WriteLine(configuration);
        }
    }

   
}
