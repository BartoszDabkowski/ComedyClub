namespace ComedyClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToShow : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shows", name: "Comedian_Id", newName: "ComedianId");
            RenameColumn(table: "dbo.Shows", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Shows", name: "IX_Comedian_Id", newName: "IX_ComedianId");
            RenameIndex(table: "dbo.Shows", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shows", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Shows", name: "IX_ComedianId", newName: "IX_Comedian_Id");
            RenameColumn(table: "dbo.Shows", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Shows", name: "ComedianId", newName: "Comedian_Id");
        }
    }
}
