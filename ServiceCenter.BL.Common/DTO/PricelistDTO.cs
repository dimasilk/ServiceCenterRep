using System;
using System.Runtime.Serialization;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class PricelistDTO
    {
        public PricelistDTO() { }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid? ParentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        
    }
}
