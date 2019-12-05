using System;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;

namespace Tester.ViewModels
{
    internal class SignUpViewModel : BaseViewModel
    {
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _signUpCommand;
        private string _name;
        private string _surname;
        private string _email;
        private string _login;
        private string _password;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

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


        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand =
                           new RelayCommand<object>(BackImplementation));
            }
        }

        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand =
                           new RelayCommand<object>(SignUpImplementation, CanSignUpExecute));
            }
        }

        private bool CanSignUpExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password) && !String.IsNullOrWhiteSpace(_name) 
                && !String.IsNullOrWhiteSpace(_surname) && !String.IsNullOrWhiteSpace(_email);
        }

        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private async void SignUpImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
            //TODO
        }
    }
}
