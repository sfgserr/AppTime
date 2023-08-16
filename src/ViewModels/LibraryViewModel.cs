using AppTime.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AppTime.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        public LibraryViewModel()
        {
            TrackedProcesses.CollectionChanged += OnCollectionChanged;
        }

        public ObservableCollection<AppProcess> TrackedProcesses { get; set; } = new ObservableCollection<AppProcess>() { new AppProcess() { IsRunning = false, TimeSpentInMs = 0, Name = "Process" } };
        public ObservableCollection<AppProcess> CurrentProcceses { get; set; } = new ObservableCollection<AppProcess>();
        public string Greet => "sdsd";

        public override void Dispose()
        {
            TrackedProcesses.CollectionChanged -= OnCollectionChanged;

            base.Dispose();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TrackedProcesses));
        }
    }
}
