namespace BookCatalog.BusinessLogic.Mappers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Author mapper.
    /// </summary>
    public static class AuthorMapper
    {
        /// <summary>
        /// Maps list of authors to list of authors view models.
        /// </summary>
        /// <param name="authors">List of authors.</param>
        /// <returns>List of authors view models.</returns>
        public static List<AuthorViewModel> Map(List<Author> authors)
        {
            List<AuthorViewModel> authorVMlist = new List<AuthorViewModel>();
            foreach (Author author in authors)
            {
                authorVMlist.Add(Map(author));
            }

            return authorVMlist;
        }

        /// <summary>
        /// Maps author to author view models.
        /// </summary>
        /// <param name="author">Author.</param>
        /// <returns>Author view model.</returns>
        public static AuthorViewModel Map(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }

            AuthorViewModel authorVM = new AuthorViewModel();
            authorVM.Id = author.Id;
            authorVM.FirstName = author.FirstName;
            authorVM.SecondName = author.SecondName;
            authorVM.BooksCount = author.Books.Count;
            foreach (var book in author.Books)
            {
                authorVM.Books.Add(book.Name, book.PublishedDate.Year);
            }

            return authorVM;
        }

        /// <summary>
        /// Maps author view model to author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author.</returns>
        public static Author Map(AuthorViewModel authorVM)
        {
            Author author = new Author();
            author.FirstName = authorVM.FirstName;
            author.SecondName = authorVM.SecondName;
            return author;
        }

        /// <summary>
        /// Maps author view model to author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <param name="author">Author.</param>
        public static void Map(AuthorViewModel authorVM, ref Author author)
        {
            author.FirstName = authorVM.FirstName;
            author.SecondName = authorVM.SecondName;
        }
    }
}