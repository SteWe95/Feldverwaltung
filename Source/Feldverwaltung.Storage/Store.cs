using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Storage
{
    public class Store : IDisposable
    {
        public ISessionFactory sessionFactory;

        public void Initialize()
        {
            var assembly = Assembly.Load("MicrosoftSQLDBPerformanceTest.Mappings");

            sessionFactory = GetSessionFactory(new Assembly[1] { assembly });
        }

        public virtual StoreSession GetStoreSession()
        {
            StoreSession storeSession = new StoreSession();
            storeSession.session = sessionFactory.OpenSession();
            storeSession.session.FlushMode = FlushMode.Commit;
            return storeSession;
        }

        private ISessionFactory GetSessionFactory(IList<Assembly> mappingAssemblys)
        {
            IPersistenceConfigurer config = null;
            config = MsSqlConfiguration.MsSql2005.ConnectionString(x => x.TrustedConnection()
                .Server(@"WS-415\SPARK")
                .Database(@"spArkDB")
                .TrustedConnection())
                .AdoNetBatchSize(0)
                .FormatSql()
                .DefaultSchema("dbo");
            Action<MappingConfiguration> orderFluentMapping = createFluentMapping(mappingAssemblys);
            try
            {
                Configuration NHConfig =
                    Fluently.Configure().Database(config).Mappings(orderFluentMapping).BuildConfiguration();
                return NHConfig.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {

                    Console.WriteLine("Error on creating session factory Details: {0}", ex.InnerException.Message);
                }
                Console.WriteLine(string.Format("Error on creating session factory Details: {0}", ex.Message));
                throw;
            }
        }

        private Action<MappingConfiguration> createFluentMapping(IList<Assembly> mappingAssemblys)
        {
            Action<MappingConfiguration> orderFluentMapping = (MappingConfiguration MC) =>
            {
                FluentMappingsContainer FMC = MC.FluentMappings;
                mappingAssemblys.ToList().ForEach(Assembly => FMC.AddFromAssembly(Assembly));
                FMC.Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never());
            };

            return orderFluentMapping;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
