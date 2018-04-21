using System.Collections.Generic;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Api.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customerRepository.Add(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            _customerRepository.Update(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}