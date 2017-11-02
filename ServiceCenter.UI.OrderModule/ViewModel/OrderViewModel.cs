using System;
using Microsoft.Practices.Prism.Mvvm;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderViewModel : BindableBase
    {
        public Guid Id { get; set; }
        public string Device { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public bool Urgently { get; set; }
    }
}
