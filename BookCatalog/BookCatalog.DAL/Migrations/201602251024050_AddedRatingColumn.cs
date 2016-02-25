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
            AddColumn("dbo.Book", "Rating", c => c.Int(nullable: false));
        }

        /// <summary>
        /// Revert.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Book", "Rating");
        }
    }
}
