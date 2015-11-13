namespace DinnersOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(),
                        CourseId = c.Int(),
                        LocationId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.ClassId)
                .Index(t => t.CourseId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50, unicode: false),
                        JoinDate = c.DateTime(),
                        StatusInd = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassCourse", "LocationId", "dbo.Location");
            DropForeignKey("dbo.ClassCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.ClassCourse", "ClassId", "dbo.Class");
            DropIndex("dbo.ClassCourse", new[] { "LocationId" });
            DropIndex("dbo.ClassCourse", new[] { "CourseId" });
            DropIndex("dbo.ClassCourse", new[] { "ClassId" });
            DropTable("dbo.Users");
            DropTable("dbo.Location");
            DropTable("dbo.Course");
            DropTable("dbo.Class");
            DropTable("dbo.ClassCourse");
        }
    }
}
