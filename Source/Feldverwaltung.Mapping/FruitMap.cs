using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class FruitMap : ClassMap<Fruit>
    {
        public FruitMap()
        {
            Table("Fruit");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.FruitName).Column("FruitName");

            //HasMany(_ => _.Fields).KeyColumn("FruitId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
            //HasMany(_ => _.TaskDescriptions).KeyColumn("JobId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
        }
    }
}
