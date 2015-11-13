namespace DinnersOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ClassCourse", "LocationId", c => c.Int());
            CreateIndex("dbo.ClassCourse", "LocationId");
            AddForeignKey("dbo.ClassCourse", "LocationId", "dbo.Location", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassCourse", "LocationId", "dbo.Location");
            DropIndex("dbo.ClassCourse", new[] { "LocationId" });
            DropColumn("dbo.ClassCourse", "LocationId");
            DropTable("dbo.Location");
        }
    }
}
