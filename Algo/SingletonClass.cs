using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    //https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
    public sealed class SingletonClass
    {
       
            private static readonly SingletonClass instance = new SingletonClass();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        //The laziness of type initializers is only guaranteed by .NET when the type isn't marked with a special flag called beforefieldinit. 
        static SingletonClass()
            {
            }

            private SingletonClass()
            {
            }

            public static SingletonClass Instance
            {
                get
                {
                    return instance;
                }
            }
    }
}
