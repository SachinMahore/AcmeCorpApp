using AcmeCorp.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerByCustomerIdAsync(int CustomerId);
        Task<Customer> AddCustomerAsync(Customer Customer);
        Task<Customer> UpdateCustomerAsync(Customer Customer);
        Task<Customer> DeleteCustomerAsync(int CustomerId);

    }
}
