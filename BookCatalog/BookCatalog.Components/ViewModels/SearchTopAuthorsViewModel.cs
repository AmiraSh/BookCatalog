//-----------------------------------------------------------------------
// <copyright file="SearchTopAuthorsViewModel.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Components.ViewModels
{
    #region Using
    using System;
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// View model for searching top autors.
    /// </summary>
    public class SearchTopAuthorsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTopAuthorsViewModel"/> class.
        /// </summary>
        public SearchTopAuthorsViewModel()
        {
            this.Count = 5;
            this.BeginDate = DateTime.Now.AddYears(-10).Date;
            this.EndDate = DateTime.Now;
        }

        /// <summary>
        /// Authors' count to find.
        /// </summary>
        [Required(ErrorMessage = "Count is required.")]
        [Display(Name = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// Begin date.
        /// </summary>
        [Required(ErrorMessage = "Begin date is required.")]
        [Display(Name = "Begin Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// End date.
        /// </summary>
        [Required(ErrorMessage = "End date is required.")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
