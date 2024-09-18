using System;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (BingClient baseClient = new BingClient())
            {
                await baseClient.SendRequestToEndpoint();
                // baseClient.Dispose();
            }
            Console.WriteLine("Starting Main");
            // Invoke a static method on Test
            //Singleton single = Singleton.Instance();
           // Singleton single = new Singleton();
           // Console.WriteLine("After echo");
           //await  single.SendRequestToEndpoint();
           // single = new Singleton();
        }
    }
}
