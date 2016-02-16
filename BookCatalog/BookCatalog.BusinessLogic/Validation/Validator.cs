namespace BookCatalog.BusinessLogic.Validation
{
    #region Using
    using System;
    using ViewModels;
    #endregion

    /// <summary>
    /// Validator.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates book view model.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static int Validate(BookViewModel bookVM)
        {
            if (bookVM.AuthorsIds.Count == 0)
            {
                return 1;
            }

            if (string.IsNullOrEmpty(bookVM.Name))
            {
                return 2;
            }

            if (bookVM.PagesCount < 1 || bookVM.PagesCount > 20000)
            {
                return 3;
            }

            if (bookVM.PublishedDate.CompareTo(DateTime.Now) > -1)
            {
                return 4;
            }

            if (!IsValidSqlDateTimeNative(bookVM.PublishedDate.ToString()))
            {
                return 5;
            }

            return 0;
        }

        /// <summary>
        /// Validates author view model.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static int Validate(AuthorViewModel authorVM)
        {
            if (string.IsNullOrEmpty(authorVM.FirstName))
            {
                return 1;
            }

            if (string.IsNullOrEmpty(authorVM.SecondName))
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// Verifies whether a value is 
        /// kosher for SQL Server datetime. This uses the native library
        /// for checking range values
        /// </summary>
        /// <param name="someval">A date string that may parse</param>
        /// <returns>true if the parameter is valid for SQL Sever datetime</returns>
        private static bool IsValidSqlDateTimeNative(string someval)
        {
            bool valid = false;
            DateTime testDate = DateTime.MinValue;
            System.Data.SqlTypes.SqlDateTime sdt;
            if (DateTime.TryParse(someval, out testDate))
            {
                try
                {
                    sdt = new System.Data.SqlTypes.SqlDateTime(testDate);
                    valid = true;
                }
                catch { }
            }

            return valid;
        }
    }
}