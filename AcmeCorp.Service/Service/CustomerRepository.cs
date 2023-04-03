using AcmeCorp.Service.Data;
using AcmeCorp.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AcmeCorpDbContext _appDbContext;
        public CustomerRepository(AcmeCorpDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            var CustomerList = await _appDbContext.Customers.ToListAsync();
            return CustomerList;
        }

        public async Task<Customer> GetCustomerByCustomerIdAsync(int CustomerId)
        {
            var result = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<Customer> AddCustomerAsync(Customer Customer)
        {
            _appDbContext.Customers.Add(Customer);
            await _appDbContext.SaveChangesAsync();
            return Customer;
        }


        public async Task<Customer> DeleteCustomerAsync(int CustomerId)
        {
            var result = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
            if (result == null)
            {
                return null;
            }


             _appDbContext.Customers.Remove(result);
             await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _appDbContext.Customers.Update(customer);
            await _appDbContext.SaveChangesAsync();
            return customer;

        }
    }
}
