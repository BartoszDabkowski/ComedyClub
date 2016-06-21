namespace ComedyClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateShowTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Comedian_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Comedian_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Comedian_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Shows", "Comedian_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            DropIndex("dbo.Shows", new[] { "Comedian_Id" });
            DropTable("dbo.Shows");
            DropTable("dbo.Genres");
        }
    }
}
