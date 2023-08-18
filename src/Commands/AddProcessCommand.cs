using AppTime.Stores.AppProcessStores;
using AppTime.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AppTime.Commands
{
    public class AddProcessCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly LibraryViewModel _viewModel;
        private readonly IAppProcessStore _appProcessStore;

        public AddProcessCommand(LibraryViewModel viewModel, IAppProcessStore appProcessStore)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnCanExecuteChanged;

            _appProcessStore = appProcessStore;
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.CanAddProcess;
        }

        public void Execute(object? parameter)
        {
            _appProcessStore.AddProcess(_viewModel.SelectedProcess.ProcessName, _viewModel.SelectedProcess.MainModule.FileName);
        }

        private void OnCanExecuteChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.CanAddProcess)) CanExecuteChanged?.Invoke(this, e);
        }
    }
}
