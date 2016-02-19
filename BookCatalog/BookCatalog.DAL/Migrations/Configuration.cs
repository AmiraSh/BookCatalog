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
            //var authors = new List<Author>
            //{
            //    new Author { FirstName = "Andy", SecondName = "Weir" },
            //    new Author { FirstName = "Jacob", SecondName = "Grimm" },
            //    new Author { FirstName = "Wilhelm", SecondName = "Grimm" },
            //    new Author { FirstName = "J. K.", SecondName = "Rowling" }
            //};
            //authors.ForEach(author => context.Authors.AddOrUpdate(author));
            //context.SaveChanges();

            //var books = new List<Book>
            //{
            //    new Book { Name = "The Martian", PublishedDate = new DateTime(2014, 02, 11), PagesCount = 369, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Weir") } },
            //    new Book { Name = "Rapunzel", PublishedDate = new DateTime(1812, 03, 15), PagesCount = 87, Authors = new HashSet<Author>(authors.Where(author => author.SecondName == "Grimm").ToList()) },
            //    new Book { Name = "Hansel and Gretel", PublishedDate = new DateTime(1996, 07, 04), PagesCount = 48, Authors = new HashSet<Author>(authors.Where(author => author.SecondName == "Grimm").ToList()) },
            //    new Book { Name = "Harry Potter and the Philosopher's Stone", PublishedDate = new DateTime(1997, 06, 26), PagesCount = 309, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Chamber of Secrets", PublishedDate = new DateTime(1998, 06, 26), PagesCount = 341, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Prisoner of Azkaban", PublishedDate = new DateTime(1999, 06, 08), PagesCount = 435, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Goblet of Fire", PublishedDate = new DateTime(2000, 06, 26), PagesCount = 734, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Order of the Phoenix", PublishedDate = new DateTime(2003, 06, 26), PagesCount = 870, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Half-Blood Prince", PublishedDate = new DateTime(2005, 06, 26), PagesCount = 652, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } },
            //    new Book { Name = "Harry Potter and the Deathly Hallows", PublishedDate = new DateTime(2007, 06, 26), PagesCount = 759, Authors = new HashSet<Author> { authors.FirstOrDefault(author => author.SecondName == "Rowling") } }
            //};
            //books.ForEach(book => context.Books.AddOrUpdate(book));
            //context.SaveChanges();
        }
    }
}
