using System.Linq;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.ViewModel;


namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class AddEditOrderWindowViewModel : BaseDialogViewModel
    {
        public OrderDTO Item { get; set; }

        private OrderStatusDTO[] _statuses;
        public OrderStatusDTO[] Statuses
        {
            get { return _statuses; }
            set { SetProperty(ref _statuses, value); }
        }
        public AddEditOrderWindowViewModel(OrderDTO item, IWcfOrderService serviceClient)
        {
            Item = item ?? new OrderDTO();
            _serviceClient = serviceClient;
            GetStatuses();
        }

        private readonly IWcfOrderService _serviceClient;

        public override void OkClick()
        {
            DialogResultData = Item;
            base.OkClick();
        }
        private async void GetStatuses()
        {
            Statuses = await _serviceClient.GetOrderStatuses();
            if (Item.Status == null) return;
            Item.Status = Statuses.FirstOrDefault(x => x.Id == Item.Status.Id);
            Item.OnPropertyChanged(nameof(Item.Status));
            
        }
    }
}
