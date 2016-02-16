namespace BookCatalog
{
    #region Using
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Filters configuration.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers global filters.
        /// </summary>
        /// <param name="filters">Global filters collection.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
