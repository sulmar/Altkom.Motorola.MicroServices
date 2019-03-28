using Bogus;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Orders.FakeServices.Fakers
{
    public class OrderFaker : Faker<Order>
    {
        // snippet: ctor
        public OrderFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.OrderDate, 
                f => f.Date.Between(DateTime.Parse("2019-03-25"), DateTime.Parse("2019-03-29")));

            RuleFor(p => p.Status, f => f.PickRandom<OrderStatus>());
            //RuleFor(p => p.Start.Latitude, f => f.Address.Latitude(53, 55));
            //RuleFor(p => p.Start.Longitude, f => f.Address.Longitude(19, 21));

            RuleFor(p => p.Start, f =>
                new Location
                {
                    Latitude = f.Address.Latitude(53, 55),
                    Longitude = f.Address.Longitude(19, 21)
                });

            RuleFor(p => p.DriverId, f => f.Random.Int(0, 10));
            RuleFor(p => p.CustomerId, f => f.Random.Int(0, 10000));

            // Ignore(p => p.Destination);

            RuleFor(p => p.Destination, f =>
                new Location
                {
                    Latitude = f.Address.Latitude(53, 55),
                    Longitude = f.Address.Longitude(19, 21)
                });

        }
    }

   
}
