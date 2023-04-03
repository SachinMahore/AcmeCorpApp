using AcmeCorp.Service.Data;
using AcmeCorp.Service.Model;
using AcmeCorp.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeCorp.Service.SolidClassess
{
    //Use SRP here
    public class OrderItemList
    {
        private readonly AcmeCorpDbContext _appDbContext;
        public OrderItemList(AcmeCorpDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<OrderItem> GetOrderItemList(long orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems =_appDbContext.OrderItems.Where(p => p.OrderId == orderId).ToList();            
            return orderItems;
        }
    }
}
