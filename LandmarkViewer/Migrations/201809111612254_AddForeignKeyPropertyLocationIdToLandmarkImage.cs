namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertyLocationIdToLandmarkImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LandmarkImages", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LandmarkImages", new[] { "Location_Id" });
            RenameColumn(table: "dbo.LandmarkImages", name: "Location_Id", newName: "LocationId");
            AlterColumn("dbo.LandmarkImages", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.LandmarkImages", "LocationId");
            AddForeignKey("dbo.LandmarkImages", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandmarkImages", "LocationId", "dbo.Locations");
            DropIndex("dbo.LandmarkImages", new[] { "LocationId" });
            AlterColumn("dbo.LandmarkImages", "LocationId", c => c.Int());
            RenameColumn(table: "dbo.LandmarkImages", name: "LocationId", newName: "Location_Id");
            CreateIndex("dbo.LandmarkImages", "Location_Id");
            AddForeignKey("dbo.LandmarkImages", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
