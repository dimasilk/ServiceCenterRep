using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.Auth.Models
{
    public class PricelistOrders
    {
        [Key, Column(Order = 0)]
        public Guid Pricelist_Id { get; set; }
        [Key, Column(Order = 1)]
        public Guid Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        [ForeignKey("Pricelist_Id")]
        public Pricelist Pricelist { get; set; }
    }
}
