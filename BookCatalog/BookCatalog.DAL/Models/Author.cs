namespace BookCatalog.DAL.Models
{
    #region Using
    using System.Collections.Generic;
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
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets second name.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets author's books.
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}