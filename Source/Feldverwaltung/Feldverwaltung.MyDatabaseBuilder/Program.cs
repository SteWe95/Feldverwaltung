using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.MyDatabaseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey("db")))
                .Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssembly(Assembly.Get);
                    });
        }
    }
}
