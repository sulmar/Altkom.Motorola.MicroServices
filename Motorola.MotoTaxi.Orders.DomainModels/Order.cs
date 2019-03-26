using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Orders.DomainModels
{
    public class Order : Base
    {
        public int Id { get; set; }
        public Location Start { get; set; }
        public Location Destination { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int? DriverId { get; set; }
        public OrderStatus Status { get; set; }


        public Order()
        {
            Status = OrderStatus.New;
            OrderDate = DateTime.Now;
        }
    }
}
