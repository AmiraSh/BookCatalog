//-----------------------------------------------------------------------
// <copyright file="Validator.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Components.Validation
{
    #region Using
    using System;
    using Infrastructure.Errors;
    using ViewModels;
    #endregion

    /// <summary>
    /// The validator.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates book view model.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        public static void Validate(BookViewModel bookVM)
        {
            if (bookVM.AuthorsIds.Count == 0)
            {
                throw new InvalidFieldValueException("You need to specify at least one author.", "AuthorsIds");
            }

            if (string.IsNullOrEmpty(bookVM.Name))
            {
                throw new InvalidFieldValueException("Name is required.", "Name");
            }

            if (bookVM.PagesCount < 1 || bookVM.PagesCount > 20000)
            {
                throw new InvalidFieldValueException("Pages' count should be in range from 1 to 20,000.", "PagesCount");
            }

            if (bookVM.Rating < 1 || bookVM.Rating > 5)
            {
                throw new InvalidFieldValueException("Rating should be between 1 and 5.", "Rating");
            }

            if (bookVM.PublishedDate.CompareTo(DateTime.Now) > -1)
            {
                throw new InvalidFieldValueException("Published day should ealier then today.", "PublishedDate");
            }

            ValidateSqlDateTimeNative(bookVM.PublishedDate.ToString());
        }

        /// <summary>
        /// Validates author view model.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        public static void Validate(AuthorViewModel authorVM)
        {
            if (string.IsNullOrEmpty(authorVM.FirstName))
            {
                throw new InvalidFieldValueException("First name is required.", "FirstName");
            }

            if (string.IsNullOrEmpty(authorVM.SecondName))
            {
                throw new InvalidFieldValueException("Second name is required.", "SecondName");
            }
        }

        /// <summary>
        /// Verifies whether a value is 
        /// kosher for SQL Server datetime. This uses the native library
        /// for checking range values
        /// </summary>
        /// <param name="someval">A date string that may parse</param>
        private static void ValidateSqlDateTimeNative(string someval)
        {
            DateTime testDate = DateTime.MinValue;
            System.Data.SqlTypes.SqlDateTime sdt;
            if (DateTime.TryParse(someval, out testDate))
            {
                try
                {
                    sdt = new System.Data.SqlTypes.SqlDateTime(testDate);
                }
                catch (System.Data.SqlTypes.SqlTypeException exception)
                {
                    throw new InvalidFieldValueException("Published day is in wrong format.", "PublishedDate", exception);
                }
            }
        }
    }
}