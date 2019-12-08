using System;
using System.Collections.ObjectModel;
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


        #endregion

        #region Implementation

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
            //NavigationManager.Instance.Navigate(ViewType.);
        }

        #endregion

    }
}
