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
            Map(_ => _.FruitId).Column("FruitId");
            Map(_ => _.GrowthId).Column("GrowthStateId");
            Map(_ => _.Size).Column("Size");
            Map(_ => _.FertilizerLevelId).Column("FertilizerLevelId");
            Map(_ => _.PloughedStateId).Column("PloughedStateId");

            References(_ => _.Fruit, "FruitId").Cascade.None();
            References(_ => _.GrowthState, "GrowthStateId").Cascade.None();
            References(_ => _.FertilizerLevel, "FertilizerLevelId").Cascade.None();
            References(_ => _.PloughedState, "PloughedStateId").Cascade.None();
        }
    }
}