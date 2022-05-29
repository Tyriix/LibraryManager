using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.Domain.Services.ClientServices;
using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.MVVM.ViewModels.ListViewModels;
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
            services.AddSingleton<IDataService<Book>, GenericDataService<Book>>();
            services.AddSingleton<IDataService<Borrow>, GenericDataService<Borrow>>();

            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IBorrowService, BorrowService>();

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
                return () => new AddClientViewModel(services.GetRequiredService<IClientService>());
            });

            services.AddSingleton<CreateViewModel<AddGenreViewModel>>(services =>
            {
                return () => new AddGenreViewModel(services.GetRequiredService<IGenreService>());
            });

            services.AddSingleton<CreateViewModel<AddAuthorViewModel>>(services =>
            {
                return () => new AddAuthorViewModel(services.GetRequiredService<IAuthorService>());
            });

            services.AddSingleton<CreateViewModel<AddBookViewModel>>(services =>
            {
                return () => new AddBookViewModel(services.GetRequiredService<IBookService>());
            });

            services.AddSingleton<CreateViewModel<AddBorrowViewModel>>(services =>
            {
                return () => new AddBorrowViewModel(services.GetRequiredService<IBorrowService>());
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
            return services.BuildServiceProvider();
        }
    }
}
