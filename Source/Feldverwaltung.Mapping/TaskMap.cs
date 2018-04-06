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
            LazyLoad();
            Id(x => x.Id)
                .Column("TaskId")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.HiLo("10");
            Map(x => x.Employee)
                .Column("Employee")
                .CustomType("String")
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR")
                .Length(50);
            Map(x => x.Active).Not.Nullable();
            Map(x => x.Done).Not.Nullable();

            References(_ => _.Field)
                .Class<Field>()
                .Access.Property()
                .Cascade.None()
                .LazyLoad()
                .Columns("FieldId");
            References(_ => _.TaskDescription)
                .Class<TaskDescription>()
                .Access.Property()
                .Cascade.None()
                .LazyLoad()
                .Columns("TaskdescriptionId");
            //            HasOne<Field>(_ => _.Field);
            //            HasOne<TaskDescription>(_ => _.TaskDescription);
        }
    }
}
