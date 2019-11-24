

using System;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;

namespace Tester.ViewModels
{
    internal class SignInViewModel : BaseViewModel
    {
        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;
        private string _login;
        private string _password;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        public RelayCommand<Object> SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand =
                           new RelayCommand<object>(SignInImplementation, CanSignInExecute));
            }
        }

        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand =
                           new RelayCommand<object>(SignUpImplementation));
            }
        }

        private bool CanSignInExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void SignUpImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignUp);
        }

        private async void SignInImplementation(object obj)
        {
            //TODO
            //Person person = null;
            //LoaderManeger.Instance.ShowLoader();
            //var result = await Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    try
            //    {
            //        person = new Person(Name, Surname, Email, Birthday);
            //        StationManager.DataStorage.AddPerson(person);
            //        StationManager.CurrentPerson = person;
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //        return false;
            //    }
            //    return true;
            //});
            //LoaderManeger.Instance.HideLoader();
            //if (result && person != null) NavigationManager.Instance.Navigate(ViewType.PersonList, person);
        }

    }
}
