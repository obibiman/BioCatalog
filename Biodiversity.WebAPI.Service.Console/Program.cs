using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Biodiversity.WebAPI.Service.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61330/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("api/Litertures/RetrieveAuthors/searchText");
                if (response.IsSuccessStatusCode)
                {
                    //Product product = await response.Content.ReadAsAsync > Product > ();
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }
        }
    }
}