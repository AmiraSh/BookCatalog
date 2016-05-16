//-----------------------------------------------------------------------
// <copyright file="IBookService.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalogService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ServiceModel;
    using System.Web.Mvc;
    using System.Xml;
    using BookCatalog.Components.ViewModels;
    using BookCatalog.Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Books' service interface.
    /// </summary>
    [ServiceContract, ProtoBuf.ProtoContract]
    public interface IBookService
    {
        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        [OperationContract]
        int GetBooksCount();

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books list.</returns>
        [OperationContract]
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
        [OperationContract]
        List<BookViewModel> GetBooks(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip);

        /// <summary>
        /// Checks if a book exists.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>True if the book exists, false otherwise.</returns>
        [OperationContract]
        bool BookExists(int id);

        /// <summary>
        /// Gets book view model.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book view model.</returns>
        [OperationContract]
        BookViewModel GetBook(int id);

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Book identifier.</returns>
        [OperationContract]
        int Manage(BookViewModel bookVM);

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        [OperationContract]
        void Delete(int bookId);

        /// <summary>
        /// Gets authors' names.
        /// </summary>
        /// <param name="bookId">Book identifier.</param>
        /// <returns>Authors' names.</returns>
        [OperationContract]
        string GetAuthors(int bookId);
        
        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <returns>Multi select list.</returns>
        [OperationContract]
        List<SelectListItem> PopulateMultiSelectList();

        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML catalog.</returns>
        [OperationContract, XmlSerializerFormat]
        XmlDocument GetXML();
    }    
}
