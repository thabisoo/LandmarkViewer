namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLocations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Latitude", c => c.String());
            AlterColumn("dbo.Locations", "Logitude", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Logitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Latitude", c => c.Double(nullable: false));
        }
    }
}
