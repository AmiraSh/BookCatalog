//-----------------------------------------------------------------------
// <copyright file="AddedRatingColumn.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System.Data.Entity.Migrations;
    #endregion

    /// <summary>
    /// Migration: 'added rating column'.
    /// </summary>
    public partial class AddedRatingColumn : DbMigration
    {
        /// <summary>
        /// Apply.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Book", "Rating", c => c.Int(nullable: false));
        }

        /// <summary>
        /// Revert.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("dbo.Book", "Rating");
        }
    }
}
