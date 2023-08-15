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
            Processes.CollectionChanged += OnCollectionChanged;
        }

        public ObservableCollection<AppProcess> Processes { get; set; } = new ObservableCollection<AppProcess>() { new AppProcess() { IsRunning = false, TimeSpentInMs = 0, Name = "Process" } };
        public string Greet => "sdsd";

        public override void Dispose()
        {
            Processes.CollectionChanged -= OnCollectionChanged;

            base.Dispose();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Processes));
        }
    }
}
