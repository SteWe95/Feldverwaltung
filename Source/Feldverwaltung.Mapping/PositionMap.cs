using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        { 
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.PositionName).Not.Nullable();

            HasMany<User>(_ => _.Users).Inverse();
            HasMany<TaskDescription>(_ => _.TaskDescriptions).Inverse();
        }
    }
}
