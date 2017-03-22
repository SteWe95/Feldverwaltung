using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.DatabaseBuilder
{
    public abstract class ReadOnlyClassMap<T> : ClassMap<T>, IReadOnlyClassMap
    {
        public ReadOnlyClassMap()
        {
            SchemaAction.None();
            ReadOnly();
        }

        public abstract string GetCreateScriptForSqlServer();

        public abstract string GetDropScriptForSqlServer();

    }
}
