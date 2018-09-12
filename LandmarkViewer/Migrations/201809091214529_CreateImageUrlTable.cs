namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateImageUrlTable : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.LandmarkImages", "ImageUrl_Id");
            AddForeignKey("dbo.LandmarkImages", "ImageUrl_Id", "dbo.ImageUrls", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandmarkImages", "ImageUrl_Id", "dbo.ImageUrls");
            DropIndex("dbo.LandmarkImages", new[] { "ImageUrl_Id" });
            DropColumn("dbo.LandmarkImages", "ImageUrl_Id");
            DropTable("dbo.ImageUrls");
        }
    }
}
