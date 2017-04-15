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

            HasMany(_ => _.Fields).KeyColumn("Id");
            HasMany(_ => _.TaskDescriptions).KeyColumn("Id");
        }
    }
}
