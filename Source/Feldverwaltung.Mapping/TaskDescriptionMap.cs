using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class TaskDescriptionMap : ClassMap<TaskDescription>
    {
        public TaskDescriptionMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.Comment);

            HasOne<Fruit>(_ => _.Fruit);
            HasOne<Fertilizers>(_ => _.Fertilizer);
            HasOne<Job>(_ => _.Job);

        }
    }
}
