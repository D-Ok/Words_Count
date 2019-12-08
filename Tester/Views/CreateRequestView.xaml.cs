using System.Windows.Controls;
using Tester.Tools.Navigation;
using Tester.ViewModels;

namespace Tester.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateRequestView.xaml
    /// </summary>
    public partial class CreateRequestView : UserControl, INavigatable
    {
        public CreateRequestView()
        {
            InitializeComponent();
            DataContext = new CreateRequestViewModel();
        }
    }
}
