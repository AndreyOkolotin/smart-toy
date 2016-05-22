namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class songsRelationshipFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Song_Id", "dbo.Songs");
            DropIndex("dbo.AspNetUsers", new[] { "Song_Id" });
            CreateTable(
                "dbo.SongApplicationUsers",
                c => new
                    {
                        Song_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Song_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Song_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.AspNetUsers", "Song_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Song_Id", c => c.Guid());
            DropForeignKey("dbo.SongApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SongApplicationUsers", "Song_Id", "dbo.Songs");
            DropIndex("dbo.SongApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SongApplicationUsers", new[] { "Song_Id" });
            DropTable("dbo.SongApplicationUsers");
            CreateIndex("dbo.AspNetUsers", "Song_Id");
            AddForeignKey("dbo.AspNetUsers", "Song_Id", "dbo.Songs", "Id");
        }
    }
}
