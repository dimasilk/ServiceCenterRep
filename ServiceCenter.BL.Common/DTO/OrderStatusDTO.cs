﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class OrderStatusDTO
    {
        public OrderStatusDTO() { }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string StatusValue { get; set; }
    }
}
