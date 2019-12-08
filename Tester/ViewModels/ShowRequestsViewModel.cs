using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
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

        public string FilePath { get; private set; }


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
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                var extension = Path.GetExtension(fileDialog.FileName);

                if (extension != ".txt")
                {
                    MessageBox.Show("Wrong file format! You can download only .txt files");
                    return;
                }

                FilePath = fileDialog.FileName;
                PerformAnaysis();
            }
        }


        private async void PerformAnaysis() {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                string fileText = File.ReadAllText(FilePath);
                TextCalculator.Calculate(fileText, out int lines, out int words, out int symbols);
                MessageBox.Show($"File: {FilePath} \nLines: {lines} Words: {words} Symbols: {symbols}");
            });
            LoaderManager.Instance.HideLoader();
        }

        #endregion

    }
}
