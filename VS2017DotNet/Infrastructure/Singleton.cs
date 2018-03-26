using System;

namespace Infrastructure
{
    public sealed class Singleton
    {
        private static volatile Singleton _instance;

        private static readonly object SyncRoot = new Object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }
}