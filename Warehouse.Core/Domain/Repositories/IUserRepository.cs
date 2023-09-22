using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.Domain.Repositories
{
    public class IUserRepository
    {
        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        public void Add(User user) { }

      
    }
}
