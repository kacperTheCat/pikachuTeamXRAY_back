using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWebAPIAsync().Wait();
        }
        static async Task CallWebAPIAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58738/api/image");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));

                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/image");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Dziala");
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            Console.Read();
        }
    }
}
