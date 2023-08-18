using AppTime.ViewModels;
using Avalonia.Controls;

namespace AppTime.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Closed += (s, e) => vm.OnClosed();
        }
    }
}