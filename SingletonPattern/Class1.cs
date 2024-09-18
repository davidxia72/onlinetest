using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton 
     {
        private static  object instance; //= new Singleton();

        static Singleton()
        {
            instance = new object();
            Console.WriteLine("static constructor");
        }

        public Singleton()
        {
            instance = new object();
            Console.WriteLine("normal constructor");
        }

        //public static Singleton Instance()
        //{
        //    Console.WriteLine("In type initializer");
        //    return instance;
        //}
        public async Task SendRequestToEndpoint()
        {
            HttpClient _client = new HttpClient();
            string res = await _client.GetStringAsync("https://www.bing.com");
           // Console.WriteLine($"{res}");
        }
    }
}
