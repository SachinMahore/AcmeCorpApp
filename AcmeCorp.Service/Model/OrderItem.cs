using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcmeCorp.Service.Model
{
    [Table("tblOrderItem")]
    public class OrderItem
    {
        [Key]
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }

        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
