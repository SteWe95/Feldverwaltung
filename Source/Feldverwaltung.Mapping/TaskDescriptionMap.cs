using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class TaskDescriptionMap : ClassMap<TaskDescription>
    {
        public TaskDescriptionMap()
        {
            Table("C6B6FF669A3865555C737D3414717618");
            Id(x => x.Id).Column("C6B6FF669A3865555C737D3414717619").GeneratedBy.Assigned();
            References(x => x.Fruit).Column("C6B6FF669A3865555C737D3414717620");
            References(x => x.JobName).Column("C6B6FF669A3865555C737D3414717621");
            Map(x => x.Comment).Column("C6B6FF669A3865555C737D3414717622");
        }
    }
}
