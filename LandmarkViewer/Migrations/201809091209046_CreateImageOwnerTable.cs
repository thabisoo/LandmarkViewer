namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateImageOwnerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                        OwnerImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LandmarkImages", "Owner_Id", c => c.Int());
            CreateIndex("dbo.LandmarkImages", "Owner_Id");
            AddForeignKey("dbo.LandmarkImages", "Owner_Id", "dbo.ImageOwners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandmarkImages", "Owner_Id", "dbo.ImageOwners");
            DropIndex("dbo.LandmarkImages", new[] { "Owner_Id" });
            DropColumn("dbo.LandmarkImages", "Owner_Id");
            DropTable("dbo.ImageOwners");
        }
    }
}
