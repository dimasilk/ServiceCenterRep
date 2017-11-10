using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;


namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddEditOrderWindowViewModel : BaseDialogViewModel
    {
        public OrderDTO Item { get; set; }
        public OrderStatusDTO[] Statuses { get; set; }
        public AddEditOrderWindowViewModel(OrderDTO item, IWcfOrderService serviceClient)
        {
            Item = item ?? new OrderDTO();
            _serviceClient = serviceClient;
            GetStatuses();
        }

        private IWcfOrderService _serviceClient;

        public override void OkClick()
        {
            DialogResultData = Item;
            base.OkClick();
        }
        private async void GetStatuses()
        {
            Statuses = await _serviceClient.GetOrderStatuses();
        }
    }
}
