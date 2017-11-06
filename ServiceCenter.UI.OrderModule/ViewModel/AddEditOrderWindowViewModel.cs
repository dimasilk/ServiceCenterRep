using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddEditOrderWindowViewModel : BaseDialogViewModel
    {
        public AddEditOrderWindowViewModel(OrderDTO item)
        {
            Item = item ?? new OrderDTO();
        }

        public OrderDTO Item { get; set; }

        public override void OkClick()
        {
            DialogResultData = Item;
            base.OkClick();
        }
    }
}
