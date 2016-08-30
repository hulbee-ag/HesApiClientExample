using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using HESApiClientExample.Models;
using Nito.AsyncEx;

namespace HESApiClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            HttpClientHandler handler = new HttpClientHandler();            
            // set Windows Authentication credentials
            handler.Credentials = new NetworkCredential("username", "password", "DOMAIN");
            // enable cookies
            handler.UseCookies = true;

            HttpClient client = new HttpClient(handler);
            
            // set HES base address
            client.BaseAddress = new Uri("http://uri_to_the_HES_application/");
            
            // set default response format to JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // authentication
            var authenticationResponse = await client.GetAsync("account/signin?useWindowsCredentials=true");

            // get search results
            var response = await client.GetAsync(String.Format("api/search?query={0}", Uri.EscapeDataString(":all")));
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadAsAsync<SearchResponse>();
            
            Console.WriteLine("Found {0} items by query `{1}`...", results.TotalCount, results.Request.OriginalQuery);
            if (results.Items.Any())
            {
                Console.WriteLine("The first {0} items:", results.Items.Count());
                foreach (DocumentEntry entry in results.Items)
                {
                    Console.WriteLine("Uri: {0}", entry.Uri);
                }
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
