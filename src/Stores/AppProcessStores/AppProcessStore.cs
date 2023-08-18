using AppTime.Models;
using System;
using System.Collections.Generic;

namespace AppTime.Stores.AppProcessStores
{
    public class AppProcessStore : IAppProcessStore
    {
        public event Action StateChanged;

        private List<AppProcess> _appProcesses = new List<AppProcess>();

        public List<AppProcess> State
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
            State.Add(new AppProcess() { Name = processName });

            StateChanged?.Invoke();
        }
    }
}
