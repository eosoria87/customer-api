using System.Collections.Generic;

namespace Northwind.Repositorie
{ 
    public interface IRepository<T> where T:class
    {
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);
    }
}
