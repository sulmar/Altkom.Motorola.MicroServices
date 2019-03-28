using Microsoft.AspNetCore.SignalR;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Orders.Api.Hubs
{
    public class OrdersHub : Hub
    {
        public Task AddedOrder(Order order)
        {
            return this.Clients.All.SendAsync("Added", order);

            // return this.Clients.Others.SendAsync("Added", order);
        }


        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
