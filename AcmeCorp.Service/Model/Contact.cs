using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcmeCorp.Service.Model
{
    [Table("tblCustomerContact")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
    }
}
