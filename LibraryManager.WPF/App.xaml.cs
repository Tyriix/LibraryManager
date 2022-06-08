using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.MVVM.ViewModels.ListViewModels;
using LibraryManager.WPF.State.Navigation;
using LibraryManager.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace LibraryManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    //services.AddDbContext<LibraryManagerDbContext>(o => o.UseSqlite("Filename=LibraryManager.db"));

                    services.AddSingleton<LibraryManagerDbContextFactory>();
                    services.AddSingleton<IDataService<Client>, GenericDataService<Client>>();
                    services.AddSingleton<IDataService<Genre>, GenericDataService<Genre>>();
                    services.AddSingleton<IDataService<Author>, GenericDataService<Author>>();
                    services.AddSingleton<IDataService<Book>, GenericDataService<Book>>();
                    services.AddSingleton<IDataService<Borrow>, GenericDataService<Borrow>>();

                    services.AddSingleton<ILibraryManagerViewModelFactory, LibraryManagerViewModelFactory>();

                    //Registering CreateViewModel function
                    services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
                    {
                        return () => new HomeViewModel();
                    });
                    services.AddSingleton<CreateViewModel<ClientsViewModel>>(services =>
                    {
                        return () => new ClientsViewModel();
                    });
                    services.AddSingleton<CreateViewModel<GenresViewModel>>(services =>
                    {
                        return () => new GenresViewModel();
                    });
                    services.AddSingleton<CreateViewModel<AuthorsViewModel>>(services =>
                    {
                        return () => new AuthorsViewModel();
                    });
                    services.AddSingleton<CreateViewModel<BooksViewModel>>(services =>
                    {
                        return () => new BooksViewModel();
                    });
                    services.AddSingleton<CreateViewModel<BorrowsViewModel>>(services =>
                    {
                        return () => new BorrowsViewModel();
                    });


                    services.AddSingleton<CreateViewModel<AddClientViewModel>>(services =>
                    {
                        return () => new AddClientViewModel(services.GetRequiredService<IDataService<Client>>());
                    });

                    services.AddSingleton<CreateViewModel<AddGenreViewModel>>(services =>
                    {
                        return () => new AddGenreViewModel(services.GetRequiredService<IDataService<Genre>>());
                    });

                    services.AddSingleton<CreateViewModel<AddAuthorViewModel>>(services =>
                    {
                        return () => new AddAuthorViewModel(services.GetRequiredService<IDataService<Author>>());
                    });

                    services.AddSingleton<CreateViewModel<AddBookViewModel>>(services =>
                    {
                        return () => new AddBookViewModel(services.GetRequiredService<IDataService<Book>>());
                    });

                    services.AddSingleton<CreateViewModel<AddBorrowViewModel>>(services =>
                    {
                        return () => new AddBorrowViewModel(services.GetRequiredService<IDataService<Borrow>>());
                    });

                    services.AddScoped<INavigator, Navigator>();
                    services.AddScoped<MainViewModel>();

                    services.AddScoped<ClientsViewModel>();
                    services.AddScoped<GenresViewModel>();
                    services.AddScoped<AuthorsViewModel>();
                    services.AddScoped<BooksViewModel>();
                    services.AddScoped<BorrowsViewModel>();

                    services.AddScoped<AddClientViewModel>();
                    services.AddScoped<AddGenreViewModel>();
                    services.AddScoped<AddAuthorViewModel>();
                    services.AddScoped<AddBookViewModel>();
                    services.AddScoped<AddBorrowViewModel>();

                    services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
