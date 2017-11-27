using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using ServiceCenter.UI.Infrastructure.AggregatedEvent;

namespace ServiceCenter.UI.Infrastructure.ViewModel
{
    public abstract class BaseNavigationAwareViewModel : BindableBase, INavigationAware
    {
        private readonly DeleteOrderEvent _delete;
        private readonly EditOrderEvent _edit;
        private readonly AddOrderEvent _add;

        protected BaseNavigationAwareViewModel(IEventAggregator eventAggregator)
        {
            _delete = eventAggregator.GetEvent<DeleteOrderEvent>();
            _add = eventAggregator.GetEvent<AddOrderEvent>();
            _edit = eventAggregator.GetEvent<EditOrderEvent>();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _delete.Subscribe(DeleteOrder);
           _add.Subscribe(AddOrder);
            _edit.Subscribe(EditOrder);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _delete.Unsubscribe(DeleteOrder);
            _add.Unsubscribe(AddOrder);
            _edit.Unsubscribe(EditOrder);
        }

        protected virtual void DeleteOrder(object parametr) { }
        protected virtual void AddOrder(object parametr) { }
        protected virtual void EditOrder(object parametr) { }
    }
}
