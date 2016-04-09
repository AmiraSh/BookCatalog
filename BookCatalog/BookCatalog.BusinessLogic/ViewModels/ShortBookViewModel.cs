﻿namespace BookCatalog.BusinessLogic.ViewModels
{
    #region Using
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// Short book view model.
    /// </summary>
    public class ShortBookViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the published year.
        /// </summary>
        [JsonProperty(PropertyName = "Year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets rating.
        /// </summary>
        [JsonProperty(PropertyName = "Rating")]
        public int Rating { get; set; }
    }
}
