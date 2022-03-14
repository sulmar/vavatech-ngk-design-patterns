using System;

namespace SingletonPattern
{
    // Szablon singletona w wersji leniwej (Lazy)
    public class LazySingleton<T>
        where T : new ()
    {
        private static Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance => _instance.Value;
    }
}
