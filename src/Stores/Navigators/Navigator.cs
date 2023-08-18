using AppTime.ViewModels;
using System;

namespace AppTime.Stores.Navigators
{
    public class Navigator : INavigator
    {
        public event Action StateChanged;

        private ViewModelBase _currentViewModel;

        public ViewModelBase State 
        { 
            get => _currentViewModel;
            set 
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
    }
}
