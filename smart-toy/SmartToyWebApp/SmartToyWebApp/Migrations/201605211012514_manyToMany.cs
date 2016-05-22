namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Actions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Games", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Stories", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ApplicationUserActions",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Action_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Action_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actions", t => t.Action_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Action_Id);
            
            CreateTable(
                "dbo.GameApplicationUsers",
                c => new
                    {
                        Game_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.StoryApplicationUsers",
                c => new
                    {
                        Story_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Story_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Stories", t => t.Story_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Story_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Actions", "ApplicationUser_Id");
            DropColumn("dbo.Games", "ApplicationUser_Id");
            DropColumn("dbo.Stories", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Games", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Actions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.StoryApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StoryApplicationUsers", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.GameApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GameApplicationUsers", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.ApplicationUserActions", "Action_Id", "dbo.Actions");
            DropForeignKey("dbo.ApplicationUserActions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StoryApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.StoryApplicationUsers", new[] { "Story_Id" });
            DropIndex("dbo.GameApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GameApplicationUsers", new[] { "Game_Id" });
            DropIndex("dbo.ApplicationUserActions", new[] { "Action_Id" });
            DropIndex("dbo.ApplicationUserActions", new[] { "ApplicationUser_Id" });
            DropTable("dbo.StoryApplicationUsers");
            DropTable("dbo.GameApplicationUsers");
            DropTable("dbo.ApplicationUserActions");
            CreateIndex("dbo.Stories", "ApplicationUser_Id");
            CreateIndex("dbo.Games", "ApplicationUser_Id");
            CreateIndex("dbo.Actions", "ApplicationUser_Id");
            AddForeignKey("dbo.Stories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Games", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Actions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
