using AppTime.ViewModels;

namespace AppTime.Stores.Navigators
{
    public class Renavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly CreateViewModel<TViewModel> _createViewModel;
        private readonly INavigator _navigator;

        public Renavigator(CreateViewModel<TViewModel> createViewModel, INavigator navigator)
        {
            _createViewModel = createViewModel;
            _navigator = navigator;
        }

        public void Navigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
