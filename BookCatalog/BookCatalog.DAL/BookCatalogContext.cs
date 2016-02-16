namespace BookCatalog.DAL
{
    #region Using
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Book catalog context.
    /// </summary>
    public class BookCatalogContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookCatalogContext"/> class.
        /// </summary>
        public BookCatalogContext() : base("BookCatalogContext")
        {
        }

        /// <summary>
        /// Gets or sets books' set.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets authors' set.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Invokes when model created.
        /// </summary>
        /// <param name="modelBuilder">database model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}