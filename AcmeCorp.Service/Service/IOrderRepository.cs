using AcmeCorp.Service.Model;
using AcmeCorp.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Service.Service
{
   public interface IOrderRepository
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrderAsync();
        Task<OrderViewModel> GetOrderByOrderIdAsync(int orderId);
        Task<OrderViewModel> AddOrderAsync(OrderViewModel order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(long orderId);
    }
}
