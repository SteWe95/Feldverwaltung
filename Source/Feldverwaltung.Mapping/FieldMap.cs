using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FieldMap : ClassMap<Field>
    {
        public FieldMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(_ => _.Number).Unique().Not.Nullable();
            Map(_ => _.Size);

            HasOne<Fruit>(_ => _.Fruit);
            //HasOne<Growth>(_ => _.GrowthState);
            //HasOne<Fertilizer>(_ => _.FertilizerLevel);
            //HasOne<Ploughed>(_ => _.PloughedState);
        }
    }
}