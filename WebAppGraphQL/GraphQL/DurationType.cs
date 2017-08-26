using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class DurationType : ObjectGraphType<Duration>
    {
        public DurationType()
        {
            Name = "duration";
            Field(x => x.End).Description("End");
            Field(x => x.Start).Description("Start");

        }
    }

}
