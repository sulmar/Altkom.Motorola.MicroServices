using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Motorola.MotoTaxi.Orders.Api.Controllers
{
    [Route("api/[controller]")]
   // [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;

        }

        [HttpGet]
       // [Authorize(Roles = "boss, driver")]
        public IActionResult Get()
       {
            var orders = orderService.Get();

            if (this.User.IsInRole("driver"))
            {
                var driverId = int.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                orders = orders.Where(o => o.DriverId == driverId).ToList();
            }

            return Ok(orders);

            //if (this.User.Identity.IsAuthenticated)
            //{
            //    string email = this.User.FindFirst(ClaimTypes.Email).Value;

            //    var orders = orderService.Get();
            //    return Ok(orders);
            //}
            //else
            //{
            //    return Unauthorized();
            //}

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
        [AllowAnonymous]
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
