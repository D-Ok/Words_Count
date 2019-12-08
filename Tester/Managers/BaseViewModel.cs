using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Tester.Tools
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {


        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
