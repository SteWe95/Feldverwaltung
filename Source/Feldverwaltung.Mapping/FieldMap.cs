using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Mapping
{
    public class FieldMap : ClassMap<Field>
    {
        public FieldMap()
        {
            Table("C6B6FF669A3865555C737D3414717604");
            Id(x => x.Number).Column("C6B6FF669A3865555C737D3414717605");
            Map(x => x.Fruit).Column("C6B6FF669A3865555C737D3414717606");
            Map(x => x.GrowthState).Column("C6B6FF669A3865555C737D3414717607");
            Map(x => x.Size).Column("C6B6FF669A3865555C737D3414717608");
            Map(x => x.FertilizerLevel).Column("C6B6FF669A3865555C737D3414717609");
            Map(x => x.Ploughed).Column("C6B6FF669A3865555C737D3414717610");
        }
    }
}
