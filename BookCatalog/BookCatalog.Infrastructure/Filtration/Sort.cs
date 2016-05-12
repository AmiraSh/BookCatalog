namespace BookCatalog.Infrastructure.Filtration
{
    #region Using
    using System.ComponentModel;
    #endregion Using

    /// <summary>
    /// Sort settings.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Field name.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Sort direction.
        /// </summary>
        public ListSortDirection SortDirection { get; set; }
    }
}
