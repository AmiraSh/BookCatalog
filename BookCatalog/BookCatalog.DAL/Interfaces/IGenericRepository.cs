//-----------------------------------------------------------------------
// <copyright file="IGenericRepository.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Interfaces
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Infrastructure.Filtration;
    #endregion

    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">Database entity.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Finds instance by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Found instance.</returns>
        T FindById(int id);
        
        /// <summary>
        /// Gets all entities in database.
        /// </summary>
        /// <returns>All entities in database.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets table size.
        /// </summary>
        /// <returns>Table size.</returns>
        int GetSize();

        /// <summary>
        /// Gets specified count of entities from database.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sorting settings.</param>
        /// <param name="filters">Filters settings.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>Some entities from database.</returns>
        IEnumerable<T> Take(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip = 0);

        /// <summary>
        /// Sorts queryable set.
        /// </summary>
        /// <param name="set">Queryable set.</param>
        /// <param name="sorts">Sorting settings.</param>
        void Sort(ref IQueryable<T> set, Dictionary<string, ListSortDirection> sorts);

        /// <summary>
        /// Filters queryable set.
        /// </summary>
        /// <param name="set">Queryable set.</param>
        /// <param name="filters">Filters settings.</param>
        void Filter(ref IQueryable<T> set, List<CustomFilter> filters);

        /// <summary>
        /// Adds a new instance to database.
        /// </summary>
        /// <param name="instance">New instance.</param>
        void Add(T instance);
        
        /// <summary>
        /// Modifies existing instance.
        /// </summary>
        /// <param name="instance">Instance to modify.</param>
        void Modify(T instance);

        /// <summary>
        /// Deletes existing instance.
        /// </summary>
        /// <param name="instance">Instance to delete.</param>
        void Delete(T instance);
        
        /// <summary>
        /// Deletes existing instance.
        /// </summary>
        /// <param name="id">Id of an instance to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Finds the first instance that matches the filter.
        /// </summary>
        /// <param name="filter">Filter settings.</param>
        /// <returns>Found instance.</returns>
        T FirstOrDefault(Func<T, bool> filter);

        /// <summary>
        /// Finds all instances that match the filter.
        /// </summary>
        /// <param name="filter">Filter settings.</param>
        /// <returns>Found instances.</returns>
        IEnumerable<T> FindBy(Func<T, bool> filter);

        /// <summary>
        /// Saves changes in the database.
        /// </summary>
        void SaveChanges();
    }
}