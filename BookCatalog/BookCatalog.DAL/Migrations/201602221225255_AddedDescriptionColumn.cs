namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System.Data.Entity.Migrations;
    #endregion

    /// <summary>
    /// Migration: 'added description column'.
    /// </summary>
    public partial class AddedDescriptionColumn : DbMigration
    {
        /// <summary>
        /// Apply.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Book", "Description", c => c.String());
        }
        
        /// <summary>
        /// Revert.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("dbo.Book", "Description");
        }
    }
}
