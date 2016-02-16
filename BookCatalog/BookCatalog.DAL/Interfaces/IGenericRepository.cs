namespace BookCatalog.DAL.Interfaces
{
    #region Using

    using System;
    using System.Collections.Generic;

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
        /// <param name="id">Identifier.</param>
        /// <returns>Found instance.</returns>
        T FindById(int id);
        
        /// <summary>
        /// Gets all entities in database.
        /// </summary>
        /// <returns>All entities in database.</returns>
        IEnumerable<T> GetAll();

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
        /// <param name="filter">Filter.</param>
        /// <returns>Found instance.</returns>
        T FirstOrDefault(Func<T, bool> filter);

        /// <summary>
        /// Finds all instances that match the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Found instances.</returns>
        IEnumerable<T> FindBy(Func<T, bool> filter);

        /// <summary>
        /// Saves changes in the database.
        /// </summary>
        void SaveChanges();
    }
}