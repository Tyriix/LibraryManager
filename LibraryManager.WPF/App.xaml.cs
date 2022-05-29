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
using LibraryManager.WPF.State.Navigation;
using LibraryManager.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
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

            services.AddSingleton<IRootLibraryManagerViewModelFactory, RootLibraryManagerViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<ClientsViewModel>, ClientsViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<GenresViewModel>, GenresViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AuthorsViewModel>, AuthorsViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<BooksViewModel>, BooksViewModelFactory>();

            services.AddSingleton<ILibraryManagerViewModelFactory<AddClientViewModel>, AddClientViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddGenreViewModel>, AddGenreViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddAuthorViewModel>, AddAuthorViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddBookViewModel>, AddBookViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddBorrowViewModel>, AddBorrowViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();

            services.AddScoped<MainViewModel>();
            services.AddScoped<ClientsViewModel>();
            services.AddScoped<GenresViewModel>();
            services.AddScoped<AuthorsViewModel>();
            services.AddScoped<BooksViewModel>();

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
