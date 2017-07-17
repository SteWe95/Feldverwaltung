using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class FertilizersMap : ClassMap<Fertilizers>
    {
        public FertilizersMap()
        {
            Table("Fertilizers");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.Name).Column("FertilizerName");

            HasMany(_ => _.Tasks).KeyColumn("Id").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
        }
    }
}
