namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Logitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LandmarkImages", "Location_Id", c => c.Int());
            CreateIndex("dbo.LandmarkImages", "Location_Id");
            AddForeignKey("dbo.LandmarkImages", "Location_Id", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandmarkImages", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LandmarkImages", new[] { "Location_Id" });
            DropColumn("dbo.LandmarkImages", "Location_Id");
            DropTable("dbo.Locations");
        }
    }
}
