﻿using System;
using System.Runtime.Serialization;
using ServiceCenter.Auth.Models;

namespace ServiceCenter.BL.Common.DTO
{
    [DataContract]
    public class OrderDTO
    {
        public OrderDTO() { }
        public OrderDTO(Order dataModel)
        {
            this.Id = dataModel.Id;
            this.Device = dataModel.Device;
            this.Manufacturer = dataModel.Manufacturer;
            this.SerialNumber = dataModel.SerialNumber;
            this.Urgently = dataModel.Urgently;
            this.DeviceModel = dataModel.DeviceModel;
        }

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


        public virtual void CopyTo(Order dataModel)
        {
            dataModel.Id = this.Id;
            dataModel.Device = this.Device;
            dataModel.Manufacturer = this.Manufacturer;
            dataModel.SerialNumber = this.SerialNumber;
            dataModel.Urgently = this.Urgently;
            dataModel.DeviceModel = this.DeviceModel;
        }

    }
}
