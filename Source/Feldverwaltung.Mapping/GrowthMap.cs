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
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.GrowthState).Unique().Not.Nullable();

            //HasMany<Field>(_ => _.Fields).Inverse();
        }
    }
}
