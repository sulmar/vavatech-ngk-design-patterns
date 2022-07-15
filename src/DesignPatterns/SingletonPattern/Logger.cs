using System;
using System.IO;

namespace SingletonPattern
{
    public class Logger
    {
        private readonly string path = "log.txt";

        public void LogInformation(string message)
        {
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{DateTime.Now} {message}");
        }

        public Logger()
        {

        }

        //private static Logger logger;

        //public static Logger Instance
        //{
        //    get
        //    {
        //        if (logger==null)
        //        {
        //            logger = new Logger();
        //        }

        //        return logger;
        //    }
        //}


        // Logger logger = lazy new Logger();
        // Logger.Instance -> new Logger();


        // Leniwy singleton (Lazy Singleton)
        private static Lazy<Logger> logger = new Lazy<Logger>(() => new Logger(), true);

        public static Logger Instance => logger.Value;

    }
}
