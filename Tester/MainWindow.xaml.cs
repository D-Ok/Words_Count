using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Tester.Managers;
using Tester.Tools.Navigation;
using Tester.ViewModels;

namespace Tester
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        //private ContentControl _contentControl;

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            WordsCountService.WordsCounterClient client = new WordsCountService.WordsCounterClient();
            Console.WriteLine(client.Answer("Masha"));
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

    
    }
}
