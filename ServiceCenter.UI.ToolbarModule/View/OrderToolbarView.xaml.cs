using System.Windows.Controls;
using ServiceCenter.UI.ToolbarModule.ViewModel;

namespace ServiceCenter.UI.ToolbarModule.View
{
    /// <summary>
    /// Логика взаимодействия для OrderToolbarView.xaml
    /// </summary>
    public partial class OrderToolbarView : UserControl
    {
        public OrderToolbarView(OrderToolbarViewModel toolbarViewModel)
        {
            InitializeComponent();
            DataContext = toolbarViewModel;
        }
    }
}
