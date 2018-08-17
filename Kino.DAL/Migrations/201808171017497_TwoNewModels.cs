namespace Kino.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Film_ID = c.Int(),
                        User_ID = c.Int(),
                        Film_ID1 = c.Int(),
                        Film_ID2 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Films", t => t.Film_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Films", t => t.Film_ID1)
                .ForeignKey("dbo.Films", t => t.Film_ID2)
                .Index(t => t.Film_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Film_ID1)
                .Index(t => t.Film_ID2);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Films", "TimeOfStartFilm", c => c.String());
            AddColumn("dbo.Films", "DateOfFilm", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "Film_ID2", "dbo.Films");
            DropForeignKey("dbo.Slots", "Film_ID1", "dbo.Films");
            DropForeignKey("dbo.Slots", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Slots", "Film_ID", "dbo.Films");
            DropIndex("dbo.Slots", new[] { "Film_ID2" });
            DropIndex("dbo.Slots", new[] { "Film_ID1" });
            DropIndex("dbo.Slots", new[] { "User_ID" });
            DropIndex("dbo.Slots", new[] { "Film_ID" });
            DropColumn("dbo.Films", "DateOfFilm");
            DropColumn("dbo.Films", "TimeOfStartFilm");
            DropTable("dbo.Users");
            DropTable("dbo.Slots");
        }
    }
}
