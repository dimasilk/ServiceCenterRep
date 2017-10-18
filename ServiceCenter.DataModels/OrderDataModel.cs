using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.DataModels
{
    public class OrderDataModel
    {
        public string Id { get; set; }
        public string Device { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public bool Urgently { get; set; }

    }
}
