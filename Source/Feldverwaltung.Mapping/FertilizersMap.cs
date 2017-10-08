using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FertilizersMap : ClassMap<Fertilizers>
    {
        public FertilizersMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.Name).Unique().Not.Nullable();

            HasMany<Task>(_ => _.Tasks).Inverse();
        }
    }
}
