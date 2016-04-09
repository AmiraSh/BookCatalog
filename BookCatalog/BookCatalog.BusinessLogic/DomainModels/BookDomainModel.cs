namespace BookCatalog.BusinessLogic.DomainModel
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Transactions;
    using System.Web.Mvc;
    using System.Xml;
    using AutoMapper;
    using DAL.Interfaces;
    using DAL.Models;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using ViewModels;
    #endregion

    /// <summary>
    /// Book domain model.
    /// </summary>
    public class BookDomainModel
    {
        /// <summary>
        /// Book repository.
        /// </summary>
        private IBookRepository bookRepository;

        /// <summary>
        /// Author repository.
        /// </summary>
        private IAuthorRepository authorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookDomainModel"/> class.
        /// </summary>
        /// <param name="bookRepository">Book repository.</param>
        /// <param name="authorRepository">Author repository.</param>
        public BookDomainModel(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        public int GetBooksCount()
        {
            return this.bookRepository.GetSize();
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        public List<SelectListItem> PopulateMultiSelectList()
        {
            return new MultiSelectList(
                this.authorRepository.GetAll().ToList().Select(author => new SelectListItem()
                {
                    Text = string.Format("{0} {1}", author.FirstName, author.SecondName),
                    Value = author.Id.ToString()
                }), "Value", "Text").ToList();
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void PopulateMultiSelectList(BookViewModel bookVM)
        {
            bookVM.AuthorsOptions = new MultiSelectList(
                this.authorRepository.GetAll().ToList().Select(author => new SelectListItem()
                {
                    Text = string.Format("{0} {1}", author.FirstName, author.SecondName),
                    Value = author.Id.ToString(),
                    Selected = bookVM.Authors.FirstOrDefault(bookAuthor => bookAuthor.Id == author.Id) != null
                }), "Value", "Text").ToList();
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books list.</returns>
        public List<BookViewModel> GetBooks()
        {
            return Mapper.Map<List<BookViewModel>>(this.bookRepository.GetAll().ToList());
        }

        /// <summary>
        /// Gets books.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sotrs.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>Books list.</returns>
        public List<BookViewModel> GetBooks(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip)
        {
            if (sorts.Count == 0)
            {
                sorts.Add("Id", ListSortDirection.Ascending);
            }

            return Mapper.Map<List<BookViewModel>>(this.bookRepository.Take(out total, sorts, filters, take, skip).ToList());
        }

        /// <summary>
        /// Checks if a book exists.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>True if the book exists, false otherwise.</returns>
        public bool BookExists(int id)
        {
            return this.bookRepository.FindById(id) != null;
        }

        /// <summary>
        /// Gets book view model.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book view model.</returns>
        public BookViewModel GetBook(int id)
        {
            return Mapper.Map<BookViewModel>(this.bookRepository.FindById(id));
        }

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void Manage(BookViewModel bookVM)
        {
            if (bookVM.Id == 0)
            {
                this.AddBook(bookVM);
            }
            else
            {
                this.EditBook(bookVM);
            }
        }

        /// <summary>
        /// Adds a new book to database.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void AddBook(BookViewModel bookVM)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Book book = Mapper.Map<Book>(bookVM);
                this.bookRepository.Add(book);
                this.bookRepository.SaveChanges();
                this.bookRepository.SetAuthors(book.Id, bookVM.AuthorsIds);
                this.bookRepository.SaveChanges();
                bookVM.Id = book.Id;
                scope.Complete();
            }
        }

        /// <summary>
        /// Edits a book in database.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void EditBook(BookViewModel bookVM)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Book book = this.bookRepository.FindById(bookVM.Id);
                Mapper.Map(bookVM, book);
                this.bookRepository.Modify(book);
                this.bookRepository.SaveChanges();
                book.Authors.Clear();
                this.bookRepository.SetAuthors(book.Id, bookVM.AuthorsIds);
                this.bookRepository.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        public void DeleteBook(int bookId)
        {
            Book book = this.bookRepository.FindById(bookId);
            if (book == null)
            {
                throw new InvalidFieldValueException("Book does not exists.");
            }

            this.bookRepository.Delete(book);
            this.bookRepository.SaveChanges();
        }

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <param name="bookId">Book identifier.</param>
        /// <returns>Authors' names.</returns>
        public string GetAuthors(int bookId)
        {
            StringBuilder authors = new StringBuilder();
            Book book = this.bookRepository.FindById(bookId);
            foreach (Author author in book.Authors)
            {
                authors.AppendLine(string.Format("{0} {1}", author.FirstName, author.SecondName));
            }

            return authors.ToString();
        }

        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML catalog.</returns>
        public XmlDocument GetXML()
        {
            return this.bookRepository.GetXML();
        }
    }
}