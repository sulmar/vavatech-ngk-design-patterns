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

        }

        public MessageService(Logger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.LogInformation($"Send {message}");
        }
    }
}
