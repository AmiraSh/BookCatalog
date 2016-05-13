//-----------------------------------------------------------------------
// <copyright file="IBookServiceWrapper.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.ServiceWrappers.Interfaces
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using System.Xml;
    using BookCatalog.Components.ViewModels;
    using Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Book service wrapper interface.
    /// </summary>
    public interface IBookServiceWrapper
    {
        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        int GetBooksCount();

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books list.</returns>
        List<BookViewModel> GetAllBooks();

        /// <summary>
        /// Gets books.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sorting settings.</param>
        /// <param name="filters">Filters settings.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>Books list.</returns>
        List<BookViewModel> GetBooks(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip);

        /// <summary>
        /// Checks if a book exists.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>True if the book exists, false otherwise.</returns>
        bool BookExists(int id);

        /// <summary>
        /// Gets book view model.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book view model.</returns>
        BookViewModel GetBook(int id);

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        void Manage(BookViewModel bookVM);

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        void Delete(int bookId);

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <param name="bookId">Book identifier.</param>
        /// <returns>Authors' names.</returns>
        string GetAuthors(int bookId);

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <returns>Multi select list.</returns>
        List<SelectListItem> PopulateMultiSelectList();

        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML catalog.</returns>
        string GetXML();
    }
}