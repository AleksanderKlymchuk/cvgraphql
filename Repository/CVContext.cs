using Model;
using System.Data.Entity;

namespace Repository
{
    public class CVContext : DbContext, ICVContext
    {
        public CVContext():base(@"data source = (LocalDb)\MSSQLLocalDB; initial catalog = CV; integrated security = True;")
        {

        }
        
        public virtual DbSet<Person> Persons { get; set; }
    }

   
}
