using System;
using System.Runtime.Serialization;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class OrderFilterDTO
    {
        [DataMember]
        public CustomerDTO Customer { get; set; }
        [DataMember]
        public CompanyDTO Company { get; set; }
        [DataMember]
        public DateTime? FromDateRecieved { get; set; }
        [DataMember]
        public DateTime? TillDateRecieved { get; set; }
        [DataMember]
        public bool Urgently { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public OrderStatusDTO Status { get; set; }
    }
}
