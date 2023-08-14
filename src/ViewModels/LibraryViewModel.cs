using AppTime.Models;
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

        public ObservableCollection<AppProcess> Processes { get; set; } = new ObservableCollection<AppProcess>();

        private string _greet = "HI";

        public string Greet
        {
            get => _greet;
            set => Set(ref _greet, value);
        }

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
