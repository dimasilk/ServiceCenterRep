using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
