using LibraryManager.Domain.Services.BookServices;
using LibraryManager.WPF.Commands.AddCommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.AddViewModels
{
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


        //private string _genreName;
        //public string GenreName
        //{
        //    get { return _genreName; }
        //    set
        //    {
        //        _genreName = value;
        //        OnPropertyChanged(nameof(GenreName));
        //    }
        //}
        //private string _authorName;

        //public string AuthorName
        //{
        //    get { return _authorName; }
        //    set
        //    {
        //        _authorName = value;
        //        OnPropertyChanged(nameof(AuthorName));
        //    }
        //}

        public ICommand AddBookCommand { get; set; }
        public AddBookViewModel(IBookService addBookService)
        {
            AddBookCommand = new AddBookCommand(this, addBookService);
        }
    }
}
