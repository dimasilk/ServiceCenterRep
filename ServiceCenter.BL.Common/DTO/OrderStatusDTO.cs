using System;
using System.Runtime.Serialization;

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
