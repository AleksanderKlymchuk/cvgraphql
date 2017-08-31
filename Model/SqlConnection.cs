using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ISqlConnectionString
    {
       string ConnectionString { get; set; } 
    }
    public class CVConnection : ISqlConnectionString
    {
        public string ConnectionString { get; set; }
        
    }
}
