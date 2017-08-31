using Model;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CVContext : DbContext, ICVContext
    {
        public CVContext(CVConnection connection) : base(connection.ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Person> Persons { get; set; }
    }
}
