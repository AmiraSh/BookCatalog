namespace BookCatalog.KendoAnalysing
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using Infrastructure.Filtration;
    using Kendo.Mvc;
    #endregion

    /// <summary>
    /// Analyser for Kendo filters and sorts.
    /// </summary>
    public static class KendoAnalyser
    {
        /// <summary>
        /// Gets sortings dictionary.
        /// </summary>
        /// <param name="sortDescriptors">Sorting descriptors.</param>
        /// <returns>Dictionary for sorting descriptors.</returns>
        public static Dictionary<string, ListSortDirection> GetSorts(IList<SortDescriptor> sortDescriptors)
        {
            var sorts = new Dictionary<string, ListSortDirection>();
            foreach (var sort in sortDescriptors)
            {
                sorts.Add(sort.Member, sort.SortDirection);
            }

            return sorts;
        }

        /// <summary>
        /// Gets filters list.
        /// </summary>
        /// <param name="filtersDescriptors">Filters descriptors.</param>
        /// <returns>Filters list.</returns>
        public static List<CustomFilter> GetFilters(IList<IFilterDescriptor> filtersDescriptors)
        {
            var filters = new List<CustomFilter>();
            var descriptors = new List<FilterDescriptor>();
            foreach (var filterDescriptor in filtersDescriptors)
            {
                descriptors.AddRange(GetDescriptors(filterDescriptor));
            }

            foreach (FilterDescriptor filter in descriptors)
            {
                var customFilter = new CustomFilter()
                {
                    Member = filter.Member,
                    MemberType = filter.Value.GetType(),
                    Value = filter.Value
                };
                switch (filter.Operator)
                {
                    case FilterOperator.Contains:
                        customFilter.Operator = CustomOperator.Contains;
                        break;
                    case FilterOperator.IsGreaterThan:
                        customFilter.Operator = CustomOperator.Greater;
                        break;
                    case FilterOperator.IsLessThan:
                        customFilter.Operator = CustomOperator.Less;
                        break;
                    case FilterOperator.IsGreaterThanOrEqualTo:
                        customFilter.Operator = CustomOperator.GreaterOrEqual;
                        break;
                    case FilterOperator.IsLessThanOrEqualTo:
                        customFilter.Operator = CustomOperator.LessOrEqual;
                        break;
                }

                filters.Add(customFilter);
            }

            return filters;
        }

        /// <summary>
        /// Gets filters list.
        /// </summary>
        /// <param name="filterDescriptor">Filter's descriptor.</param>
        /// <returns>Filters list.</returns>
        private static List<FilterDescriptor> GetDescriptors(IFilterDescriptor filterDescriptor)
        {
            var descriptors = new List<FilterDescriptor>();
            if (filterDescriptor.GetType() == typeof(FilterDescriptor))
            {
                descriptors.Add(filterDescriptor as FilterDescriptor);
            }
            else
            {
                foreach (IFilterDescriptor filter in (filterDescriptor as CompositeFilterDescriptor).FilterDescriptors)
                {
                    descriptors.AddRange(GetDescriptors(filter));
                }
            }

            return descriptors;
        }
    }
}