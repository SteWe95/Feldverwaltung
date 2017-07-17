using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class FertilizerMap : ClassMap<Fertilizer>
    {
        public FertilizerMap()
        {
            Table("Fertilizer");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.FertilizerLevel).Column("FertilizerLevel");

            HasMany(_ => _.Fields).KeyColumn("FertilizerLevelId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
        }
    }
}
