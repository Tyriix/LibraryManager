using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.WPF.Commands.AddCommands;
using System;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.AddViewModels
{
    /// <summary>
    /// This is a viewModel class for AddBook View.
    /// </summary>
    public class AddBookViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                OnPropertyChanged(nameof(PageCount));
            }
        }

        private DateTime _publishDate;

        public DateTime PublishDate
        {
            get { return _publishDate; }
            set
            {
                _publishDate = value;
                OnPropertyChanged(nameof(PublishDate));
            }
        }
        private string _genreName;
        public string GenreName
        {
            get { return _genreName; }
            set
            {
                _genreName = value;
                OnPropertyChanged(nameof(GenreName));
            }
        }
        private int _genreId;
        public int GenreId
        {
            get { return _genreId; }
            set { _genreId = value; }
        }
        private int _authorId;
        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }

        public ICommand AddBookCommand { get; set; }
        public AddBookViewModel(IDataService<Book> dataService)
        {
            AddBookCommand = new AddBookCommand(this, dataService);
        }
    }
}
