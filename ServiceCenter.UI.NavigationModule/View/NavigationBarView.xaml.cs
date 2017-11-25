using System.Windows.Controls;
using ServiceCenter.UI.NavigationModule.ViewModel;

namespace ServiceCenter.UI.NavigationModule.View
{
    /// <summary>
    /// Логика взаимодействия для NavigationBarView.xaml
    /// </summary>
    public partial class NavigationBarView : UserControl
    {
        public NavigationBarView(NavigationBarViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
