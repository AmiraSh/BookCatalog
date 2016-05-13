//-----------------------------------------------------------------------
// <copyright file="CustomFilter.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Infrastructure.Filtration
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Filter for database sets.
    /// </summary>
    public class CustomFilter
    {
        /// <summary>
        /// Gets or sets the value for filtering.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the type of member to filter.
        /// </summary>
        public Type MemberType { get; set; }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public CustomOperator Operator { get; set; }
    }
}
