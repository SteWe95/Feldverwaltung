using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class GrowthMap : ClassMap<Growth>
    {
        public GrowthMap()
        {
            Table("Growth");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.GrowthState).Column("GrowthState");

            HasMany(_ => _.Fields).KeyColumn("Id");
        }
    }
}
