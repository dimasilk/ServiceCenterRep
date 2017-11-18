﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.Auth.Models
{
    public class Pricelist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
     
        public string Name { get; set; }
        public double? Price { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<Pricelist> Items { get; set; } 
    }
}
