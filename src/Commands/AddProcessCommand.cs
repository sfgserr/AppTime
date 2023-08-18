using AppTime.Stores.AppProcessStores;
using AppTime.ViewModels;
using System;
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
            _appProcessStore = appProcessStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _appProcessStore.AddProcess(_viewModel.SelectedProcess.ProcessName);
        }
    }
}
