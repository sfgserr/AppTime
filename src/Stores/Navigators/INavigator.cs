using AppTime.ViewModels;

namespace AppTime.Stores.Navigators
{
    public interface INavigator : IStore
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
