namespace BookCatalog.BusinessLogic.ViewModels
{
    using System.Collections.Generic;
    #region Using
    using System.ComponentModel.DataAnnotations;
    using DAL.Models;
    #endregion

    /// <summary>
    /// Author view model.
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorViewModel"/> class.
        /// </summary>
        public AuthorViewModel()
        {
            Books = new Dictionary<string, int>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the second name.
        /// </summary>
        [Display(Name = "Last Name")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets the books' count.
        /// </summary>
        [Display(Name = "Books Count")]
        public int BooksCount { get; set; }

        /// <summary>
        /// Gets or sets the books' list.
        /// </summary>
        [Display(Name = "Books")]
        public Dictionary<string, int> Books { get; set; }     
    }
}