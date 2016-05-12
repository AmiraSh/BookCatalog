//-----------------------------------------------------------------------
// <copyright file="InitialCreate.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System.Data.Entity.Migrations;
    #endregion

    /// <summary>
    /// The initial migration.
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Creates the database tables that correspond to the data model entity sets.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        BooksCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        PagesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);            
        }

        /// <summary>
        /// Deletes the database tables that correspond to the data model entity sets.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.BookAuthor", "Author_Id", "dbo.Author");
            this.DropForeignKey("dbo.BookAuthor", "Book_Id", "dbo.Book");
            this.DropIndex("dbo.BookAuthor", new[] { "Author_Id" });
            this.DropIndex("dbo.BookAuthor", new[] { "Book_Id" });
            this.DropTable("dbo.BookAuthor");
            this.DropTable("dbo.Book");
            this.DropTable("dbo.Author");
        }
    }
}
