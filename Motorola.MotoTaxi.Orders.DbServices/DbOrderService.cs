using Microsoft.EntityFrameworkCore;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Motorola.MotoTaxi.Orders.DbServices
{
    public class DbOrderService : IOrderService
    {
        private readonly OrdersContext context;

        public DbOrderService(OrdersContext context)
        {
            this.context = context;
        }

        public void Add(Order entity)
        {
            Trace.WriteLine(context.Entry(entity).State);

            context.Orders.Add(entity);

            // context.Entry(entity).State = EntityState.Unchanged;

            Trace.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Trace.WriteLine(context.Entry(entity).State);

            entity.Status = OrderStatus.Canceled;

            // ręczne sterowanie
            // context.Orders.Update(entity);

            Trace.WriteLine(context.Entry(entity).State);
        }

        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public void Complete(int id, Location destination)
        {
            var order = Get(id);

            order.Status = OrderStatus.Completed;

            context.SaveChanges();
        }

        public void Confirm(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return context.Orders
                .FromSql($"select * from dbo.Orders where id={id}")
                .SingleOrDefault();
        }

        public IEnumerable<Order> Get()
        {
            // return context.Orders.FromSql("select * from dbo.Orders").ToList();

            return context.Orders.AsNoTracking().ToList();
        }

        public void Start(int id, Location start)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            //var order = context.Orders.SingleOrDefault(o => o.Id == entity.Id);

            //order.Destination = entity.Destination;
            //order.CustomerId = entity.CustomerId;

            //context.Orders.Attach(entity);
            //context.Entry(entity).State = EntityState.Modified;

            context.Orders.Update(entity);
            context.SaveChanges();
        }
    }
}
