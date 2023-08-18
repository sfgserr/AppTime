using AppTime.Services.AppProcessServices;
using AppTime.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AppTime.Commands
{
    class GetCurrentProcessesCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly LibraryViewModel _viewModel;
        private readonly IAppProcessService _appProcessService;

        public GetCurrentProcessesCommand(IAppProcessService appProcessService, LibraryViewModel viewModel)
        {
            _appProcessService = appProcessService;
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.CurrentProcesses = _appProcessService.GetCurrentProcesses();
        }
    }
}
