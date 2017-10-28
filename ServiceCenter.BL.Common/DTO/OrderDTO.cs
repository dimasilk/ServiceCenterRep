using System;
using System.Runtime.Serialization;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class OrderDTO
    {
        public OrderDTO() { }
        
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public string DeviceModel { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public bool Urgently { get; set; }

    }
}
