//-----------------------------------------------------------------------
// <copyright file="AutoMapperWebServiceConfiguration.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.AutoMapperExtention
{
    #region Using
    using System.ComponentModel;
    using System.Web.Mvc;
    using AutoMapper;
    using Components.ViewModels;
    using Infrastructure.Filtration;
    #endregion

    /// <summary>
    /// Auto mapper configuration.
    /// </summary>
    public static class AutoMapperWebServiceConfiguration
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
        /// Configures book mapping rules.
        /// </summary>
        private static void ConfigureBookMapping()
        {
            Mapper.CreateMap<BookWebService.BookViewModel, BookViewModel>();
            Mapper.CreateMap<BookViewModel, BookWebService.BookViewModel>();

            Mapper.CreateMap<BookWebService.AuthorViewModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, BookWebService.AuthorViewModel>();

            Mapper.CreateMap<BookWebService.ShortBookViewModel, ShortBookViewModel>();
            Mapper.CreateMap<ShortBookViewModel, BookWebService.ShortBookViewModel>();

            Mapper.CreateMap<CustomFilter, BookWebService.CustomFilter>();
            Mapper.CreateMap<BookWebService.CustomFilter, CustomFilter>();

            Mapper.CreateMap<SelectListItem, BookWebService.SelectListItem>();
            Mapper.CreateMap<BookWebService.SelectListItem, SelectListItem>();

            Mapper.CreateMap<Sort, BookWebService.Sort>();
            Mapper.CreateMap<BookWebService.Sort, Sort>();

            Mapper.CreateMap<ListSortDirection, BookWebService.ListSortDirection>();
            Mapper.CreateMap<BookWebService.ListSortDirection, ListSortDirection>();

            Mapper.CreateMap<SelectListGroup, BookWebService.SelectListGroup>();
            Mapper.CreateMap<BookWebService.SelectListGroup, SelectListGroup>();
        }

        /// <summary>
        /// Configures author mapping rules.
        /// </summary>
        private static void ConfigureAuthorMapping()
        {
            Mapper.CreateMap<AuthorWebService.AuthorViewModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, AuthorWebService.AuthorViewModel>();

            Mapper.CreateMap<SearchTopAuthorsViewModel, AuthorWebService.SearchTopAuthorsViewModel>();
            Mapper.CreateMap<AuthorWebService.SearchTopAuthorsViewModel, SearchTopAuthorsViewModel>();

            Mapper.CreateMap<AuthorWebService.ShortBookViewModel, ShortBookViewModel>();
            Mapper.CreateMap<ShortBookViewModel, AuthorWebService.ShortBookViewModel>();

            Mapper.CreateMap<CustomFilter, AuthorWebService.CustomFilter>();
            Mapper.CreateMap<AuthorWebService.CustomFilter, CustomFilter>();

            Mapper.CreateMap<TopAuthorViewModel, AuthorWebService.TopAuthorViewModel>();
            Mapper.CreateMap<AuthorWebService.TopAuthorViewModel, TopAuthorViewModel>();

            Mapper.CreateMap<Sort, AuthorWebService.Sort>();
            Mapper.CreateMap<AuthorWebService.Sort, Sort>();

            Mapper.CreateMap<ListSortDirection, AuthorWebService.ListSortDirection>();
            Mapper.CreateMap<AuthorWebService.ListSortDirection, ListSortDirection>();
        }
    }
}