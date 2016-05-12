//-----------------------------------------------------------------------
// <copyright file="BookService.svc.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalogService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using System.Xml;
    using BookCatalog.BusinessLogic.DomainModel;
    using BookCatalog.ViewModels.ViewModels;
    using BookCatalog.Infrastructure.Filtration;
    using Configurations;
    #endregion Using

    /// <summary>
    /// Books' service.
    /// </summary>
    [AutomapServiceBehavior]
    public class BookService : IBookService
    {
        /// <summary>
        /// Book domain model.
        /// </summary>
        private BookDomainModel domainModel;

        /// <summary>
        /// Gets book domain model.
        /// </summary>
        private BookDomainModel DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = new BookDomainModel();
            }
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
            return this.DomainModel.GetBooks();
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
            return this.DomainModel.GetBooks(out total, sorts, filters, take, skip);
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
        public int Manage(BookViewModel bookVM)
        {
            return this.DomainModel.Manage(bookVM);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        public void Delete(int bookId)
        {
            this.DomainModel.DeleteBook(bookId);
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
        public XmlDocument GetXML()
        {
            return this.DomainModel.GetXML();
        }
    }
}
