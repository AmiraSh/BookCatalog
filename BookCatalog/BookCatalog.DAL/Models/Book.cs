namespace BookCatalog.DAL.Models
{
    #region Using
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Book model.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }

        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets published date.
        /// </summary>
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets count of pages.
        /// </summary>
        public int PagesCount { get; set; }

        /// <summary>
        /// Gets or sets book's authors.
        /// </summary>
        public virtual ICollection<Author> Authors { get; set; }
    }
}