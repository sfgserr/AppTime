using AppTime.ViewModels;
using AppTime.Views;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;

namespace AppTime
{
    public class ViewMapper : IDataTemplate
    {
        private readonly LibraryView _library;

        public ViewMapper(LibraryView library)
        {
            _library = library;
        }

        public Control? Build(object param)
        {
            string viewName = param.GetType().FullName!.Replace("ViewModel", "View");
            Type type = Type.GetType(viewName);

            if (type != null)
            {
                return type.Name switch
                {
                    "LibraryView" => (Control)_library
                };
            }

            return new TextBlock { Text = $"NotFound: {viewName}" };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
