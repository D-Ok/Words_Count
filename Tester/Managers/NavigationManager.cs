using System.Windows;
using Tester.Tools.Navigation;

namespace Tester.Managers
{
    internal class NavigationManager
    {
        #region Fields

        private static readonly object Locker = new object();
        private static NavigationManager _instance;
        private INavigationModel _navigationModel;

        #endregion


        #region Properties

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }


        #endregion

        private NavigationManager()
        {

        }

        #region Methods

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType)
        {
            if (_navigationModel == null) MessageBox.Show(" " + _navigationModel);
            _navigationModel.Navigate(viewType);
        }


        #endregion

    }
}
