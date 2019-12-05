
namespace Tester.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        ShowRequests
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
