using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class PloughedMap : ClassMap<Ploughed>
    {
        public PloughedMap()
        {
            Table("Ploughed");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.PloughedState).Column("PloughedState");

            HasMany(_ => _.Fields).KeyColumn("PloughedStateId").Cascade.AllDeleteOrphan().Inverse().Fetch.Join().AsSet();
        }
    }
}
