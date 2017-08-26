using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Duration
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CompanyId { get; set; }
        public int PositionId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
