namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actions1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actions", "Type");
        }
    }
}
