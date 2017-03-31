using Feldverwaltung.Storage;
using Feldverwaltung.Domain;
using NHibernate;
using System.Collections.Generic;
using System.Reflection;
using System;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using System.Linq;
using NHibernate.Cfg;

namespace Feldverwaltung.Auftragsliste
{
    public class Controller
    {
        private Store store;
        public Controller()
        {
            store = new Store();
        }


        public IList<Task> LoadTasks()
        {
            using (StoreSession storeSession = store.GetStoreSession())
            {
                return storeSession.LoadAll<Task>();
            }
        }

        
    }
}