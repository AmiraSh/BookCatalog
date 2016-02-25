namespace BookCatalog.BusinessLogic.Mappers
{
    #region Using
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Author mapper.
    /// </summary>
    public static class AuthorMapper
    {
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