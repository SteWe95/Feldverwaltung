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
            Table("Employee");
            Id(_ => _.Id).Column("Id");
            Map(_ => _.Username).Column("UserName");
            Map(_ => _.Password).Column("Password");
            Map(_ => _.PositionId).Column("PositionId");

            References(_ => _.Position, "PositionId").Cascade.None();
        }
    }
}
