namespace BookCatalog.BusinessLogic.Mappers
{
    #region Using
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Book mapper.
    /// </summary>
    public static class BookMapper
    {
        /// <summary>
        /// Maps book view model to book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <param name="book">Book.</param>
        public static void Map(BookViewModel bookVM, ref Book book)
        {
            book.Name = bookVM.Name;
            book.PagesCount = bookVM.PagesCount;
            book.PublishedDate = bookVM.PublishedDate;
            book.Description = bookVM.Description;
        }
    }
}