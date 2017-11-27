using System.Windows.Controls;
using ServiceCenter.UI.CustomerModule.ViewModel;

namespace ServiceCenter.UI.CustomerModule.View
{
    /// <summary>
    /// Логика взаимодействия для CustomerCollectionView.xaml
    /// </summary>
    public partial class CustomerCollectionView : UserControl
    {
        public CustomerCollectionView(CustomerCollectionViewModel customerCollectionViewModel)
        {
            InitializeComponent();
            DataContext = customerCollectionViewModel;
        }
    }
}
