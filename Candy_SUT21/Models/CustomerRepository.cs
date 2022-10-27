using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext customers)
        {
            _appDbContext = customers;
        }

        public Task<Customer> CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            return customer;
        }

        public Task<IEnumerable<Customer>> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
