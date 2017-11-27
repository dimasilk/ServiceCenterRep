using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class CustomerItemViewModel
    {
        public CustomerItemViewModel(CustomerDTO customerDto)
        {
            Item = customerDto;
        }
        public CustomerDTO Item { get; set; }
    }
}
