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
            Map(_ => _.FruitId).Column("FruitId");
            Map(_ => _.GrowthStateId).Column("GrowthStateId");
            Map(_ => _.FertilizerLevelId).Column("FertilizerLevelId");
            Map(_ => _.PloughedStateId).Column("PloughedStateId");

            //References(_ => _.Fruit).Column("FruitId").ReadOnly();
            //References(_ => _.GrowthState).Column("GrowthStateId").ReadOnly();
            //References(_ => _.FertilizerLevel).Column("FertilizerLevelId").ReadOnly();
            //References(_ => _.PloughedState).Column("PloughedStateId").ReadOnly();
        }
    }
}