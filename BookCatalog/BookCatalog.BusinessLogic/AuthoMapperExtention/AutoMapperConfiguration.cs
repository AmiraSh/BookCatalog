namespace BookCatalog.BusinessLogic.AuthoMapperExtention
{
    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ViewModels;
    using DAL.Models;
    #endregion

    /// <summary>
    /// Auto mapper configuration.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Configures auto mapper.
        /// </summary>
        public static void Configure()
        {
            ConfigureAuthorMapping();
            ConfigureBookMapping();
        }

        /// <summary>
        /// Configures books' mapping.
        /// </summary>
        private static void ConfigureBookMapping()
        {
            Mapper.CreateMap<Book, BookViewModel>().ConstructUsing(book =>
            {
                if (book != null)
                {
                    BookViewModel bookVM = new BookViewModel();
                    bookVM.Id = book.Id;
                    bookVM.Name = book.Name;
                    bookVM.PagesCount = book.PagesCount;
                    bookVM.PublishedDate = book.PublishedDate;
                    bookVM.Description = (book.Description == null) ? string.Empty : book.Description;
                    List<Author> authors = book.Authors.ToList();
                    bookVM.Authors.AddRange(Mapper.Map<List<AuthorViewModel>>(authors));
                    bookVM.AuthorsIds.AddRange(authors.Select(author => author.Id));
                    return bookVM;
                }

                return default(BookViewModel);
            });

            Mapper.CreateMap<Book, ShortBookViewModel>().ConstructUsing(book =>
            {
                if (book != null)
                {
                    ShortBookViewModel bookVM = new ShortBookViewModel();
                    bookVM.Name = book.Name;
                    bookVM.Year = book.PublishedDate.Year;
                    return bookVM;
                }

                return default(ShortBookViewModel);
            });

            Mapper.CreateMap<List<Book>, List<BookViewModel>>().ConstructUsing(books =>
            {
                if (books != null)
                {
                    List<BookViewModel> bookVMlist = new List<BookViewModel>();
                    foreach (Book book in books)
                    {
                        bookVMlist.Add(Mapper.Map<BookViewModel>(book));
                    }

                    return bookVMlist;
                }

                return default(List<BookViewModel>);
            });

            Mapper.CreateMap<BookViewModel, Book>().ConstructUsing(bookVM =>
                {
                    if (bookVM != null)
                    {
                        Book book = new Book();
                        book.Name = bookVM.Name;
                        book.PagesCount = bookVM.PagesCount;
                        book.PublishedDate = bookVM.PublishedDate;
                        book.Description = bookVM.Description;
                        return book;
                    }

                    return default(Book);
                });
        }

        /// <summary>
        /// Configures authors' mapping.
        /// </summary>
        private static void ConfigureAuthorMapping()
        {
            Mapper.CreateMap<AuthorViewModel, Author>().ConstructUsing(authorVM =>
            {
                if (authorVM != null)
                {
                    Author author = new Author();
                    author.FirstName = authorVM.FirstName;
                    author.SecondName = authorVM.SecondName;
                    return author;
                }

                return default(Author);
            });

            Mapper.CreateMap<Author, AuthorViewModel>().ConstructUsing(author =>
            {
                if (author != null)
                {
                    AuthorViewModel authorVM = new AuthorViewModel();
                    authorVM.Id = author.Id;
                    authorVM.FirstName = author.FirstName;
                    authorVM.SecondName = author.SecondName;
                    authorVM.BooksCount = author.Books.Count;
                    foreach (var book in author.Books)
                    {
                        authorVM.Books.Add(Mapper.Map<ShortBookViewModel>(book));
                    }

                    return authorVM;
                }

                return default(AuthorViewModel);
            });

            Mapper.CreateMap<List<Author>, List<AuthorViewModel>>().ConstructUsing(authors =>
            {
                if (authors != null)
                {
                    List<AuthorViewModel> authorVMlist = new List<AuthorViewModel>();
                    foreach (Author author in authors)
                    {
                        authorVMlist.Add(Mapper.Map<AuthorViewModel>(author));
                    }

                    return authorVMlist;
                }

                return default(List<AuthorViewModel>);
            });
        }
    }
}