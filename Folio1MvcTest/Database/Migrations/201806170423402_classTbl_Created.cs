namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classTbl_Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        LocationId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 15),
                        LastName = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Class_Id", c => c.Int());
            CreateIndex("dbo.Students", "Class_Id");
            AddForeignKey("dbo.Students", "Class_Id", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "LocationId", "dbo.Locations");
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropIndex("dbo.Classes", new[] { "LocationId" });
            DropColumn("dbo.Students", "Class_Id");
            DropTable("dbo.Teachers");
            DropTable("dbo.Classes");
        }
    }
}
