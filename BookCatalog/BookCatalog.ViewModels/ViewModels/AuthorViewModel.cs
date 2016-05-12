//-----------------------------------------------------------------------
// <copyright file="AuthorViewModel.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.ViewModels.ViewModels
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
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
            this.Books = new List<ShortBookViewModel>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(150, MinimumLength = 1)]
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the second name.
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(150, MinimumLength = 1)]
        [JsonProperty(PropertyName = "SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets the books' count.
        /// </summary>
        [Display(Name = "Books Count")]
        [JsonProperty(PropertyName = "BooksCount")]
        public int BooksCount { get; set; }

        /// <summary>
        /// Gets or sets the books' list.
        /// </summary>
        [Display(Name = "Books")]
        [JsonProperty(PropertyName = "Books")]
        public List<ShortBookViewModel> Books { get; set; }
    }
}