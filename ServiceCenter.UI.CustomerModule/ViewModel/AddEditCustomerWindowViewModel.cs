using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CustomerModule.ViewModel
{
    public class AddEditCustomerWindowViewModel : BaseDialogViewModel
    {
        private readonly IWcfCustomerService _customerService;

        public AddEditCustomerWindowViewModel(CustomerDTO item, IWcfCustomerService customerService)
        {
            _customerService = customerService;
            Item = item ?? new CustomerDTO();
        }
        public CustomerDTO Item { get; set; }

        public override void OkClick(object o)
        {
            DialogResultData = Item;
           // if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }
    }
}
