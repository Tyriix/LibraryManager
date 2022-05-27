using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace LibraryManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            
            //Window window = new LoginWindow();
            Window window = new MainWindow();
            window.Show();



            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<LibraryManagerDbContextFactory>();
            services.AddSingleton<IDataService<Client>, GenericDataService<Client>>();
            services.AddSingleton<IAddClientService, AddClientService>();


            services.AddScoped<AddClientViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
