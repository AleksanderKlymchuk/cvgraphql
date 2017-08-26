using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGraphQL.GraphQL
{
    public class PositionType:ObjectGraphType<Position>
    {
        public PositionType()
        {
            Field(x => x.Id).Description("Id");
            Field(x => x.Title).Description("Position Title");
            Field<DurationType>("duration","Position Duration");
            Field(x => x.Description).Description("Positi<on Description");
        }
    }
}
