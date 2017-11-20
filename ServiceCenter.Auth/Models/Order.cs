using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenter.Auth.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Device { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public bool Urgently { get; set; }

        public Guid IdUserCreated { get; set; }

        public Guid StatusId { get; set; }
        public OrderStatus Status { get; set; }
        //public virtual ICollection<Pricelist> Pricelist { get; set; }
        public virtual ICollection<PricelistOrders> PricelistOrders { get; set; }

        public Order()
        {
            PricelistOrders = new List<PricelistOrders>();
        }

    }
}
