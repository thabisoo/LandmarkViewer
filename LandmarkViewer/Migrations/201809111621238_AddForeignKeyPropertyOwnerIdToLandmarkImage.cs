namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertyOwnerIdToLandmarkImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LandmarkImages", "Owner_Id", "dbo.ImageOwners");
            DropIndex("dbo.LandmarkImages", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.LandmarkImages", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.LandmarkImages", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.LandmarkImages", "OwnerId");
            AddForeignKey("dbo.LandmarkImages", "OwnerId", "dbo.ImageOwners", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandmarkImages", "OwnerId", "dbo.ImageOwners");
            DropIndex("dbo.LandmarkImages", new[] { "OwnerId" });
            AlterColumn("dbo.LandmarkImages", "OwnerId", c => c.Int());
            RenameColumn(table: "dbo.LandmarkImages", name: "OwnerId", newName: "Owner_Id");
            CreateIndex("dbo.LandmarkImages", "Owner_Id");
            AddForeignKey("dbo.LandmarkImages", "Owner_Id", "dbo.ImageOwners", "Id");
        }
    }
}
