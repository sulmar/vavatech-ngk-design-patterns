namespace SingletonPattern
{
    // Szablon singletona
    public class Singleton<T>
        where T : new() // wymusza, że typ T musi posiadać konstruktor bezparametryczny
    {
        protected Singleton()
        {
        }

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
    }
}
