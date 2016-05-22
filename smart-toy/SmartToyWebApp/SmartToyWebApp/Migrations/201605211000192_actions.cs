namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Commands = c.String(),
                        Cost = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        StoryAudioFileUrl = c.String(),
                        Cost = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Games", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Toys", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Toys", "Volume", c => c.Int(nullable: false));
            AddColumn("dbo.Toys", "NightMode", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Money", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "ApplicationUser_Id");
            AddForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Actions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Games", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Actions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Money");
            DropColumn("dbo.Toys", "NightMode");
            DropColumn("dbo.Toys", "Volume");
            DropColumn("dbo.Toys", "Age");
            DropColumn("dbo.Games", "ApplicationUser_Id");
            DropTable("dbo.Stories");
            DropTable("dbo.Actions");
        }
    }
}
