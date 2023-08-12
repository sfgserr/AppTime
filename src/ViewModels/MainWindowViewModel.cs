using AppTime.Stores.Navigators;

namespace AppTime.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public MainWindowViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.StateChanged += OnViewModelChanged;
        }

        public ViewModelBase CurrentView => _navigator.CurrentViewModel;

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}