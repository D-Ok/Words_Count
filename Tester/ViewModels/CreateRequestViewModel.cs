using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;
using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester.ViewModels
{
    class CreateRequestViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _countCommand;
        private RelayCommand<object> _browseFileCommand;

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

        public RelayCommand<Object> BrowseFileCommand
        {
            get
            {
                return _browseFileCommand ?? (_browseFileCommand =
                           new RelayCommand<object>(BrowseFileImplementation));
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

        #region Implementations

        private bool CanCountExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(FileName);
        }

        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

        private void BrowseFileImplementation(object obj)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                var extension = Path.GetExtension(fileDialog.FileName);

                if (extension != ".txt")
                {
                    MessageBox.Show("Wrong file format! You can download only .txt files");
                    return;
                }

                FileName = fileDialog.FileName;
            }
        }

        private async void CountImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var count = await Task.Run(() =>
            {
                var extension = Path.GetExtension(FileName);

                if (extension != ".txt")
                {
                    MessageBox.Show("Wrong file format! You can download only .txt files");
                    return false;
                }

                if (!File.Exists(FileName))
                {
                    MessageBox.Show("File does not exist");
                    return false;
                }

                string fileText = File.ReadAllText(FileName);
                TextCalculator.Calculate(fileText, out int lines, out int words, out int symbols);
                Request r = new Request(FileName, symbols, words, lines);
                r.OwnerGuid = UserManager.CurrentUser.Guid;
                ServiceClient.Instance.AddRequest(r);
                MessageBox.Show($"File: {FileName} \nLines: {lines} Words: {words} Symbols: {symbols}");
                return true;
            });
            LoaderManager.Instance.HideLoader();

            if(count)
                 NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

        #endregion

    }
}
