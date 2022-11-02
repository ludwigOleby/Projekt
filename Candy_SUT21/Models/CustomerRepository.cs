using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Customer> GetCustomerByApplicationUserId(string id)
        {
            var user = await _appDbContext.Users.Include(c => c.Customer).FirstOrDefaultAsync(u => u.Id == id);
            return user.Customer;
        }

        public Task<IEnumerable<Customer>> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            if (await _appDbContext.Customers.AsNoTracking().
                FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId) == null)
                return null;
            var result = _appDbContext.Customers.Update((customer));
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
