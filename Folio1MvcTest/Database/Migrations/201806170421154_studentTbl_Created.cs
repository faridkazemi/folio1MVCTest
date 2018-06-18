namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentTbl_Created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 15),
                        LastName = c.String(maxLength: 15),
                        Age = c.Int(nullable: false),
                        GPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
