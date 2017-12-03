using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using ServiceCenter.UI.Infrastructure.AggregatedEvent;

namespace ServiceCenter.UI.ToolbarModule.ViewModel
{
    public class CommonToolbarViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public CommonToolbarViewModel(IEventAggregator eventAggregator)
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
            _eventAggregator.GetEvent<AddEntityEvent>().Publish(null);
        }

        public void EditClickMethod()
        {
            _eventAggregator.GetEvent<EditEntityEvent>().Publish(null);
        }

        public void DeleteClickMethod()
        {
            _eventAggregator.GetEvent<DeleteEntityEvent>().Publish(null);
        }
    }
}
