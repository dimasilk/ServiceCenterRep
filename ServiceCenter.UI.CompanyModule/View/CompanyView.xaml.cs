using System.Windows;
using ServiceCenter.UI.CompanyModule.ViewModel;

namespace ServiceCenter.UI.CompanyModule.View
{
    /// <summary>
    /// Логика взаимодействия для CompanyView.xaml
    /// </summary>
    public partial class CompanyView : Window
    {
        public CompanyView(AddEditCompanyWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
