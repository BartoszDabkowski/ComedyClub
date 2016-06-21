namespace ComedyClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToShow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shows", "IsCanceled");
        }
    }
}
