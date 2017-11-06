using System.Windows;
using ServiceCenter.UI.OrderModule.ViewModel;

namespace ServiceCenter.UI.OrderModule.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : Window
    {
        public AddEditOrderWindow(AddEditOrderWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
