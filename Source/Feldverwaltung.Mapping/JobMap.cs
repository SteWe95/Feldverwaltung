using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class JobMap : ClassMap<Job>
    {
        public JobMap()
        {
            Table("Job");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.Name).Column("JobName");

            HasMany(_ => _.Tasks).KeyColumn("Id");
        }
    }
}
