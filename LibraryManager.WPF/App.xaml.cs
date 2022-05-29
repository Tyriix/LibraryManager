using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.Domain.Services.ClientServices;
using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.State.Navigation;
using LibraryManager.WPF.ViewModels;
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
            //IDataService<Client> dataService = new GenericDataService<Client>(new EntityFramework.LibraryManagerDbContextFactory());
            //IGetClientsService getClientsService = new GetClientsService(dataService);

            //var clients = getClientsService.GetClients();
            //foreach (var item in clients)
            //{
            //    MessageBox.Show(item.FirstName);
            //}
            IServiceProvider serviceProvider = CreateServiceProvider();
            
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<LibraryManagerDbContextFactory>();
            services.AddSingleton<IDataService<Client>, GenericDataService<Client>>();
            services.AddSingleton<IDataService<Genre>, GenericDataService<Genre>>();
            services.AddSingleton<IDataService<Author>, GenericDataService<Author>>();

            services.AddSingleton<IAddClientService, AddClientService>();
            services.AddSingleton<IAddGenreService, AddGenreService>();
            services.AddSingleton<IGetClientsService, GetClientsService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IAuthorService, AuthorService>();

            services.AddSingleton<IRootLibraryManagerViewModelFactory, RootLibraryManagerViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddClientViewModel>, AddClientViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddGenreViewModel>, AddGenreViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<ClientsViewModel>, ClientsViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<GenresViewModel>, GenresViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AuthorsViewModel>, AuthorsViewModelFactory>();


            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<AddClientViewModel>();
            services.AddScoped<AddGenreViewModel>();
            services.AddScoped<ClientsViewModel>();
            services.AddScoped<GenresViewModel>();
            services.AddScoped<AuthorsViewModel>();
            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}
