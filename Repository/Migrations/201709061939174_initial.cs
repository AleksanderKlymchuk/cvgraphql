namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        InstitutionName = c.String(),
                        Specialization = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EducationPersons",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.Person_ID })
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_ID, cascadeDelete: true)
                .Index(t => t.Education_Id)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.ProjectPersons",
                c => new
                    {
                        Project_ID = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ID, t.Person_ID })
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectPersons", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.ProjectPersons", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.PersonSkills", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.PersonSkills", "PersonID", "dbo.Person");
            DropForeignKey("dbo.EducationPersons", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.EducationPersons", "Education_Id", "dbo.Educations");
            DropIndex("dbo.ProjectPersons", new[] { "Person_ID" });
            DropIndex("dbo.ProjectPersons", new[] { "Project_ID" });
            DropIndex("dbo.EducationPersons", new[] { "Person_ID" });
            DropIndex("dbo.EducationPersons", new[] { "Education_Id" });
            DropIndex("dbo.PersonSkills", new[] { "SkillID" });
            DropIndex("dbo.PersonSkills", new[] { "PersonID" });
            DropTable("dbo.ProjectPersons");
            DropTable("dbo.EducationPersons");
            DropTable("dbo.Projects");
            DropTable("dbo.Skills");
            DropTable("dbo.PersonSkills");
            DropTable("dbo.Educations");
            DropTable("dbo.Person");
        }
    }
}
