namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLandmarkImageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandmarkImages", "Title", c => c.String());
            AddColumn("dbo.LandmarkImages", "PathAlias", c => c.String());
            AddColumn("dbo.LandmarkImages", "Published", c => c.String());
            AddColumn("dbo.LandmarkImages", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LandmarkImages", "Views");
            DropColumn("dbo.LandmarkImages", "Published");
            DropColumn("dbo.LandmarkImages", "PathAlias");
            DropColumn("dbo.LandmarkImages", "Title");
        }
    }
}
