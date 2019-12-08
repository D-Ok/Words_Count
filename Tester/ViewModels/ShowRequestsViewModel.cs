using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;
using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester.ViewModels
{
    class ShowRequestsViewModel : BaseViewModel
    {

        #region Fields
        private ObservableCollection<Request> _requests;
        private RelayCommand<object> _newRequestCommand;
        private RelayCommand<object> _logOutCommand;
        #endregion

        #region Properties

        public ObservableCollection<Request> Requests
        {
            get { return _requests; }
            private set
            {
                _requests = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<Object> NewRequestCommand
        {
            get
            {
                return _newRequestCommand ?? (_newRequestCommand =
                           new RelayCommand<object>(NewRequestImplementation));
            }
        }

        public RelayCommand<Object> LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand =
                           new RelayCommand<object>(LogOutImplementation));
            }
        }

        #endregion

        #region Implementations

        internal ShowRequestsViewModel()
        {
            _requests = new ObservableCollection<Request>();

            foreach (var req in UserManager.CurrentUser.Requests)
            {
                _requests.Add(req);
            }

        }

        private void NewRequestImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.CreateRequest);
        }


        private void LogOutImplementation(object obj)
        {
            UserManager.CurrentUser = null;
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        #endregion

    }
}
