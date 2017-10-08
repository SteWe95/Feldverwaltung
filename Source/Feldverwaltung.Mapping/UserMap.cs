using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(_ => _.Id).GeneratedBy.HiLo("10");
            Map(_ => _.Username).Unique().Not.Nullable();
            Map(_ => _.Password).Unique().Not.Nullable();

            HasOne<Position>(_ => _.Position);
        }
    }
}
