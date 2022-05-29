using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.Domain.Services.BookServices;
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
            //IDataService<Book> bookDataService = new GenericDataService<Book>(new LibraryManagerDbContextFactory());
            //IDataService<Author> authorDataService = new GenericDataService<Author>(new LibraryManagerDbContextFactory());
            //IDataService<Genre> genreDataService = new GenericDataService<Genre>(new LibraryManagerDbContextFactory());

            //IBookService bookService = new BookService(bookDataService, authorDataService, genreDataService);

            //Author author = await authorDataService.Get(1);
            //Genre genre = await genreDataService.Get(1);
            //Book newBook = new Book()
            //{
            //    Title = "TestBook1",
            //    PageCount = 100,
            //    PublishDate = DateTime.Now,
            //    GenreId = genre.Id,
            //    AuthorId = author.Id
            //};

            //await bookService.AddBook(newBook, author, genre);
            //Environment.Exit(0);


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

            
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IGenreService, GenreService>();

            services.AddSingleton<IRootLibraryManagerViewModelFactory, RootLibraryManagerViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<ClientsViewModel>, ClientsViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<GenresViewModel>, GenresViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AuthorsViewModel>, AuthorsViewModelFactory>();

            services.AddSingleton<ILibraryManagerViewModelFactory<AddClientViewModel>, AddClientViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddGenreViewModel>, AddGenreViewModelFactory>();
            services.AddSingleton<ILibraryManagerViewModelFactory<AddAuthorViewModel>, AddAuthorViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();

            services.AddScoped<MainViewModel>();
            services.AddScoped<ClientsViewModel>();
            services.AddScoped<GenresViewModel>();
            services.AddScoped<AuthorsViewModel>();

            services.AddScoped<AddClientViewModel>();
            services.AddScoped<AddGenreViewModel>();
            services.AddScoped<AddAuthorViewModel>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}
