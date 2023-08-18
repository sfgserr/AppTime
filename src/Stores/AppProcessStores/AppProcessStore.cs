using AppTime.Models;
using AppTime.Services.AppProcessServices;
using System;
using System.Collections.Generic;

namespace AppTime.Stores.AppProcessStores
{
    public class AppProcessStore : IAppProcessStore
    {
        public event Action StateChanged;

        private readonly IAppProcessService _appProcessService;

        public AppProcessStore(IAppProcessService appProcessService)
        {
            _appProcessService = appProcessService;

            GetProcesses();
        }

        private List<AppProcess> _appProcesses = new List<AppProcess>();

        public List<AppProcess> AppProcesses
        {
            get => _appProcesses;
            set
            {
                _appProcesses = value;
                StateChanged?.Invoke();
            }
        }

        public void UpdateState()
        {
            StateChanged?.Invoke();
        }

        public void AddProcess(string processName)
        {
            AppProcesses.Add(new AppProcess() { Name = processName });

            StateChanged?.Invoke();
        }

        private async void GetProcesses()
        {
            AppProcesses = await _appProcessService.GetTrackedProcesses() ?? new List<AppProcess>();
        }
    }
}
