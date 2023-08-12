using AppTime.Stores.Navigators;
using AppTime.ViewModels;
using AppTime.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       services.AddSingleton<MainWindow>();
                       services.AddSingleton<MainWindowViewModel>();
                       services.AddSingleton<INavigator, Navigator>();
                   });
    }
}