using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.DataModels;

namespace ServiceCenter.BL.DTO
{
    public class OrderDTO
    {
        public OrderDTO() { }
        public OrderDTO(OrderDataModel dataModel)
        {
            this.Id = dataModel.Id;
            this.Device = dataModel.Device;
            this.Manufacturer = dataModel.Manufacturer;
            this.SerialNumber = dataModel.SerialNumber;
            this.Urgently = dataModel.Urgently;
            this.DeviceModel = dataModel.DeviceModel;
        }

        public string Id { get; set; }
        public string Device { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public bool Urgently { get; set; }


        internal virtual void CopyTo(OrderDataModel dataModel)
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
