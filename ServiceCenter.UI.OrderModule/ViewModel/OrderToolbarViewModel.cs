using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using ServiceCenter.UI.OrderModule.AggregatedEvent;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderToolbarViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public OrderToolbarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            DeleteClick = new DelegateCommand(DeleteClickMethod);
            AddClick = new DelegateCommand(AddClickMethod);
            EditClick = new DelegateCommand(EditClickMethod);
        }
        public ICommand AddClick { get; set; }
        public ICommand DeleteClick { get; set; }
        public ICommand EditClick { get; set; }

        public void AddClickMethod()
        {
            _eventAggregator.GetEvent<AddOrderEvent>().Publish(null);
        }

        public void EditClickMethod()
        {
            _eventAggregator.GetEvent<EditOrderEvent>().Publish(null);
        }

        public void DeleteClickMethod()
        {
            _eventAggregator.GetEvent<DeleteOrderEvent>().Publish(null);
        }
    }
}
