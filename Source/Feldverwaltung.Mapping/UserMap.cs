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
            Table("C6B6FF669A3865555C737D3414717600");
            Id(x => x.Username).Column("C6B6FF669A3865555C737D3414717601");
            Map(x => x.Password).Column("C6B6FF669A3865555C737D3414717602");
            Map(x => x.Position).Column("C6B6FF669A3865555C737D3414717603");
        }
    }
}
