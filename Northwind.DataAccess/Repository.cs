using Dapper.Contrib.Extensions;
using Northwind.Repositorie;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Northwind.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $" {type.Name} "; };
            _connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Delete(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Get<T>(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetList()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.GetAll<T>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return (int)connection.Insert(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Update<T>(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
