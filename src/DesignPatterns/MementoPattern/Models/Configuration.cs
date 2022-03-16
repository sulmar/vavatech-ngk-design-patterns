using System;
using System.Text;

namespace MementoPattern.Problem
{
    public class Configuration
    {
        public byte[] Content { get; set; }

        public Configuration(byte[] content)
        {
            Content = content;
        }

        public override string ToString()
        {
            return ASCIIEncoding.UTF8.GetString(Content);
        }



        // Backup (snapshot)
        public ConfigurationMemento CreateMemento()
        {
            return new ConfigurationMemento(Content);
        }

        // Restore
        public void SetMemento(ConfigurationMemento memento)
        {
            this.Content = memento.Content;
        }
    }

    public class ConfigurationMemento
    {
        public byte[] Content { get; }
        public DateTime SnashotDate { get; }

        public ConfigurationMemento(byte[] content)
        {
            Content = content;
            SnashotDate = DateTime.Now;
        }
    }

    public class ConfigurationCaretaker
    {
        private readonly IConfigurationRepository configurationRepository;

        public ConfigurationCaretaker(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }

        public void SetState(ConfigurationMemento memento)
        {
            configurationRepository.Add(memento.Content);

        }

        public ConfigurationMemento GetState()
        {
            return new ConfigurationMemento(configurationRepository.Get());
        }
    }


}
