//-----------------------------------------------------------------------
// <copyright file="Sort.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
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
        /// Gets or sets field name.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets sort direction.
        /// </summary>
        public ListSortDirection SortDirection { get; set; }
    }
}
