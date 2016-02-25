namespace BookCatalog.DAL.Models
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
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
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(150, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets published date.
        /// </summary>
        [Required(ErrorMessage = "Published date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets count of pages.
        /// </summary>
        [Required(ErrorMessage = "Pages' count is required.")]
        [Range(minimum: 1, maximum: 20000)]
        public int PagesCount { get; set; }

        /// <summary>
        /// Gets or sets rating.
        /// </summary>
        [Range(minimum: 1, maximum: 5)]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the description of the book.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets book's authors.
        /// </summary>
        [Required(ErrorMessage = "You need to specify at least one author.")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}