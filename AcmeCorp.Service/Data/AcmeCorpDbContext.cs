using AcmeCorp.Service.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCorp.Service.Data
{
    public class AcmeCorpDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AcmeCorpDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("AcmeCorpDbConnection"));
        }
        public DbSet<Customer> Customers
        {
            get;
            set;
        }
        public DbSet<Contact> Contacts
        {
            get;
            set;
        }
        public DbSet<Order> Orders
        {
            get;
            set;
        }
        public DbSet<OrderItem> OrderItems
        {
            get;
            set;
        }
    }
}
