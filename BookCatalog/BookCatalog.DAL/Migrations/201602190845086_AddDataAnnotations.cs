namespace BookCatalog.DAL.Migrations
{
    #region Using
    using System.Data.Entity.Migrations;
    #endregion

    /// <summary>
    /// Migration: 'add data annotations'.
    /// </summary>
    public partial class AddDataAnnotations : DbMigration
    {
        /// <summary>
        /// Apply.
        /// </summary>
        public override void Up()
        {
            this.AlterColumn("dbo.Author", "FirstName", c => c.String(nullable: false, maxLength: 150));
            this.AlterColumn("dbo.Author", "SecondName", c => c.String(nullable: false, maxLength: 150));
            this.AlterColumn("dbo.Book", "Name", c => c.String(nullable: false, maxLength: 150));
        }

        /// <summary>
        /// Revert.
        /// </summary>
        public override void Down()
        {
            this.AlterColumn("dbo.Book", "Name", c => c.String());
            this.AlterColumn("dbo.Author", "SecondName", c => c.String());
            this.AlterColumn("dbo.Author", "FirstName", c => c.String());
        }
    }
}
