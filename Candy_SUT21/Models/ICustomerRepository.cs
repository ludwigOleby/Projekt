using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
