using AppTime.ViewModels;
using AppTime.Views;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppTime
{
    public class ViewLocator : IDataTemplate
    {
        private readonly IServiceProvider _services;

        public ViewLocator(IServiceProvider services)
        {
            _services = services;
        }

        public Control Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return type.Name switch
                {
                    "LibraryView" => (Control)_services.GetRequiredService<LibraryView>()
                };
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}