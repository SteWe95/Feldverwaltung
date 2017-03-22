using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Dialect;
using NHibernate.Engine;

namespace Feldverwaltung.DatabaseBuilder
{
    public class ReadOnlyMappingExtension : IAuxiliaryDatabaseObject
    {
        private IList<Assembly> _assemblyList;
        public ReadOnlyMappingExtension(IList<Assembly> assemblyList)
        {
            _assemblyList = assemblyList;
        }

        public bool AppliesToDialect(Dialect dialect)
        {
            if(dialect is NHibernate.Dialect.MsSql2005Dialect)
            {
                return true;
            }else if(dialect is NHibernate.Dialect.Oracle10gDialect)
            {
                return true;
            }else
            {
                Console.WriteLine("Unsupported dialect for additional script execution");
                return false;
            }
        }

        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            
        }

        public void AddDialectScope(String dialectScope)
        {
            
        }

        public string SqlCreateString(Dialect dialect, IMapping p, string defaultCatalog, string defaultSchema)
        {
            if (dialect is NHibernate.Dialect.MsSql2005Dialect | dialect is NHibernate.Dialect.MsSql2008Dialect)
            {
                dynamic SqlString = GetCreateStatementsForSqlServer();
                return SqlString + System.Environment.NewLine + SqlCreateStringForBasicFunctions();
            }
            else
            {
                return null;
            }
        }

        public string SqlDropString(Dialect dialect, string defaultCatalog, string defaultSchema)
        {
            if (dialect is NHibernate.Dialect.MsSql2005Dialect | dialect is NHibernate.Dialect.MsSql2008Dialect)
            {
                dynamic SqlString = GetDropStatementsForSqlServer();
                return SqlString + System.Environment.NewLine + SqlDropStringForBasicFunctions();
            }
            else
            {
                return null;
            }
        }
        private String GetCreateStatementsForSqlServer()
        {
            var ReadOnlyMappings = GetReadOnlyMappingsFromAssemblies();
            var ResultString = String.Empty;
            foreach(var type in ReadOnlyMappings)
            {
                var Mapping = (IReadOnlyClassMap)Activator.CreateInstance(type);
                ResultString = ResultString + Mapping.GetCreateScriptForSqlServer() + System.Environment.NewLine;
            }
            return ResultString;
        }

        private String GetDropStatementsForSqlServer()
        {
            var ReadOnlyMappings = GetReadOnlyMappingsFromAssemblies();
            var ResultString = String.Empty;
            foreach (var type in ReadOnlyMappings)
            {
                var Mapping = (IReadOnlyClassMap)Activator.CreateInstance(type);
                ResultString = ResultString + Mapping.GetDropScriptForSqlServer() + System.Environment.NewLine;
            }
            return ResultString;
        }

        private String SqlCreateStringForBasicFunctions()
        {
            return null;
        }

        private String SqlDropStringForBasicFunctions()
        {
            return "DROP FUNCTION NetUtcTicksToDateTime;" + System.Environment.NewLine + "GO" + System.Environment.NewLine;
        }

        private IList<Type> GetReadOnlyMappingsFromAssemblies()
        {
            dynamic ResultList = new List<Type>();
            foreach (var assemblyItem in _assemblyList)
            {
                var assembly = assemblyItem;
                foreach (var typeItem in assembly.GetExportedTypes())
                {
                    var type = typeItem;
                    if (type.BaseType.IsGenericType)
                    {
                        if (typeof(ReadOnlyClassMap<>).IsAssignableFrom(type.BaseType.GetGenericTypeDefinition()))
                        {
                            ResultList.Add(type);
                        }
                    }
                }
            }
            return ResultList;
        }
    }
}
