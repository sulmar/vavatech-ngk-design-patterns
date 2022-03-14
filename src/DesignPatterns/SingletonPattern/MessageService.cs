namespace SingletonPattern
{
    // Singleton generyczny
    public class SingletonMessageService : Singleton<MessageService>
    {
        protected SingletonMessageService()
        { }
    }

    public class MessageService
    {
        public Logger logger;

        public MessageService()
        {
            logger = Logger.Instance;
        }

        public void Send(string message)
        {
            logger.LogInformation($"Send {message}");
        }
    }
}
