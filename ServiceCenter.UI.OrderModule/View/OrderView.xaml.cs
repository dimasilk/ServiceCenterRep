using System.Windows.Controls;
using ServiceCenter.UI.OrderModule.ViewModel;

namespace ServiceCenter.UI.OrderModule.View
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView(OrderViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
