namespace Kino.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedICollections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slots", "Film_ID1", "dbo.Films");
            DropForeignKey("dbo.Slots", "Film_ID2", "dbo.Films");
            DropIndex("dbo.Slots", new[] { "Film_ID1" });
            DropIndex("dbo.Slots", new[] { "Film_ID2" });
            DropColumn("dbo.Slots", "Film_ID1");
            DropColumn("dbo.Slots", "Film_ID2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Slots", "Film_ID2", c => c.Int());
            AddColumn("dbo.Slots", "Film_ID1", c => c.Int());
            CreateIndex("dbo.Slots", "Film_ID2");
            CreateIndex("dbo.Slots", "Film_ID1");
            AddForeignKey("dbo.Slots", "Film_ID2", "dbo.Films", "ID");
            AddForeignKey("dbo.Slots", "Film_ID1", "dbo.Films", "ID");
        }
    }
}
