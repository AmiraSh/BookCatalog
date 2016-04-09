namespace BookCatalog.BusinessLogic.ViewModels
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// Book view model.
    /// </summary>
    public class BookViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookViewModel"/> class.
        /// </summary>
        public BookViewModel()
        {
            this.Authors = new List<AuthorViewModel>();
            this.AuthorsIds = new List<int>();
            this.PublishedDate = DateTime.Now.Date;
            this.Rating = 3;
            this.AuthorsOptions = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(150, MinimumLength = 1)]
        [Display(Name = "Name")]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        [Required(ErrorMessage = "Published date is required.")]
        [Display(Name = "Published Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [JsonProperty(PropertyName = "PublishedDate")]
        public DateTime PublishedDate { get; set; }

        /// <summary>
        /// Gets or sets the count of pages.
        /// </summary>
        [Required(ErrorMessage = "Pages' count is required.")]
        [Range(minimum: 1, maximum: 20000)]
        [Display(Name = "Pages Count")]
        [JsonProperty(PropertyName = "PagesCount")]
        public int PagesCount { get; set; }

        /// <summary>
        /// Gets or sets the description of the book.
        /// </summary>
        [System.Web.Mvc.AllowHtml]
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets rating.
        /// </summary>
        [Required(ErrorMessage = "Rating is required.")]
        [Range(minimum: 1, maximum: 5)]
        [Display(Name = "Rating")]
        [JsonProperty(PropertyName = "Rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the book's authors.
        /// </summary>
        [Display(Name = "Authors")]
        [JsonProperty(PropertyName = "Authors")]
        public List<AuthorViewModel> Authors { get; set; }

        /// <summary>
        /// Gets or sets the book's authors ids.
        /// </summary>
        [Required(ErrorMessage = "You need to specify at least one author.")]
        [Display(Name = "Authors")]
        [JsonProperty(PropertyName = "AuthorsIds")]
        public List<int> AuthorsIds { get; set; }

        /// <summary>
        /// Gets or sets multi select list.
        /// </summary>
        [JsonProperty(PropertyName = "AuthorsOptions")]
        public List<SelectListItem> AuthorsOptions { get; set; }
    }
}