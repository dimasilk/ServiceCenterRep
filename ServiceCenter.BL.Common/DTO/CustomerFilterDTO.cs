using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class CustomerFilterDTO
    {
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
