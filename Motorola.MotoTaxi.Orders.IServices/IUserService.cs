using Motorola.MotoTaxi.Orders.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Orders.IServices
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
