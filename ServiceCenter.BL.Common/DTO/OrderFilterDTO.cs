using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public OrderStatusDTO Status { get; set; }
    }
}
