using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.CompanyModule.ViewModel
{
    public class AddEditCompanyWindowViewModel : BaseDialogViewModel
    {
        public AddEditCompanyWindowViewModel(CompanyDTO item)
        {
            Item = item ?? new CompanyDTO();
        }
        public CompanyDTO Item { get; set; }

        public override void OkClick(object o)
        {
            DialogResultData = Item;
            // if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
        }
    }
}
