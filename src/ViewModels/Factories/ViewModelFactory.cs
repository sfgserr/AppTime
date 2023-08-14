using AppTime.Stores.Navigators;
using System;

namespace AppTime.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LibraryViewModel> _library;

        public ViewModelFactory(CreateViewModel<LibraryViewModel> library)
        {
            _library = library;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Library => _library(),
                _ => throw new ArgumentException()
            };
        }
    }
}
