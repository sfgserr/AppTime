using AppTime.BackgroundWorkers;
using AppTime.Models;
using AppTime.Services.AppProcessServices;
using AppTime.Services.JsonServices;
using AppTime.Stores.AppProcessStores;
using AppTime.Stores.Navigators;
using AppTime.Stores.StateSerializers;
using AppTime.ViewModels;
using AppTime.ViewModels.Factories;
using AppTime.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace AppTime
{
    public partial class App : Application
    {
        private IHost _host;
        private MainWindow _window;

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
                _window = _host.Services.GetRequiredService<MainWindow>();

                desktop.MainWindow = _window;

                DataTemplates.Add(_host.Services.GetRequiredService<ViewMapper>());
            }

            base.OnFrameworkInitializationCompleted();
        }

        public void OnExitButtonClicked(object sender, EventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
            {
                desktopApp.Shutdown();
            }
        }

        public void OnIconClicked(object sender, EventArgs e)
        {
            _window.Show();
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
                       services.AddSingleton<IAppProcessService, AppProcessService>(s => new AppProcessService(s.GetRequiredService<IJsonService>(), s.GetRequiredService<StateSerializer<List<AppProcess>>>()));
                       services.AddSingleton<IJsonService, JsonService>();
                       services.AddSingleton<IAppProcessStore, AppProcessStore>();
                       services.AddSingleton<StateSerializer<List<AppProcess>>>(s => new StateSerializer<List<AppProcess>>(s.GetRequiredService<IAppProcessStore>(), s.GetRequiredService<IJsonService>()));
                       services.AddSingleton<SpendTimeWorker>();
                   });
    }
}