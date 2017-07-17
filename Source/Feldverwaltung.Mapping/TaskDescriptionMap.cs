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
            Map(x => x.Comment).Column("Comment");

            //References(_ => _.Fruit, "FruitId").Cascade.All();
            //References(_ => _.Fertilizer, "FertilizerId").Cascade.All();
            //References(_ => _.JobName, "JobNameId").Cascade.All();
        }
    }
}
