using AppTime.Stores.AppProcessStores;
using AppTime.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AppTime.Commands
{
    class RemoveProcessCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IAppProcessStore _appProcessStore;
        private readonly LibraryViewModel _viewModel;

        public RemoveProcessCommand(IAppProcessStore appProcessStore, LibraryViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnCanExecuteChanged;

            _appProcessStore = appProcessStore;
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.CanRemoveProcess;
        }

        public void Execute(object? parameter)
        {
            _appProcessStore.RemoveProcess(_viewModel.SelectedTrackedProcess.Name);
        }

        private void OnCanExecuteChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.CanRemoveProcess)) CanExecuteChanged?.Invoke(sender, e);
        }
    }
}
