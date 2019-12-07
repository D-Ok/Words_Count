using System;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;

namespace Tester.ViewModels
{
    class ShowRequestsViewModel
    {

        #region Fields

        private RelayCommand<object> _newRequestCommand;

        #endregion

        #region Properties
        public RelayCommand<Object> NewRequestCommand
        {
            get
            {
                return _newRequestCommand ?? (_newRequestCommand =
                           new RelayCommand<object>(NewRequestImplementation));
            }
        }

        #endregion

        private void NewRequestImplementation(object obj)
        {
            //NavigationManager.Instance.Navigate(ViewType.);
        }

    }
}
