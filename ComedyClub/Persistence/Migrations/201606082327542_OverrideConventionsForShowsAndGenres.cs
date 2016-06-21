namespace ComedyClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForShowsAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "Comedian_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Shows", new[] { "Comedian_Id" });
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shows", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shows", "Comedian_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Shows", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Shows", "Comedian_Id");
            CreateIndex("dbo.Shows", "Genre_Id");
            AddForeignKey("dbo.Shows", "Comedian_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Shows", "Comedian_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            DropIndex("dbo.Shows", new[] { "Comedian_Id" });
            AlterColumn("dbo.Shows", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Shows", "Comedian_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Shows", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Shows", "Genre_Id");
            CreateIndex("dbo.Shows", "Comedian_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Shows", "Comedian_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
