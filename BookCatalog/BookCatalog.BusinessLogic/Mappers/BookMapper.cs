namespace BookCatalog.BusinessLogic.Mappers
{
    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Book mapper.
    /// </summary>
    public static class BookMapper
    {
        /// <summary>
        /// Maps list of books to list of books view models.
        /// </summary>
        /// <param name="books">List of books.</param>
        /// <returns>List of books view models.</returns>
        public static List<BookViewModel> Map(List<Book> books)
        {
            List<BookViewModel> bookVMlist = new List<BookViewModel>();
            foreach (Book book in books)
            {
                bookVMlist.Add(Map(book));
            }

            return bookVMlist;
        }

        /// <summary>
        /// Maps book to book view models.
        /// </summary>
        /// <param name="book">Book.</param>
        /// <returns>Book view model.</returns>
        public static BookViewModel Map(Book book)
        {
            BookViewModel bookVM = new BookViewModel();
            bookVM.Id = book.Id;
            bookVM.Name = book.Name;
            bookVM.PagesCount = book.PagesCount;
            bookVM.PublishedDate = book.PublishedDate;
            bookVM.Description = (book.Description == null) ? string.Empty : book.Description;
            List<Author> authors = book.Authors.ToList();
            bookVM.Authors.AddRange(AuthorMapper.Map(authors));
            bookVM.AuthorsIds.AddRange(authors.Select(author => author.Id));
            return bookVM;
        }

        /// <summary>
        /// Maps book view model to book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Book.</returns>
        public static Book Map(BookViewModel bookVM)
        {
            Book book = new Book();
            Map(bookVM, ref book);
            return book;
        }
        
        /// <summary>
        /// Maps book view model to book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <param name="book">Book.</param>
        public static void Map(BookViewModel bookVM, ref Book book)
        {
            book.Name = bookVM.Name;
            book.PagesCount = bookVM.PagesCount;
            book.PublishedDate = bookVM.PublishedDate;
            book.Description = bookVM.Description;
        }
    }
}