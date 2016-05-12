//-----------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.AutoMapperExtention
{
    #region Using
    using AutoMapper;
    using Components.ViewModels;
    using Infrastructure.Filtration;
    #endregion

    /// <summary>
    /// Auto mapper configuration.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Configures auto mapper.
        /// </summary>
        public static void Configure()
        {
            Mapper.CreateMap<BookWebService.BookViewModel, BookViewModel>();
            Mapper.CreateMap<BookWebService.AuthorViewModel, AuthorViewModel>();
            Mapper.CreateMap<BookWebService.ShortBookViewModel, ShortBookViewModel>();

            Mapper.CreateMap<BookViewModel, BookWebService.BookViewModel>();
            Mapper.CreateMap<AuthorViewModel, BookWebService.AuthorViewModel>();
            Mapper.CreateMap<ShortBookViewModel, BookWebService.ShortBookViewModel>();

            Mapper.CreateMap<Sort, BookWebService.Sort>();
            Mapper.CreateMap<BookWebService.Sort, Sort>();
        }

        /// <summary>
        /// Ignores all unmapped members.
        /// </summary>
        /// <typeparam name="TSource">Source.</typeparam>
        /// <typeparam name="TDest">Destination.</typeparam>
        /// <param name="expression">Expression.</param>
        /// <returns>Mapping expression.</returns>
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
    }
}