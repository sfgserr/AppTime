﻿using AppTime.BackgroundWorkers;
using AppTime.Commands;
using AppTime.Models;
using AppTime.Services.AppProcessServices;
using AppTime.Stores.AppProcessStores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AppTime.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        private int _count = 0;

        private readonly SpendTimeWorker _worker;
        private readonly IAppProcessStore _appProcessStore;

        public LibraryViewModel(IAppProcessService appProcessService, IAppProcessStore appProcessStore, SpendTimeWorker worker)
        {
            _appProcessStore = appProcessStore;
            _appProcessStore.StateChanged += OnCollectionChanged;

            _worker = worker;

            GetCurrentProcessesCommand = new GetCurrentProcessesCommand(appProcessService, this);
            GetCurrentProcessesCommand.Execute(null);

            GetTrackedProcessesCommand = new GetTrackedProcessesCommand(appProcessService, _appProcessStore);
            GetTrackedProcessesCommand.Execute(null);

            AddProcessCommand = new AddProcessCommand(this, appProcessStore, appProcessService);
            RemoveProcessCommand = new RemoveProcessCommand(_appProcessStore, this);
        }

        public ICommand GetCurrentProcessesCommand { get; }
        public ICommand GetTrackedProcessesCommand { get; }
        public ICommand AddProcessCommand { get; }
        public ICommand RemoveProcessCommand { get; }
        public ObservableCollection<AppProcess> TrackedProcesses => new ObservableCollection<AppProcess>(_appProcessStore.State);
        public bool CanAddProcess => SelectedProcess != null;
        public bool CanRemoveProcess => SelectedTrackedProcess != null;

        private List<Process> _currentProcesses = new List<Process>();

        public List<Process> CurrentProcesses
        {
            get => _currentProcesses;
            set => Set(ref _currentProcesses, value);
        }

        private Process _selectedProcess;

        public Process SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                Set(ref _selectedProcess, value);
                OnPropertyChanged(nameof(CanAddProcess));
            }
        }

        private AppProcess _selectedTrackedProcess;

        public AppProcess SelectedTrackedProcess
        {
            get => _selectedTrackedProcess;
            set
            {
                Set(ref _selectedTrackedProcess, value);
                OnPropertyChanged(nameof(CanRemoveProcess));
            }
        }

        public override void Dispose()
        {
            _appProcessStore.StateChanged -= OnCollectionChanged;

            base.Dispose();
        }

        private void OnCollectionChanged()
        {
            if (_count < TrackedProcesses.Count)
            {
                for (int i = _count; i < TrackedProcesses.Count; i++) 
                {
                    _worker.StartWork(i);
                }
            }

            _count = TrackedProcesses.Count;
            OnPropertyChanged(nameof(TrackedProcesses));
        }
    }
}
