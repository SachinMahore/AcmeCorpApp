using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcmeCorp.Service.Model
{
    [Table("tblOrder")]
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
  
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ContactId { get; set; }
        public decimal Amount { get; set; }
    }
}
