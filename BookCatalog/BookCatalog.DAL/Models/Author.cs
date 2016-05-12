//-----------------------------------------------------------------------
// <copyright file="Author.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Models
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Author model.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(150, MinimumLength = 1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets second name.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(150, MinimumLength = 1)]
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets author's books.
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}