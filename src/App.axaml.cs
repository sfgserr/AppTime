using AppTime.BackgroundWorkers;
using AppTime.Services.AppProcessServices;
using AppTime.Services.JsonServices;
using AppTime.Stores.AppProcessStores;
using AppTime.Stores.Navigators;
using AppTime.ViewModels;
using AppTime.ViewModels.Factories;
using AppTime.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppTime
{
    public partial class App : Application
    {
        private IHost _host;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                _host = CreateHostBuilder().Build();

                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = _host.Services.GetRequiredService<MainWindow>();

                DataTemplates.Add(_host.Services.GetRequiredService<ViewMapper>());
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       services.AddSingleton<MainWindow>();
                       services.AddSingleton<LibraryView>();
                       services.AddSingleton<MainWindowViewModel>();
                       services.AddSingleton<CreateViewModel<LibraryViewModel>>(s => () => s.GetRequiredService<LibraryViewModel>());
                       services.AddScoped<LibraryViewModel>();
                       services.AddSingleton<INavigator, Navigator>();
                       services.AddSingleton<IViewModelFactory, ViewModelFactory>();
                       services.AddSingleton<ViewMapper>();
                       services.AddSingleton<IAppProcessService, AppProcessService>();
                       services.AddSingleton<IJsonService, JsonService>();
                       services.AddSingleton<IAppProcessStore, AppProcessStore>();
                       services.AddSingleton<SpendTimeWorker>();
                   });
    }
}