using System.Runtime.Serialization;

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
