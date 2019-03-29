using System;
using System.Collections.Generic;
using System.Text;

namespace Motorola.MotoTaxi.Orders.DomainModels
{
    public class User : Base
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
