using AcmeCorp.Service.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCorp.Service.ViewModel
{
    public class OrderViewModel
    {
        [JsonIgnore]
        public long OrderId { get; set; }

        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ContactId { get; set; }
        public decimal Amount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
