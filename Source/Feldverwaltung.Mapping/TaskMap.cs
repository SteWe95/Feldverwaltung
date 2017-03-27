using FluentNHibernate.Mapping;
using Feldverwaltung.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class TaskMap : ClassMap<global::Feldverwaltung.Domain.Task>
    {
        public TaskMap()
        {
            Table("C6B6FF669A3865555C737D3414717611");
            Id(x => x.Id).Column("C6B6FF669A3865555C737D3414717612").GeneratedBy.Assigned();
            References(x => x.Field).Column("C6B6FF669A3865555C737D3414717613");
            References(x => x.TaskDescription).Column("C6B6FF669A3865555C737D3414717614");
            Map(x => x.Employee).Column("C6B6FF669A3865555C737D3414717615");
            Map(x => x.Active).Column("C6B6FF669A3865555C737D3414717616");
            Map(x => x.Done).Column("C6B6FF669A3865555C737D3414717617");
        }
    }
}
