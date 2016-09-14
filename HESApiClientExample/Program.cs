using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
            HttpClient client = new HttpClient();
            
            // set HES base address
            client.BaseAddress = new Uri("http://uri_to_the_HES_application/");
            
            // set default response format to JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // authentication
            await AuthenticateAsync(client, 
                // you can get this data from HES Dashboard
                clientId: "CLIENT_ID", 
                clientSecret: "CLIENT_SECRET", 
                // authenticating user credentials
                userName: "USERNAME", 
                userPassword: "PASSWORD");
            
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


        static async Task AuthenticateAsync(HttpClient client, string clientId, string clientSecret, string userName, string userPassword)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/token");

            // set client_id and client_secrets to Basic authorization header
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);
            string token = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

            // set authenticating user credentials
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", userName },
                { "password", userPassword }
            });
            
            // execute authentication request
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // get bearer token
            var responseContent = await response.Content.ReadAsAsync<Dictionary<string, string>>();
            string bearerToken = responseContent["access_token"];

            // enable bearer token to be send in all further requests, e.g.
            // GET /api/search HTTP/1.1
            // Host: server.hes.com
            // Authorization: Bearer 2YotnFZFEjr1zCsicMWpAA
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }
    }
}
