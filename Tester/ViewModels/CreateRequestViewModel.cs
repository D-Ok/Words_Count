using System;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;

namespace Tester.ViewModels
{
    class CreateRequestViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _countCommand;
        private RelayCommand<object> _brouseFileCommand;

        private string _fileName;

        #endregion

        #region Properties
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand =
                           new RelayCommand<object>(BackImplementation));
            }
        }

        public RelayCommand<Object> BrouseFileCommand
        {
            get
            {
                return _brouseFileCommand ?? (_brouseFileCommand =
                           new RelayCommand<object>(BrouseFileImplementation));
            }
        }

        public RelayCommand<Object> CountCommand
        {
            get
            {
                return _countCommand ?? (_countCommand =
                           new RelayCommand<object>(CountImplementation, CanCountExecute));
            }
        }

        #endregion

        #region Implementation

        private bool CanCountExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(FileName);
        }

        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

        private void BrouseFileImplementation(object obj)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                FileName = openFileDlg.FileName;
            }
        }

        private void CountImplementation(object obj)
        {
            //TODO
        }

        #endregion
    
    }
}
