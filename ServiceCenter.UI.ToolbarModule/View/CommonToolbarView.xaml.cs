using System.Windows.Controls;
using ServiceCenter.UI.ToolbarModule.ViewModel;

namespace ServiceCenter.UI.ToolbarModule.View
{
    /// <summary>
    /// Логика взаимодействия для OrderToolbarView.xaml
    /// </summary>
    public partial class CommonToolbarView : UserControl
    {
        public CommonToolbarView(CommonToolbarViewModel toolbarViewModel)
        {
            InitializeComponent();
            DataContext = toolbarViewModel;
        }
    }
}
