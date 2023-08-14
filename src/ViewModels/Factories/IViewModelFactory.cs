using AppTime.Stores.Navigators;

namespace AppTime.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
