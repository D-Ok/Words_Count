using System.Windows.Controls;
using Tester.Tools.Navigation;
using Tester.ViewModels;

namespace Tester.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class SignInView : UserControl, INavigatable
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
