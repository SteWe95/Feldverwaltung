using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Table("Position");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.PositionName).Column("PositionName");

            //HasMany(_ => _.Users).KeyColumn("UserId").Inverse().Cascade.All();
        }
    }
}
