using System;
using SignInView = Tester.Views.SignInView;
using SignUpView = Tester.Views.SignUpView;
using ShowRequestsView = Tester.Views.ShowRequestsView;
using CreateRequestView = Tester.Views.CreateRequestView;


namespace Tester.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            if (ViewsDictionary.ContainsKey(viewType)) ViewsDictionary.Remove(viewType);
            switch (viewType)
            {
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType, new SignInView());
                    break;
                case ViewType.SignUp:
                    ViewsDictionary.Add(viewType, new SignUpView());
                    break;
                case ViewType.ShowRequests:
                    ViewsDictionary.Add(viewType, new ShowRequestsView());
                    break;
                case ViewType.CreateRequest:
                    ViewsDictionary.Add(viewType, new CreateRequestView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}