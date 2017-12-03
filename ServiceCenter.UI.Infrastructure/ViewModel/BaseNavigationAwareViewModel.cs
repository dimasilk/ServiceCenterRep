using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using ServiceCenter.UI.Infrastructure.AggregatedEvent;

namespace ServiceCenter.UI.Infrastructure.ViewModel
{
    public abstract class BaseNavigationAwareViewModel : BaseViewModel, INavigationAware
    {
        private readonly DeleteEntityEvent _delete;
        private readonly EditEntityEvent _edit;
        private readonly AddEntityEvent _add;

        protected BaseNavigationAwareViewModel(IEventAggregator eventAggregator)
        {
            _delete = eventAggregator.GetEvent<DeleteEntityEvent>();
            _add = eventAggregator.GetEvent<AddEntityEvent>();
            _edit = eventAggregator.GetEvent<EditEntityEvent>();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _delete.Subscribe(DeleteEntity);
           _add.Subscribe(AddEntity);
            _edit.Subscribe(EditEntity);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _delete.Unsubscribe(DeleteEntity);
            _add.Unsubscribe(AddEntity);
            _edit.Unsubscribe(EditEntity);
        }

        protected virtual void DeleteEntity(object parametr) { }
        protected virtual void AddEntity(object parametr) { }
        protected virtual void EditEntity(object parametr) { }
    }
}
