using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWebAPIAsync().Wait();
        }

    }
}
