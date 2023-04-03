using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcmeCorp.Service.Model
{
    [Table("tblCustomer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
    }
}
