namespace BookCatalog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropBooksCoutColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Author", "BooksCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author", "BooksCount", c => c.Int(nullable: false));
        }
    }
}
