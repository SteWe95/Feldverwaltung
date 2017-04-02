using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class TaskDescriptionMap : ClassMap<TaskDescription>
    {
        public TaskDescriptionMap()
        {
            Table("TaskDescription");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(_ => _.FruitId).Column("FruitId");
            Map(_ => _.FertilizerId).Column("FertilizerId");
            Map(_ => _.JobNameId).Column("JobNameId");
            Map(x => x.Comment).Column("Comment");

            References(_ => _.Fruit, "FruitId").Cascade.None();
            References(_ => _.Fertilizer, "FertilizerId").Cascade.None();
            References(_ => _.JobName, "JobNameId").Cascade.None();
        }
    }
}
