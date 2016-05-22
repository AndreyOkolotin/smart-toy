namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class songs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        SongAudioFileUrl = c.String(),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Song_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "Song_Id");
            AddForeignKey("dbo.AspNetUsers", "Song_Id", "dbo.Songs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Song_Id", "dbo.Songs");
            DropIndex("dbo.AspNetUsers", new[] { "Song_Id" });
            DropColumn("dbo.AspNetUsers", "Song_Id");
            DropTable("dbo.Songs");
        }
    }
}
