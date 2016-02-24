namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    #endregion

    /// <summary>
    /// Migration configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<BookCatalog.DAL.BookCatalogContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "BookCatalog.DAL.BookCatalogContext";
        }

        /// <summary>
        /// Invokes after migrating to the latest version.
        /// </summary>
        /// <param name="context">The database context object.</param>
        protected override void Seed(BookCatalog.DAL.BookCatalogContext context)
        {
        }
    }
}
