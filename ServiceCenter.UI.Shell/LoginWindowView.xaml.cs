using System.Windows;
using ServiceCenter.UI.Infrastructure.Interfaces;

namespace ServiceCenter.UI.Shell
{
    /// <summary>
    /// Логика взаимодействия для LoginWindowView.xaml
    /// </summary>
    public partial class LoginWindowView : Window
    {
        public LoginWindowView(LoginWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
