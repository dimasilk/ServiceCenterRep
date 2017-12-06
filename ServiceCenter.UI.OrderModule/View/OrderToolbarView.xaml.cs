using System.Windows.Controls;
using ServiceCenter.UI.OrderModule.ViewModel;

namespace ServiceCenter.UI.OrderModule.View
{
    /// <summary>
    /// Логика взаимодействия для OrderToolbarView.xaml
    /// </summary>
    public partial class OrderToolbarView : UserControl
    {
        public OrderToolbarView(OrderToolbarViewModel orderToolbarViewModel)
        {
            InitializeComponent();
            DataContext = orderToolbarViewModel;
        }
    }
}
