using AppTime.Stores.Navigators;
using AppTime.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace AppTime.Commands
{
    public class UpdateCurrentViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IViewModelFactory _factory;
        private readonly INavigator _navigator;

        public UpdateCurrentViewCommand(IViewModelFactory factory, INavigator navigator)
        {
            _factory = factory;
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.State = _factory.CreateViewModel(viewType);
            }
        }
    }
}
