using System;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Exceptions;
using Tester.Tools.Navigation;

namespace Tester.ViewModels
{
    internal class SignUpViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields

        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _signUpCommand;
        private string _name;
        private string _surname;
        private string _email;
        private string _login;
        private string _password;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        #endregion

        #region Properties

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

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion



        private bool CanSignUpExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_name) 
                && !string.IsNullOrWhiteSpace(_surname) && !string.IsNullOrWhiteSpace(_email);
        }

        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignIn);
        }

        private async void SignUpImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var signedUp = await Task.Run(() =>
            {
                try
                {
                    Validator.ValidateNameAttribute(Name);
                }
                catch (InvalidNameAttributeException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                try
                {
                    Validator.ValidateNameAttribute(Surname);
                }
                catch (InvalidNameAttributeException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                try
                {
                    Validator.ValidateEmail(Email);
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                try
                {
                    Validator.ValidateLogin(Login);
                }
                catch (InvalidLoginException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                if (Password.Length < 6)
                    MessageBox.Show("Password must be at list 6 characters long");

                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (!signedUp)
                return;
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }
    }
}
