using Northwind.Models.Models;
using Northwind.Repositorie;
using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
    }
}
