using AppTime.Commands;
using AppTime.Stores.Navigators;
using AppTime.ViewModels.Factories;
using System.Windows.Input;

namespace AppTime.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public MainWindowViewModel(INavigator navigator, IViewModelFactory factory)
        {
            _navigator = navigator;
            _navigator.StateChanged += OnViewModelChanged;

            UpdateCurrentViewCommand = new UpdateCurrentViewCommand(factory, _navigator);
            UpdateCurrentViewCommand.Execute(ViewType.Library);
        }

        public ViewModelBase CurrentView => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewCommand { get; }

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}