using AppTime.ViewModels;
using Avalonia.Controls;
using System.ComponentModel;

namespace AppTime.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;

            DataContext = _viewModel;
            Closing += OnClosing;
        }

        private void OnClosing(object? sender, CancelEventArgs e)
        {
            e.Cancel = true;
            _viewModel.OnClosed();
            this.Hide();
        }
    }
}