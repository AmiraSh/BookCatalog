//-----------------------------------------------------------------------
// <copyright file="WebBookServiceWrapper.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.ServiceWrappers.Concrete.WebService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using BookCatalog.UI.ServiceWrappers.Interfaces;
    using Components.ViewModels;
    using Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Web author service wrapper.
    /// </summary>
    public class WebBookServiceWrapper : IBookServiceWrapper
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private BookWebService.BookWebServiceSoap domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private BookWebService.BookWebServiceSoap DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = (BookWebService.BookWebServiceSoap)DependencyResolver.Current.GetService(typeof(BookWebService.BookWebServiceSoap));
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
            return Mapper.Map<List<BookViewModel>>(this.DomainModel.GetAllBooks());
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
            BookWebService.GetBooksResponse response = this.DomainModel.GetBooks(new BookWebService.GetBooksRequest(Mapper.Map<BookWebService.Sort[]>(sorts.Select(x => new Sort() { FieldName = x.Key, SortDirection = x.Value }).ToArray()), Mapper.Map<BookWebService.CustomFilter[]>(filters), take, skip));
            total = response.total;
            return Mapper.Map<List<BookViewModel>>(response.GetBooksResult);
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
            return Mapper.Map<BookViewModel>(this.DomainModel.GetBook(id));
        }

        /// <summary>
        /// Adds or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public void Manage(BookViewModel bookVM)
        {
            int bookId = this.DomainModel.Manage(Mapper.Map<BookWebService.BookViewModel>(bookVM));
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
            return Mapper.Map<List<SelectListItem>>(this.DomainModel.PopulateMultiSelectList());
        }

        /// <summary>
        /// Gets data in XML document.
        /// </summary>
        /// <returns>XML catalog.</returns>
        public string GetXML()
        {
            return this.DomainModel.GetXML().OuterXml;
        }
    }
}