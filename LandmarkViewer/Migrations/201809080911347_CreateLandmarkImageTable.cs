namespace LandmarkViewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLandmarkImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LandmarkImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LandmarkImages");
        }
    }
}
