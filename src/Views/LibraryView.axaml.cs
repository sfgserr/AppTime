using AppTime.ViewModels;
using Avalonia.Controls;

namespace AppTime.Views;

public partial class LibraryView : UserControl
{
    public LibraryView(LibraryViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}