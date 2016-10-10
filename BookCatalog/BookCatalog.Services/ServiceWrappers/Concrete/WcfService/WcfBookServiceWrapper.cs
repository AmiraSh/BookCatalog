//-----------------------------------------------------------------------
// <copyright file="WcfBookServiceWrapper.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Services.ServiceWrappers.Concrete.WcfService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using BookService;
    using BookCatalog.Components.ViewModels;
    using Infrastructure.Filtration;
    using Interfaces;
    #endregion Using

    /// <summary>
    /// Wcf book service wrapper.
    /// </summary>
    public class WcfBookServiceWrapper : IBookServiceWrapper
    {        
        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IBookService DomainModel { get; set; }

        public WcfBookServiceWrapper(IBookService domainModel)
        {
            Infrastructure.Logging.Concrete.InfoLogger.Log("WcfBookServiceWrapper", "Constructor");
            this.DomainModel = domainModel;
        }

        ~WcfBookServiceWrapper()
        {
            Infrastructure.Logging.Concrete.InfoLogger.Log("WcfBookServiceWrapper", "Destructor");
        }

        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        public int GetBooksCount()
        {
            return this.DomainModel.GetBooksCount();
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books list.</returns>
        public List<BookViewModel> GetAllBooks()
        {
            return this.DomainModel.GetAllBooks();
        }

        /// <summary>
        /// Gets books.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sorting settings.</param>
        /// <param name="filters">Filters settings.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>Books list.</returns>
        public List<BookViewModel> GetBooks(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip)
        {
            GetBooksResponse response = this.DomainModel.GetBooks(new GetBooksRequest(sorts, filters, take, skip));
            total = response.total;
            return response.GetBooksResult;
        }

        /// <summary>
        /// Checks if a book exists.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>True if the book exists, false otherwise.</returns>
        public bool BookExists(int id)
        {
            return this.DomainModel.BookExists(id);
        }

        /// <summary>
        /// Gets book view model.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book view model.</returns>
        public BookViewModel GetBook(int id)
        {
            return this.DomainModel.GetBook(id);
        }

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void Manage(BookViewModel bookVM)
        {
            int bookId = this.DomainModel.Manage(bookVM);
            bookVM.Id = bookId;
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        public void Delete(int bookId)
        {
            this.DomainModel.Delete(bookId);
        }

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <param name="bookId">Book identifier.</param>
        /// <returns>Authors' names.</returns>
        public string GetAuthors(int bookId)
        {
            return this.DomainModel.GetAuthors(bookId);
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <returns>Multi select list.</returns>
        public List<SelectListItem> PopulateMultiSelectList()
        {
            return this.DomainModel.PopulateMultiSelectList();
        }

        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML catalog.</returns>
        public string GetXML()
        {
            return this.DomainModel.GetXML(new GetXMLRequest()).Body.GetXMLResult.ToString();
        }
    }
}