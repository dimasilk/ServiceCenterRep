using System.Windows;
using System.Windows.Controls;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.UI.OrderModule.ViewModel;

namespace ServiceCenter.UI.OrderModule.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : UserControl
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            DataContext = new OrderItemViewModel(new OrderDTO());
        }
    }
}
