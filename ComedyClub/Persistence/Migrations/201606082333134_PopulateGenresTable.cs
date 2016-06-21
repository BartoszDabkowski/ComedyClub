namespace ComedyClub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO Genres (Id, Name) VALUES (1, 'Alternative')
                INSERT INTO Genres (Id, Name) VALUES (2, 'Blue')
                INSERT INTO Genres (Id, Name) VALUES (3, 'Dark')
                INSERT INTO Genres (Id, Name) VALUES (4, 'Musical')
                INSERT INTO Genres (Id, Name) VALUES (5, 'Observational')
                INSERT INTO Genres (Id, Name) VALUES (6, 'Satire')
                INSERT INTO Genres (Id, Name) VALUES (7, 'Sketch')
            ");
        }
        
        public override void Down()
        {
            Sql("REMOVE FROM Genres WHERE Id IN (1, 2, 3, 4, 5, 6, 7)");
        }
    }
}
