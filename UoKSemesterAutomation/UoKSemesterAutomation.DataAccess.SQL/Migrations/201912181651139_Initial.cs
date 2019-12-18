namespace UoKSemesterAutomation.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassTables",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClassName = c.String(),
                        Section = c.String(),
                        shift = c.String(),
                        DepartmentID = c.String(),
                        CreatesAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DepartmentName = c.String(),
                        CreatesAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Repeaters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(),
                        ClassTableId = c.String(),
                        TeacherId = c.String(),
                        Department = c.String(),
                        CreatesAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 40),
                        FatherName = c.String(maxLength: 40),
                        SemesterNo = c.Int(nullable: false),
                        Enrolment = c.String(),
                        RollNumber = c.String(),
                        Major = c.String(),
                        Section = c.String(),
                        Year = c.String(),
                        Department = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        Shift = c.String(),
                        IsRepeater = c.Boolean(nullable: false),
                        ClassTableId = c.String(),
                        RepeaterId = c.String(),
                        CreatesAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);



            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 40),
                        LastName = c.String(maxLength: 40),
                        Department = c.String(),
                        Contact = c.Int(nullable: false),
                        Email = c.String(),
                        Degree = c.String(),
                        IsChairPerson = c.Boolean(nullable: false),
                        Teacher_Abb = c.String(),
                        CreatesAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Repeaters");
            DropTable("dbo.Departments");
            DropTable("dbo.ClassTables");
        }
    }
}
