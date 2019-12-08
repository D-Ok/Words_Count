using System;
using System.Threading.Tasks;
using System.Windows;
using Tester.Managers;
using Tester.Tools;
using Tester.Tools.Navigation;
using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester.ViewModels
{
    internal class SignInViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;
        private string _login;
        private string _password;

        #endregion
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
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);
        }

        private void SignUpImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.SignUp);
        }

        private async void SignInImplementation(object obj)
        {
            User user = null;
            LoaderManager.Instance.ShowLoader();
            var signedIn = await Task.Run(() =>
            {
                user = ServiceClient.Instance.GetUser(Login);
                if (user == null)
                {
                    MessageBox.Show("User with this login doesn't exist");
                    return false;
                }
                else
                {
                    if (user.CheckPassword(Password))
                    {
                        user = ServiceClient.Instance.UpdateUserDate(user.Guid);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                        return false;
                    }
                       
                }

            });
            LoaderManager.Instance.HideLoader();
            if (!signedIn)
                return;
            UserManager.CurrentUser = user;
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

    }
}
