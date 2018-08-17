namespace Kino.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slots", "Film_ID", "dbo.Films");
            DropIndex("dbo.Slots", new[] { "Film_ID" });
            AddColumn("dbo.Films", "Tytul", c => c.String());
            DropColumn("dbo.Films", "Title");
            DropColumn("dbo.Films", "TimeOfStartFilm");
            DropTable("dbo.Slots");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Film_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Films", "TimeOfStartFilm", c => c.String());
            AddColumn("dbo.Films", "Title", c => c.String());
            DropColumn("dbo.Films", "Tytul");
            CreateIndex("dbo.Slots", "Film_ID");
            AddForeignKey("dbo.Slots", "Film_ID", "dbo.Films", "ID");
        }
    }
}
