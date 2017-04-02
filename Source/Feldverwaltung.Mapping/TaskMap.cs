using FluentNHibernate.Mapping;
using Feldverwaltung.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feldverwaltung.Mapping
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Task");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.Employee).Column("Employee");
            Map(x => x.Active).Column("Active");
            Map(x => x.Done).Column("Done");
            Map(_ => _.FieldId).Column("FieldId");
            Map(_ => _.TaskDescriptionId).Column("TaskDescriptionId");

            References(_ => _.Field, "FieldId").Cascade.None();
            References(_ => _.TaskDescription, "TaskDescriptionId").Cascade.None();
        }
    }
}
