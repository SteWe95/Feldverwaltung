using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class PloughedMap : ClassMap<Ploughed>
    {
        public PloughedMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.PloughedState).Unique().Not.Nullable();

            //HasMany<Field>(_ => _.Fields).Inverse();
        }
    }
}
