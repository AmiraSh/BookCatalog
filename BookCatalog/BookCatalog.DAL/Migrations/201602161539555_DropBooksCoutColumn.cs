//-----------------------------------------------------------------------
// <copyright file="DropBooksCoutColumn.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System.Data.Entity.Migrations;
    #endregion

    /// <summary>
    /// Migration: 'dropped books count column'.
    /// </summary>
    public partial class DropBooksCoutColumn : DbMigration
    {
        /// <summary>
        /// Apply.
        /// </summary>
        public override void Up()
        {
            this.DropColumn("dbo.Author", "BooksCount");
        }

        /// <summary>
        /// Revert.
        /// </summary>
        public override void Down()
        {
            this.AddColumn("dbo.Author", "BooksCount", c => c.Int(nullable: false));
        }
    }
}
