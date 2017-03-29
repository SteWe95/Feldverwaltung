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
    public class StoreSession : IDisposable
    {
        public ISession session { get; set; }
        private ITransaction transaction;


        public virtual TResult LoadById<TResult>(Guid id)
        {
            try
            {
                return session.Get<TResult>(id);
            }
            catch (ObjectNotFoundException)
            {

            }
            return default(TResult);
        }

        public virtual IList<TResult> LoadAll<TResult>()
        {
            return session.Query<TResult>().ToList();
        }

        public virtual IList<TResult> LoadByPropertyWithValue<TResult>(
            string propertyName, object propertyValue) where TResult : class
        {
            var criteriaQuery = session.CreateCriteria<TResult>();
            criteriaQuery.Add(Restrictions.Eq(propertyName, propertyValue));
            return criteriaQuery.List<TResult>();
        }

        public virtual IList<TResult> LoadByPropertiesWithValues<TResult>(
            Expression<Func<TResult, bool>> condition) where TResult : class
        {
            return session.Query<TResult>().Where(condition).ToList<TResult>();
        }

        public void Close()
        {
            session.Close();
        }

        public virtual void BeginTransaction()
        {
            transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }

        public virtual void CommitTransaction()
        {
            transaction.Commit();
        }

        public virtual void RollbackTransaction()
        {
            transaction.Rollback();
        }

        public virtual void Save(object entity)
        {
            session.Save(entity);
        }

        public virtual void Delete(object entity)
        {
            session.Delete(entity);
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                if (transaction.IsActive)
                {
                    RollbackTransaction();
                }
                transaction.Dispose();
                transaction = null;
            }
            if (session != null)
            {
                if (session.IsOpen)
                {
                    Close();
                }
                session.Dispose();
                session = null;
            }
        }
    }
}
