using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = orderService.Get();

            return Ok(orders);
        }

        // api/orders/100
        [HttpGet]
        [Route("{number}")]
        public IActionResult Get(string number)
        {
            return Ok($"Hello World {number}");
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Order order = orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            orderService.Add(order);

            return CreatedAtRoute(new { id = order.Id }, order);
        }

       
    }
}
