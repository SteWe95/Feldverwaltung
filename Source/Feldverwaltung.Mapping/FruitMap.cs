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
            Id(x => x.Id).GeneratedBy.HiLo("5");
            Map(x => x.FruitName).Unique().Not.Nullable();

<<<<<<< HEAD
            //HasMany(_ => _.Fields).KeyColumn("FruitId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
            //HasMany(_ => _.TaskDescriptions).KeyColumn("JobId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
=======
            HasMany<Field>(_ => _.Fields).Inverse();
            HasMany<TaskDescription>(_ => _.TaskDescriptions).Inverse();
>>>>>>> origin/develop
        }
    }
}
