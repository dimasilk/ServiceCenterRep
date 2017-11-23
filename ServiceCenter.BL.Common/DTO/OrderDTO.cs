using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using ServiceCenter.BL.Common.Annotations;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class OrderDTO : INotifyPropertyChanged
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

        [DataMember]
        public Guid IdUserCreated { get; set; }
        [DataMember]
        public DateTime? DateRecieved { get; set; }
        [DataMember]
        public DateTime? DateReady { get; set; }

        [DataMember]
        public OrderStatusDTO Status { get; set; }
        [DataMember]
        public CustomerDTO Customer { get; set; }
        [DataMember]
        public CompanyDTO Company { get; set; }
        [DataMember]
        public ICollection<PricelistDTO> PricelistItems { get; set; } = new PricelistDTO[0];


        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
