namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlProterty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LandmarkImages", "ImageUrl_Id", "dbo.ImageUrls");
            DropIndex("dbo.LandmarkImages", new[] { "ImageUrl_Id" });
            AddColumn("dbo.LandmarkImages", "MediumImageUrl", c => c.String());
            DropColumn("dbo.LandmarkImages", "ImageUrl_Id");
            DropTable("dbo.ImageUrls");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SmallImageUrl = c.String(),
                        MediumImageUrl = c.String(),
                        LargeImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LandmarkImages", "ImageUrl_Id", c => c.Int());
            DropColumn("dbo.LandmarkImages", "MediumImageUrl");
            CreateIndex("dbo.LandmarkImages", "ImageUrl_Id");
            AddForeignKey("dbo.LandmarkImages", "ImageUrl_Id", "dbo.ImageUrls", "Id");
        }
    }
}
