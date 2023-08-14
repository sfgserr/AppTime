using AppTime.ViewModels;

namespace AppTime.Stores.Navigators
{
    public enum ViewType
    {
        Library
    }

    public interface INavigator : IStore
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
