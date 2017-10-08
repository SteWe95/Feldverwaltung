using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FertilizerMap : ClassMap<Fertilizer>
    {
        public FertilizerMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.FertilizerLevel).Unique().Not.Nullable();

            //HasMany<Field>(_ => _.Fields).Inverse();
        }
    }
}
