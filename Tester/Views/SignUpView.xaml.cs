using System.Windows.Controls;
using Tester.Tools.Navigation;
using Tester.ViewModels;

namespace Tester.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUpView : UserControl, INavigatable
    {
        public SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
