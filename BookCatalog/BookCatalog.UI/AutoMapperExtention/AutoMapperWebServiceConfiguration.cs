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
            Mapper.CreateMap<Services.BookWebService.BookViewModel, BookViewModel>();
            Mapper.CreateMap<BookViewModel, Services.BookWebService.BookViewModel>();

            Mapper.CreateMap<Services.BookWebService.AuthorViewModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, Services.BookWebService.AuthorViewModel>();

            Mapper.CreateMap<Services.BookWebService.ShortBookViewModel, ShortBookViewModel>();
            Mapper.CreateMap<ShortBookViewModel, Services.BookWebService.ShortBookViewModel>();

            Mapper.CreateMap<CustomFilter, Services.BookWebService.CustomFilter>();
            Mapper.CreateMap<Services.BookWebService.CustomFilter, CustomFilter>();

            Mapper.CreateMap<SelectListItem, Services.BookWebService.SelectListItem>();
            Mapper.CreateMap<Services.BookWebService.SelectListItem, SelectListItem>();

            Mapper.CreateMap<Sort, Services.BookWebService.Sort>();
            Mapper.CreateMap<Services.BookWebService.Sort, Sort>();

            Mapper.CreateMap<ListSortDirection, Services.BookWebService.ListSortDirection>();
            Mapper.CreateMap<Services.BookWebService.ListSortDirection, ListSortDirection>();

            Mapper.CreateMap<SelectListGroup, Services.BookWebService.SelectListGroup>();
            Mapper.CreateMap<Services.BookWebService.SelectListGroup, SelectListGroup>();
        }

        /// <summary>
        /// Configures author mapping rules.
        /// </summary>
        private static void ConfigureAuthorMapping()
        {
            Mapper.CreateMap<Services.AuthorWebService.AuthorViewModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, Services.AuthorWebService.AuthorViewModel>();

            Mapper.CreateMap<SearchTopAuthorsViewModel, Services.AuthorWebService.SearchTopAuthorsViewModel>();
            Mapper.CreateMap<Services.AuthorWebService.SearchTopAuthorsViewModel, SearchTopAuthorsViewModel>();

            Mapper.CreateMap<Services.AuthorWebService.ShortBookViewModel, ShortBookViewModel>();
            Mapper.CreateMap<ShortBookViewModel, Services.AuthorWebService.ShortBookViewModel>();

            Mapper.CreateMap<CustomFilter, Services.AuthorWebService.CustomFilter>();
            Mapper.CreateMap<Services.AuthorWebService.CustomFilter, CustomFilter>();

            Mapper.CreateMap<TopAuthorViewModel, Services.AuthorWebService.TopAuthorViewModel>();
            Mapper.CreateMap<Services.AuthorWebService.TopAuthorViewModel, TopAuthorViewModel>();

            Mapper.CreateMap<Sort, Services.AuthorWebService.Sort>();
            Mapper.CreateMap<Services.AuthorWebService.Sort, Sort>();

            Mapper.CreateMap<ListSortDirection, Services.AuthorWebService.ListSortDirection>();
            Mapper.CreateMap<Services.AuthorWebService.ListSortDirection, ListSortDirection>();
        }
    }
}