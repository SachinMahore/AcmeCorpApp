using AcmeCorp.Service.Model;
using AcmeCorp.Service.Service;
using AcmeCorpApp.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AcmeCorp.Test
{
    public class CustomerUnitTestController
    {
        private readonly Mock<ICustomerRepository> customerService;
        private readonly ILogger<CustomerController> _loggerCustomer;
        public CustomerUnitTestController()
        {
            customerService = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void GetCustomerList_CustomerList()
        {
            //arrange
            var CustomerList = GetCustomersData();
            customerService.Setup(x => x.GetAllCustomerAsync())
                .ReturnsAsync(CustomerList);
            var CustomerController = new CustomerController(customerService.Object, _loggerCustomer);

            //act
            var CustomerResult = CustomerController.GetAllCustomerAsync();

            //assert
            Assert.NotNull(CustomerResult);
            //Assert.Equal(GetCustomersData().ToString(), CustomerResult.ToString());
           // Assert.True(CustomerList.Equals(CustomerResult));
        }

        [Fact]
        public void GetCustomerByID_Customer()
        {
            //arrange
            var CustomerList = GetCustomersData();
            customerService.Setup(x => x.GetCustomerByCustomerIdAsync(2))
                .ReturnsAsync(CustomerList[1]);
            var CustomerController = new CustomerController(customerService.Object, _loggerCustomer);

            //act
            var CustomerResult = CustomerController.GetCustomerByCustomerIdAsync(2);

            //assert
            Assert.NotNull(CustomerResult);
        }

      
        [Fact]
        public async void AddCustomer_Customer()
        {
            //arrange
            var CustomerList = GetCustomersData();
            customerService.Setup(x => x.AddCustomerAsync(CustomerList[2]))
                .ReturnsAsync(CustomerList[2]);
            var CustomerController = new CustomerController(customerService.Object, _loggerCustomer);

            //act
            var CustomerResult =await CustomerController.AddCustomerAsync(CustomerList[2]);

            //assert
            Assert.NotNull(CustomerResult);
        }


        private List<Customer> GetCustomersData()
        {
            List<Customer> CustomersData = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                CustomerName = "Sachin Mahore",
                EmailId = "sachinmahore@gmail.com",
                Mobile = "8600873002"
                
            },
             new Customer
            {
                CustomerId = 2,
                CustomerName = "Nikhil Mahore",
                EmailId = "nikhilmahore@gmail.com",
                Mobile = "9096119134"
            },
             new Customer
            {
                 CustomerId = 3,
                CustomerName = "Dharvik Mahore",
                EmailId = "dharvikmahore@gmail.com",
                Mobile = "7867878787"
            },
        };
            return CustomersData;
        }
    }
}
