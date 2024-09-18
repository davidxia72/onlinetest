using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class BingClient : BaseClient
    {
        public async Task SendRequestToEndpoint()
        {
            for (var count = 0; count < 2; count++)
            {
                await Client.GetStringAsync("https://www.bing.com");
            }
        }
        ~BingClient()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
    }
}
