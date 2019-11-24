
namespace Tester.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
