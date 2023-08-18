using AppTime.Services.AppProcessServices;
using AppTime.Stores.AppProcessStores;
using AppTime.ViewModels;
using Avalonia.Media.Imaging;
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
        private readonly IAppProcessService _appProcessService;

        public AddProcessCommand(LibraryViewModel viewModel, IAppProcessStore appProcessStore, IAppProcessService appProcessService)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnCanExecuteChanged;

            _appProcessStore = appProcessStore;
            _appProcessService = appProcessService;
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.CanAddProcess;
        }

        public void Execute(object? parameter)
        {
            string fileName = _viewModel.SelectedProcess.MainModule.FileName;
            Bitmap icon = _appProcessService.GetProcessIconByName(fileName);
            _appProcessStore.AddProcess(_viewModel.SelectedProcess.ProcessName, fileName, icon);
        }

        private void OnCanExecuteChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.CanAddProcess)) CanExecuteChanged?.Invoke(this, e);
        }
    }
}
