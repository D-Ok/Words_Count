using System.Collections.Generic;

namespace Tester.Tools.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            ContentOwner = contentOwner;
            ViewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner { get; }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary { get; }

        public void Navigate(ViewType viewType)
        {
            InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
