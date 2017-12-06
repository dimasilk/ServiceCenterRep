using System.Windows;
using ServiceCenter.UI.CustomerModule.ViewModel;

namespace ServiceCenter.UI.CustomerModule.View
{
    /// <summary>
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        public CustomerView(AddEditCustomerWindowViewModel windowViewModel)
        {
            InitializeComponent();
            DataContext = windowViewModel;
        }
    }
}
