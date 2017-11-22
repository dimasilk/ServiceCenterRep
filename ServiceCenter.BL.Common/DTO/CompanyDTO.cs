using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using ServiceCenter.BL.Common.Annotations;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class CompanyDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public ICollection<OrderDTO> Orders { get; set; }
    }
}