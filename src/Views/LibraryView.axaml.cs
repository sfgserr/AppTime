using AppTime.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppTime.Views;

public partial class LibraryView : UserControl
{
    public LibraryView(LibraryViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}