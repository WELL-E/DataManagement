using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;

namespace DataManagement.Repository
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@CustomerEmail", entity.CustomerEmail);
                parameters.Add("@CustomerMobile", entity.CustomerMobile);
                SqlMapper.Execute(Conn, "AddCustomer", parameters, commandType:CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", id);
            SqlMapper.Execute(Conn, "DeleteCustomer", parameters, commandType:CommandType.StoredProcedure);
        }
        public IEnumerable<Customer> Get()
        {
            IList<Customer> customerList = SqlMapper.Query<Customer>(Conn, "GetAllCustomer", CommandType.StoredProcedure).ToList();
            return customerList;
        }
        public Customer Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerID", id);
            return SqlMapper.Query<Customer>(Conn, "GetCustomerById", parameters, commandType:CommandType.StoredProcedure).FirstOrDefault();
        }
        public void Update(Customer entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerID", entity.CustomerName);
            parameters.Add("@CustomerName", entity.CustomerName);
            parameters.Add("@CustomerEmail", entity.CustomerEmail);
            parameters.Add("@CustomerMobile", entity.CustomerMobile);
            SqlMapper.Execute(Conn, "UpdateCustomer", parameters, commandType:CommandType.StoredProcedure);
        }
    }
}
