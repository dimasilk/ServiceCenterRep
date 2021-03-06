﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenter.Auth.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}