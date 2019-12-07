using WordsCountSkyrtaOliinyk.DBModels;

namespace Tester.Managers
{
    internal class UserManager
    {
        private static User _currentUser;

        public static User CurrentUser { get => _currentUser; set => _currentUser = value; }
    }
}
