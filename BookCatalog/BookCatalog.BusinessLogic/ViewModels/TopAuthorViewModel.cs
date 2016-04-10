namespace BookCatalog.BusinessLogic.ViewModels
{
    #region Using
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// Top author view model.
    /// </summary>
    public class TopAuthorViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Display(Name = "First Name")]
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Display(Name = "Last Name")]
        [JsonProperty(PropertyName = "SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets the total rating.
        /// </summary>
        [Display(Name = "Total rating")]
        [JsonProperty(PropertyName = "TotalRating")]
        public int TotalRating { get; set; }
    }
}
