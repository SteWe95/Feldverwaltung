using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FieldMap : ClassMap<Field>
    {
        public FieldMap()
        {
            Table("Field");
            Id(x => x.Number).Column("FieldNumber");
            Map(_ => _.Size).Column("Size");

            References(_ => _.Fruit).Column("FruitId").Cascade.All();
            References(_ => _.GrowthState).Column("GrowthStateId").Cascade.All();
            References(_ => _.FertilizerLevel).Column("FertilizerLevelId").Cascade.All();
            References(_ => _.PloughedState).Column("PloughedStateId").Cascade.All();
        }
    }
}