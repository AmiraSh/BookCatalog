namespace BookCatalog.DAL.Concrete
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Dynamic;
    using BookCatalog.DAL.Interfaces;
    using Infrastructure.Filtration;
    #endregion

    /// <summary>
    /// Implementation of generic repository interface.
    /// </summary>
    /// <typeparam name="C">Database context.</typeparam>
    /// <typeparam name="T">Database entity.</typeparam>
    public abstract class GenericRepository<C, T> : IGenericRepository<T>
        where T : class
        where C : DbContext, new()
    {
        /// <summary>
        /// Database context.
        /// </summary>
        private C entities = new C();

        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        public C Context
        {
            get { return this.entities; }
            set { this.entities = value; }
        }

        /// <summary>
        /// Finds instance by id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Found instance.</returns>
        public T FindById(int id)
        {
            return this.entities.Set<T>().Find(id);
        }

        /// <summary>
        /// Gets all entities in database.
        /// </summary>
        /// <returns>All entities in database.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this.entities.Set<T>().ToList();
        }

        /// <summary>
        /// Gets table size.
        /// </summary>
        /// <returns>Table size.</returns>
        public int GetSize()
        {
            return this.entities.Set<T>().Count();
        }

        /// <summary>
        /// Gets specified count of entities from database.
        /// </summary>
        /// <param name="sorts">Sotrings.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>Some entities from database.</returns>
        public IEnumerable<T> Take(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip = 0)
        {
            var result = this.entities.Set<T>().AsQueryable();
            Sort(ref result, sorts);
            Filter(ref result, filters);
            total = result.Count();
            return result.Skip(skip).Take(take);
        }
        
        /// <summary>
        /// Sorts queryable set.
        /// </summary>
        /// <param name="set">Queryable set.</param>
        /// <param name="sorts">Sortings.</param>
        public void Sort(ref IQueryable<T> set, Dictionary<string, ListSortDirection> sorts)
        {
            foreach (var sort in sorts)
            {
                set = set.OrderBy(string.Format("{0} {1}", sort.Key, sort.Value.ToString()));
            }
        }

        /// <summary>
        /// Filters queryable set.
        /// </summary>
        /// <param name="set">Queryable set.</param>
        /// <param name="filters">Filters.</param>
        public void Filter(ref IQueryable<T> set, List<CustomFilter> filters)
        {
            foreach (var filter in filters)
            {
                string operatorString = "";
                if (filter.MemberType == typeof(string))
                {
                    operatorString = ".Contains(@0)";
                }
                else
                {
                    switch (filter.Operator)
                    {
                        case CustomOperator.Greater:
                            operatorString = " > @0";
                            break;
                        case CustomOperator.GreaterOrEqual:
                            operatorString = " >= @0";
                            break;
                        case CustomOperator.Less:
                            operatorString = " < @0";
                            break;
                        case CustomOperator.LessOrEqual:
                            operatorString = " <= @0";
                            break;
                    }
                }
                set = set.Where(filter.Member + operatorString, filter.Value);
            }
        }

        /// <summary>
        /// Adds a new instance to database.
        /// </summary>
        /// <param name="instance">New instance.</param>
        public virtual void Add(T instance)
        {
            this.entities.Set<T>().Add(instance);
        }

        /// <summary>
        /// Modifies existing instance.
        /// </summary>
        /// <param name="instance">Instance to modify.</param>
        public virtual void Modify(T instance)
        {
            this.entities.Entry(instance).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes existing instance.
        /// </summary>
        /// <param name="instance">Instance to delete.</param>
        public virtual void Delete(T instance)
        {
            this.entities.Set<T>().Remove(instance);
        }

        /// <summary>
        /// Deletes existing instance.
        /// </summary>
        /// <param name="id">Id of an instance to delete.</param>
        public virtual void Delete(int id)
        {
            T entity = this.FindById(id);
            this.entities.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Finds the first instance that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Found instance.</returns>
        public virtual T FirstOrDefault(Func<T, bool> filter)
        {
            return this.entities.Set<T>().Where(filter).FirstOrDefault();
        }

        /// <summary>
        /// Finds all instances that match the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Found instances.</returns>
        public virtual IEnumerable<T> FindBy(Func<T, bool> filter)
        {
            return this.entities.Set<T>().Where(filter);
        }

        /// <summary>
        /// Saves changes in the database.
        /// </summary>
        public virtual void SaveChanges()
        {
            this.entities.SaveChanges();
        }
    }
}