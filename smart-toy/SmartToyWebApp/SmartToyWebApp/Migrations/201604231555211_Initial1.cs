namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Toys", name: "Owner_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.Toys", name: "IX_Owner_Id", newName: "IX_OwnerId");
            AddColumn("dbo.Toys", "Uid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Toys", "Uid");
            RenameIndex(table: "dbo.Toys", name: "IX_OwnerId", newName: "IX_Owner_Id");
            RenameColumn(table: "dbo.Toys", name: "OwnerId", newName: "Owner_Id");
        }
    }
}
