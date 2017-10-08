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
            Id(x => x.Id).GeneratedBy.HiLo("10");
            Map(x => x.Employee);
            Map(x => x.Active).Not.Nullable();
            Map(x => x.Done).Not.Nullable();

            HasOne<Field>(_ => _.Field);
            HasOne<TaskDescription>(_ => _.TaskDescription);
        }
    }
}
