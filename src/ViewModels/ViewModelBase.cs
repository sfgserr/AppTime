using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppTime.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}