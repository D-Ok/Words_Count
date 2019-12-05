using System.Windows.Controls;
using Tester.Tools.Navigation;
using Tester.ViewModels;

namespace Tester.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowRequestsView.xaml
    /// </summary>
    public partial class ShowRequestsView : UserControl, INavigatable
    {
        public ShowRequestsView()
        {
            InitializeComponent();
            DataContext = new ShowRequestsViewModel();
    }
    }
}
