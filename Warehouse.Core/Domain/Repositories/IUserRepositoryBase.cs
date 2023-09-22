using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.Domain.Repositories
{
    public interface IUserRepositoryBase
    {
        User Get(string userName);
    }
}