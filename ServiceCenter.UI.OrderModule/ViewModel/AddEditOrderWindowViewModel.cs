using System;
using System.Linq;
using ServiceCenter.BL.Common;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.Infrastructure.Interfaces;
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
        public AddEditOrderWindowViewModel(OrderDTO item, IWcfOrderService serviceClient, IUserIdService userIdService)
        {
            Item = item ?? new OrderDTO();
            _serviceClient = serviceClient;
            _userIdService = userIdService;

            GetStatuses();
        }

        private readonly IWcfOrderService _serviceClient;
        private readonly IUserIdService _userIdService;
        
        public override void OkClick(object o)
        {
            DialogResultData = Item;
            if (Item.IdUserCreated == Guid.Empty) Item.IdUserCreated = _userIdService.GetCreatorId();
            base.OkClick(o);
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
