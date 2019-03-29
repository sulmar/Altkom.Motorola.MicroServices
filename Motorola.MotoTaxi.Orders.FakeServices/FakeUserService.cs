using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motorola.MotoTaxi.Orders.FakeServices
{
    public class FakeUserService : IUserService
    {
        private IEnumerable<User> users;

        public FakeUserService()
        {

            users = new List<User>
            {
                new User { Id = 1, UserName = "marcin", Password = "1234", Email = "marcin.sulecki@altkom.pl"},
                new User { Id = 2, UserName = "sa", Password = "sa"},
                new User { Id = 3, UserName = "bartek", Password = "%3c6N!5"},
            };
        }

        public User Authenticate(string username, string password)
        {
            var user = users
                .SingleOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null)
                return null;

            user.Password = null;

            return user;
        }
    }
}
