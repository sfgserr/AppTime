﻿using AppTime.Models;
using AppTime.Services.AppProcessServices;
using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;

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

        public void AddProcess(string processName, string processFileName, Bitmap icon)
        {
            AppProcess process = new AppProcess() 
            { 
                Name = processName, 
                FileName = processFileName, 
                Icon = icon 
            };

            State.Add(process);

            StateChanged?.Invoke();
        }
    }
}
