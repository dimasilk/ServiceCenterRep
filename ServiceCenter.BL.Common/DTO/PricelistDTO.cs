using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class PricelistDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid? ParentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
