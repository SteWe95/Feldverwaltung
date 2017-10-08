using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FruitMap : ClassMap<Fruit>
    {
        public FruitMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("5");
            Map(x => x.FruitName).Unique().Not.Nullable();

            HasMany<Field>(_ => _.Fields).Inverse();
            //HasMany<TaskDescription>(_ => _.TaskDescriptions).Inverse();
        }
    }
}
