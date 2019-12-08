
namespace Tester.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        ShowRequests,
        CreateRequest
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
