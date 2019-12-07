using System;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Exceptions;
using Tester.Tools.Navigation;
using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester.ViewModels
{
    internal class SignUpViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields

        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _signUpCommand;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        #endregion

        #region Properties


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

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

        #region Implementations

        private bool CanSignUpExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Name) 
                && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Email);
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
                {
                    MessageBox.Show("Password must be at list 6 characters long");
                    return false;
                }
                //var user = new User(Name, Surname, Email, Login, Password);
                //if (!ServiceClient.Instance.AddUser(user))
                //{
                //    MessageBox.Show("New user mast have unique login and email.");
                //    return false;
                //}
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (!signedUp)
                return;
            var user = new User(Name,Surname,Email,Login,Password);
            ServiceClient.Instance.AddUser(user);
            UserManager.CurrentUser = user;
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

        #endregion
    }

}
