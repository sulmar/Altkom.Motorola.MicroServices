using Microsoft.AspNetCore.SignalR.Client;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.FakeServices.Fakers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(() => SignalRClientTestAsync());

            Task.Run(()=> GetOrdersTestAsync());

            Task.Run(()=> AddOrderTestAsync());

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }


        private static async Task SignalRClientTestAsync()
        {
            string url = "http://localhost:5000/hubs/orders";

            // add package Microsoft.AspNetCore.SignalR.Client

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine("Connected.");

            var orderFaker = new OrderFaker();

            while (true)
            {
                Order order = orderFaker.Generate();

                await connection.SendAsync("AddedOrder", order);

                Console.WriteLine("Sent order");

                // Task.Delay(10);

                await Task.Delay(TimeSpan.FromSeconds(1));
            }




        }
       

        private static async Task AddOrderTestAsync()
        {
            var orderFaker = new OrderFaker();

            var order = orderFaker.Generate();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");

                client.DefaultRequestHeaders.Add("key", "Hello");

                var response = await client.PostAsJsonAsync<Order>("api/orders", order);

                response.EnsureSuccessStatusCode();

            }
        }

            private static async Task GetOrdersTestAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");

                var response = await client.GetAsync("api/orders");

                if (response.IsSuccessStatusCode)
                {
                    // var content = await response.Content.ReadAsStringAsync();

                    var orders = await response.Content.ReadAsAsync<IEnumerable<Order>>();

                    // add package Microsoft.AspNet.WebApi.Client
                }
            }
        }
    }
}
