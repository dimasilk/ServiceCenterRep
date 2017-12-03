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
