using AcmeCorp.Service.Data;
using AcmeCorp.Service.Model;
using AcmeCorp.Service.SolidClassess;
using AcmeCorp.Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AcmeCorpDbContext _appDbContext;
        public OrderRepository(AcmeCorpDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<OrderViewModel>> GetAllOrderAsync()
        {
           
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            List<Order> orders = new List<Order>();
            orders = await _appDbContext.Orders.ToListAsync();
            List<OrderItem> orderItems = new List<OrderItem>();
            
            if(orders != null)
            {
                foreach (var ord in orders)
                {
                    OrderViewModel orderViewModel = new OrderViewModel();
                    OrderItemList orderItemList = new OrderItemList(_appDbContext);
                    //Get the items in order
                    orderItems = orderItemList.GetOrderItemList(ord.OrderId);

                    orderViewModel.OrderId = ord.OrderId;
                    orderViewModel.OrderDate = ord.OrderDate;
                    orderViewModel.DeliveryDate = ord.DeliveryDate;
                    orderViewModel.OrderDate = ord.OrderDate;
                    orderViewModel.Amount = ord.Amount;
                    orderViewModel.OrderItems = orderItems;
                    orderViewModel.ContactId = ord.ContactId;

                    orderViewModels.Add(orderViewModel);
                }
               
            }

            
            return orderViewModels;
        }

        public async Task<OrderViewModel> GetOrderByOrderIdAsync(int OrderId)
        {
            var ord = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);
            if (ord == null)
            {
                return null;
            }
            OrderViewModel orderViewModel = new OrderViewModel();
            OrderItemList orderItemList = new OrderItemList(_appDbContext);

            orderViewModel.OrderId = ord.OrderId;
            orderViewModel.OrderDate = ord.OrderDate;
            orderViewModel.DeliveryDate = ord.DeliveryDate;
            orderViewModel.OrderDate = ord.OrderDate;
            orderViewModel.Amount = ord.Amount;
            orderViewModel.OrderItems = orderItemList.GetOrderItemList(OrderId);
            orderViewModel.ContactId = ord.ContactId;


            return orderViewModel;
        }

        public async Task<OrderViewModel> AddOrderAsync(OrderViewModel order)
        {
            Order orderDet = new Order();          
            orderDet.CustomerId = order.CustomerId;
            orderDet.DeliveryDate = order.DeliveryDate;
            orderDet.OrderDate = order.OrderDate;
            orderDet.Amount = order.Amount;
            orderDet.ContactId = order.ContactId;
            _appDbContext.Orders.Add(orderDet);
            await _appDbContext.SaveChangesAsync();
            // get Order Id from above order to pass Order Item
            long getOrderId = orderDet.OrderId;
            if (order.OrderItems != null)
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach(var item in order.OrderItems)
                {
                    item.OrderId = getOrderId;
                    orderItems.Add(item);
                }
                _appDbContext.OrderItems.AddRange(order.OrderItems);
                await _appDbContext.SaveChangesAsync();
            }
            
            return order;
        }


        public async Task<Order> DeleteOrderAsync(long orderId)
        {
            var ord = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (ord == null)
            {
                return null;
            }
            OrderViewModel orderViewModel = new OrderViewModel();
            OrderItemList orderItemList = new OrderItemList(_appDbContext);
            // Remove ordder items
            _appDbContext.OrderItems.RemoveRange(orderItemList.GetOrderItemList(orderId));
            // Remove ordder
            _appDbContext.Orders.Remove(ord);
            await _appDbContext.SaveChangesAsync();
            return ord;
        }
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _appDbContext.Orders.Update(order);
            await _appDbContext.SaveChangesAsync();
            return order;

        }
    }
}
