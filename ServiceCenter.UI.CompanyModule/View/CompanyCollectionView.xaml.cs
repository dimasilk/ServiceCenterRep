using System.Windows.Controls;
using ServiceCenter.UI.CompanyModule.ViewModel;

namespace ServiceCenter.UI.CompanyModule.View
{
    /// <summary>
    /// Логика взаимодействия для CompanyCollectionView.xaml
    /// </summary>
    public partial class CompanyCollectionView : UserControl
    {
        public CompanyCollectionView(CompanyCollectionViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
