using Northwind.Models.Models;
using Northwind.Repositorie;

namespace Northwind.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
