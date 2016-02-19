namespace BookCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Author", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Author", "SecondName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Book", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "Name", c => c.String());
            AlterColumn("dbo.Author", "SecondName", c => c.String());
            AlterColumn("dbo.Author", "FirstName", c => c.String());
        }
    }
}
