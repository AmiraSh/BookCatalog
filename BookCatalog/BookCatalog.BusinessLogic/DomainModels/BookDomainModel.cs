//-----------------------------------------------------------------------
// <copyright file="BookDomainModel.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.BusinessLogic.DomainModels
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
    using DAL.Concrete;
    using DAL.Interfaces;
    using DAL.Models;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using Components.ViewModels;
    #endregion

    /// <summary>
    /// Book domain model.
    /// </summary>
    public class BookDomainModel
    {
        /// <summary>
        /// Gets book repository.
        /// </summary>
        private IBookRepository BookRepository { get; set; }

        /// <summary>
        /// Gets author repository.
        /// </summary>
        private IAuthorRepository AuthorRepository { get; set; }


        public BookDomainModel(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }

        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        public int GetBooksCount()
        {
            return this.BookRepository.GetSize();
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <returns>Select list.</returns>
        public List<SelectListItem> PopulateMultiSelectList()
        {
            return new MultiSelectList(this.AuthorRepository.GetAll().ToList().Select(author => new SelectListItem() { Text = string.Format("{0} {1}", author.FirstName, author.SecondName), Value = author.Id.ToString() }).ToList(), "Value", "Text").ToList();
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void PopulateMultiSelectList(BookViewModel bookVM)
        {
            bookVM.AuthorsOptions = new MultiSelectList(this.AuthorRepository.GetAll().ToList().Select(author => new SelectListItem() { Text = string.Format("{0} {1}", author.FirstName, author.SecondName), Value = author.Id.ToString(), Selected = bookVM.Authors.FirstOrDefault(bookAuthor => bookAuthor.Id == author.Id) != null }), "Value", "Text").ToList();
        }

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <returns>Authors' names.</returns>
        public Dictionary<int, string> GetAuthorsList()
        {
            return this.AuthorRepository.GetAll().ToDictionary(author => author.Id, author => string.Format("{0} {1}", author.FirstName, author.SecondName));
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books list.</returns>
        public List<BookViewModel> GetBooks()
        {
            return Mapper.Map<List<BookViewModel>>(this.BookRepository.GetAll().ToList());
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

            return Mapper.Map<List<BookViewModel>>(this.BookRepository.Take(out total, sorts, filters, take, skip).ToList());
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
        public List<BookViewModel> GetBooks(out int total, List<Sort> sorts, List<CustomFilter> filters, int take, int skip)
        {
            return this.GetBooks(out total, sorts.ToDictionary(s => s.FieldName, s => s.SortDirection), filters, take, skip);
        }

        /// <summary>
        /// Checks if a book exists.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>True if the book exists, false otherwise.</returns>
        public bool BookExists(int id)
        {
            return this.BookRepository.FindById(id) != null;
        }

        /// <summary>
        /// Gets book view model.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book view model.</returns>
        public BookViewModel GetBook(int id)
        {
            return Mapper.Map<BookViewModel>(this.BookRepository.FindById(id));
        }

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Book identifier.</returns>
        public int Manage(BookViewModel bookVM)
        {
            return bookVM.Id == 0 ? this.AddBook(bookVM) : this.EditBook(bookVM);
        }

        /// <summary>
        /// Adds a new book to database.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Book identifier.</returns>
        public int AddBook(BookViewModel bookVM)
        {
            int bookId = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                Book book = Mapper.Map<Book>(bookVM);
                this.BookRepository.Add(book);
                this.BookRepository.SaveChanges();
                this.BookRepository.SetAuthors(book.Id, bookVM.AuthorsIds);
                this.BookRepository.SaveChanges();
                bookId = bookVM.Id = book.Id;
                scope.Complete();
            }

            return bookId;
        }

        /// <summary>
        /// Edits a book in database.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Book identifier.</returns>
        public int EditBook(BookViewModel bookVM)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Book book = this.BookRepository.FindById(bookVM.Id);
                Mapper.Map(bookVM, book);
                this.BookRepository.Modify(book);
                this.BookRepository.SaveChanges();
                book.Authors.Clear();
                this.BookRepository.SetAuthors(book.Id, bookVM.AuthorsIds);
                this.BookRepository.SaveChanges();
                scope.Complete();
            }

            return bookVM.Id;
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        public void DeleteBook(int bookId)
        {
            Book book = this.BookRepository.FindById(bookId);
            if (book == null)
            {
                throw new InvalidFieldValueException("Book does not exists.");
            }

            this.BookRepository.Delete(book);
            this.BookRepository.SaveChanges();
        }

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <param name="bookId">Book identifier.</param>
        /// <returns>Authors' names.</returns>
        public string GetAuthors(int bookId)
        {
            StringBuilder authors = new StringBuilder();
            Book book = this.BookRepository.FindById(bookId);
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
            return this.BookRepository.GetXML();
        }
    }
}