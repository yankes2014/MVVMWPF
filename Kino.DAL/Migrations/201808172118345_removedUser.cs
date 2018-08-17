namespace Kino.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slots", "User_ID", "dbo.Users");
            DropIndex("dbo.Slots", new[] { "User_ID" });
            AddColumn("dbo.Slots", "IsFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Slots", "Username", c => c.String());
            DropColumn("dbo.Slots", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Slots", "User_ID", c => c.Int());
            DropColumn("dbo.Slots", "Username");
            DropColumn("dbo.Slots", "IsFree");
            CreateIndex("dbo.Slots", "User_ID");
            AddForeignKey("dbo.Slots", "User_ID", "dbo.Users", "ID");
        }
    }
}
