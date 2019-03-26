using Motorola.MotoTaxi.Orders.DomainModels;
using System;

namespace Motorola.MotoTaxi.Orders.IServices
{

    public interface IOrderService : IEntityService<Order>
    {        
        void Confirm(int id);
        void Start(int id, Location start);
        void Cancel(int id);
        void Complete(int id, Location destination);
    }
}
