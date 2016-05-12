//-----------------------------------------------------------------------
// <copyright file="CustomOperator.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Infrastructure.Filtration
{
    /// <summary>
    /// Custom operator for filtering.
    /// </summary>
    public enum CustomOperator
    {
        /// <summary>
        /// Contains.
        /// </summary>
        Contains,

        /// <summary>
        /// Is greater then.
        /// </summary>
        Greater,

        /// <summary>
        /// Is less then.
        /// </summary>
        Less,

        /// <summary>
        /// Is greater then or equal.
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// Is less then or equal.
        /// </summary>
        LessOrEqual
    }
}
