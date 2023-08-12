using AppTime.ViewModels;
using System;

namespace AppTime.Stores.Navigators
{
    public class Navigator : INavigator
    {
        public event Action StateChanged;

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel 
        { 
            get => _currentViewModel;
            set 
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
    }
}
