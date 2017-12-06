using System.Runtime.Serialization;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class CompanyFilterDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public string Adress { get; set; }
    }
}
