using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.DatabaseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var updateOnly = AskForUpdateOnly();
            var deleteOnly = AskForDeleteOnly(updateOnly);
            var assemblyList = GetAssembliesFromExecutingFolder();
            //var config = MsSqlConfiguration.MsSql2005.ConnectionString(x => x.TrustedConnection().Server(@"WS-415\SPARK").Database(@"Feldverwaltung").TrustedConnection()).AdoNetBatchSize(0).FormatSql().DefaultSchema("dbo");
            var config = MsSqlConfiguration.MsSql2005.ConnectionString(x => x.TrustedConnection().Server(@"DESKTOP-10FNRS7\SQLEXPRESS").Database(@"Feldverwaltung").TrustedConnection()).AdoNetBatchSize(0).FormatSql().DefaultSchema("dbo");
            Action<MappingConfiguration> orderFluentMapping = createFluentMapping(assemblyList);
            Fluently.Configure().Database(config).Mappings(orderFluentMapping).ExposeConfiguration(
                delegate (Configuration cfg)
                    {
                        cfg.AddAuxiliaryDatabaseObject(new ReadOnlyMappingExtension(assemblyList));
                        if (updateOnly)
                        {
                            UpdateSchema(cfg);
                        }
                        else
                        {
                            DeleteSchema(cfg);
                            if (!deleteOnly)
                            {
                                CreateSchema(cfg);
                            }
                        }
                    }).BuildConfiguration().BuildSessionFactory();

            Console.WriteLine();
            Console.WriteLine("Process is done");
            Console.WriteLine();
            Console.WriteLine("Press \"q\" to close.");
            do
            {
            } while (!(Console.ReadKey().Key == ConsoleKey.Q));

        }

        private static IList<Assembly> GetAssembliesFromExecutingFolder()
        {
            List<Assembly> assemblies = new List<Assembly>();
            string path = (new System.IO.FileInfo(System.Environment.GetCommandLineArgs().First().Trim())).Directory.FullName;

            string[] mappingAssembly = System.IO.Directory.GetFiles(path, "*.mapping.dll");

            foreach (string assemblyFile in mappingAssembly)
            {
                assemblies.Add(Assembly.LoadFile(assemblyFile));
            }

            return assemblies;
        }

        private static Action<MappingConfiguration> createFluentMapping(IList<Assembly> mappingAssemblys)
        {
            Action<MappingConfiguration> orderFluentMapping = (MappingConfiguration MC) =>
            {
                FluentMappingsContainer FMC = MC.FluentMappings;
                MC.FluentMappings.Conventions.Add<Conventions>();
                mappingAssemblys.ToList().ForEach(Assembly => FMC.AddFromAssembly(Assembly));
                FMC.Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never());
            };

            return orderFluentMapping;
        }


        private static void UpdateSchema(NHibernate.Cfg.Configuration cfg)
        {
            SchemaUpdate SchemaUpdate = new SchemaUpdate(cfg);
            SchemaUpdate.Execute(x =>
            {
                using (Stream stream = new System.IO.FileStream(getSQLUpdateFileName(), System.IO.FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new System.IO.StreamWriter(stream))
                    {
                        streamWriter.Write(x);
                    }
                }
            }, true);
        }
        private static void DeleteSchema(NHibernate.Cfg.Configuration cfg)
        {
            SchemaExport SchemaExport = new SchemaExport(cfg);
            SchemaExport.SetOutputFile(getSQLCreateFileName()).Execute(true, true, true);
        }
        private static void CreateSchema(NHibernate.Cfg.Configuration cfg)
        {
            SchemaExport SchemaExport = new SchemaExport(cfg);
            SchemaExport.SetOutputFile(getSQLCreateFileName()).Execute(true, true, false);
        }
        private static string getSQLUpdateFileName()
        {
            dynamic Path = (new System.IO.FileInfo(System.Environment.GetCommandLineArgs().First().Trim())).Directory.FullName;
            return System.IO.Path.Combine(Path, "nhibernate_update.sql");
        }

        private static string getSQLCreateFileName()
        {
            dynamic Path = (new System.IO.FileInfo(System.Environment.GetCommandLineArgs().First().Trim())).Directory.FullName;
            return System.IO.Path.Combine(Path, "nhibernate_create.sql");
        }

        private static bool AskForUpdateOnly()
        {
            bool Result = false;

            Console.WriteLine();
            Console.WriteLine("Update only? (y/n)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                Result = true;
            }
            return Result;
        }

        private static bool AskForDeleteOnly(bool updateOnly)
        {
            bool Result = false;

            Console.WriteLine();
            if (!updateOnly)
            {
                Console.WriteLine("Delete only? (y/n)");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    Result = true;
                }
            }

            return Result;
        }
    }
}
