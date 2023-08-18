using AppTime.BackgroundWorkers;
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

            AddProcessCommand = new AddProcessCommand(this, appProcessStore);
        }

        public ICommand GetCurrentProcessesCommand { get; }
        public ICommand AddProcessCommand { get; }
        public ObservableCollection<AppProcess> TrackedProcesses => new ObservableCollection<AppProcess>(_appProcessStore.AppProcesses);
        public List<Process> CurrentProcesses { get; set; } = new List<Process>();

        private Process _selectedProcess;

        public Process SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                Set(ref _selectedProcess, value);
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
                _count = TrackedProcesses.Count;
                _worker.StartWork(_count-1);
            }

            OnPropertyChanged(nameof(TrackedProcesses));
        }
    }
}
