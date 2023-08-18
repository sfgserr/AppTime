using AppTime.Models;
using AppTime.Services.AppProcessServices;
using AppTime.Stores.AppProcessStores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AppTime.Commands
{
    public class GetTrackedProcessesCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IAppProcessService _appProcessService;
        private readonly IAppProcessStore _appProcessStore;

        public GetTrackedProcessesCommand(IAppProcessService appProcessService, IAppProcessStore appProcessStore)
        {
            _appProcessService = appProcessService;
            _appProcessStore = appProcessStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            _appProcessStore.State = await _appProcessService.GetTrackedProcesses() ?? new List<AppProcess>();
        }
    }
}
