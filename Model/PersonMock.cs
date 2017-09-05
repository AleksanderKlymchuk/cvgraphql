using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class PersonMock
    {
        public static List<Person> Persons()
        {
            return new List<Person>() {
                 new Person()
                 {
                     ID = 1,
                     FirstName = "Oleksandr",
                     LastName = "Klymchuk",
                     Age = 32,
                     Educations = Educations(),
                     PersonSkills = PersonSkills(),
                     //Companies=Companies(),
                     Projects = Projects()
              }


         };
        }
        public static List<Company> Companies()
        {

            return new List<Company>() {
                    new Company() {Id=1, Name="Procore",Positions=new List<Position>() {
                        new Position() { Id=1,Title="Web Developer",Duration=new Duration() { Start=new DateTime(2014,1,1), End=new DateTime(2015,1,1) },
                        Description="Hos ProCore har jeg arbejdet med ProTravel projekt, hvor jeg primært udviklet applikation funktionalitet i både frontend og backend. Inden for projektet har jeg arbejdet med ASP .NET  MVC 5, Web API 2, Telerik Data Access, Kendo UI og jQuery teknologier."
                        }
                    } },
                    new Company() { Id=2, Name="Hella Gutmann Solutions A/S",Positions=new List<Position>() {
                        new Position() {Id=2,Title="Backend Deveoper",Duration=new Duration() { Start=new DateTime(2015,1,1) },
                        Description=" Hos Hella Gutmann Solutions arbejder jeg i øjeblikket med opbygning af nye løsninger, samt vedligeholdelse og videreudvikling af eksisterende løsninger"
                        }

                    } }
                };

        }
        public static List<Project> Projects()
        {


            return new List<Project>() {
                    new Project() {ID=1,Name="Protravel"},
                    new Project() {ID=1,Name="Harley davidson integration"},
                    new Project() { ID=2,Name="TWM"},
                    new Project() { ID=3,Name="BTS"},
                    new Project() { ID=4,Name="TDW"},
                    new Project() { ID=5,Name="MyWorkshop"},
                    new Project() { ID=6,Name="IdP"},
                    new Project() { ID=7,Name="Context Server"},
                    new Project() { ID=8,Name="Data Converting Tool"},
                    new Project() { ID=9,Name="Car People"}
                };

        }
        public static List<PersonSkill> PersonSkills()
        {
            return new List<PersonSkill>() {

                           new PersonSkill() {  Skill=new Skill() { Name="C#" },Level="Expert" },
                           new PersonSkill() {  Skill=new Skill() { Name="SQL" },Level="Expert" },
                           new PersonSkill() {  Skill=new Skill() { Name="ASP.NET Core,  ASP.NET MVC5, Web API 2" },Level="Expert" },
                           new PersonSkill() {  Skill=new Skill() { Name="SOLID" },Level="Expert" },
                           new PersonSkill() {  Skill=new Skill() { Name="Dapper" },Level="Very experienced" },
                };


        }

        public static List<Education> Educations()
        {

            return new List<Education>() {
                                          new Education() { Id=1, InstitutionName="Aarhus Business Academy",
                                              Title ="AP Graduate in IT Technology Network engineering",
                                              Specialization="Advanced Virtualisation,Certification and Cloud Computing",
                                              Start=new DateTime(2012,1,1),
                                              End=new DateTime(2014,1,1)

                                          },
                                          new Education() { Id=2, InstitutionName="Aarhus Business Academy",
                                              Title ="Bachelor og Web Development",
                                              Specialization="Web developer",
                                              Start=new DateTime(2014,1,1),
                                              End=new DateTime(2015,5,1)

                                          },
                                          new Education() { Id=3, InstitutionName="Aarhus Business Academy",
                                              Title ="Single subject",
                                              Specialization="Web programming and network backend",
                                              Start=new DateTime(2015,1,1),
                                              End=new DateTime(2015,5,1)
                                          },
                     };
        }

    }
}
