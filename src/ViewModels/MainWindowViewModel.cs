using AppTime.Commands;
using AppTime.Services.AppProcessServices;
using AppTime.Stores.Navigators;
using AppTime.ViewModels.Factories;
using System.Windows.Input;

namespace AppTime.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IAppProcessService _appProcessService;

        public MainWindowViewModel(INavigator navigator, IViewModelFactory factory, IAppProcessService appProcessService)
        {
            _navigator = navigator;
            _navigator.StateChanged += OnViewModelChanged;

            _appProcessService = appProcessService;

            UpdateCurrentViewCommand = new UpdateCurrentViewCommand(factory, _navigator);
            UpdateCurrentViewCommand.Execute(ViewType.Library);
        }

        public ViewModelBase CurrentView => _navigator.State;
        public ICommand UpdateCurrentViewCommand { get; }

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }

        public async void OnClosed()
        {
            await _appProcessService.SaveProcesses();
        }
    }
}