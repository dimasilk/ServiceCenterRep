using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenter.Auth.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Company()
        {
            Orders = new List<Order>();
        }
    }
}