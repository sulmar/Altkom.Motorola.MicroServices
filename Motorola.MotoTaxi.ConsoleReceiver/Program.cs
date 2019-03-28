using Microsoft.AspNetCore.SignalR.Client;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.ConsoleReceiver
{
    class Program
    { 
        
        
        // add package Microsoft.AspNetCore.SignalR.Client

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(()=>TestAsync());

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static async Task TestAsync()
        {
            string url = "http://localhost:5000/hubs/orders";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine("Connected.");

            Console.BackgroundColor = ConsoleColor.Blue;

            connection.On<Order>("Added",
                order => Console.WriteLine($"Received order Id={order.Id}"));

            
        }
    }
}
