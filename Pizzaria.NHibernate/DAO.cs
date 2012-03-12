using System.Collections.Generic;

using Pizzaria.Dominio.Repositorios;
using Pizzaria.NHibernate.Helpers;
using NHibernate;

namespace Pizzaria.NHibernate
{
    public class DAO<T> : IRepositorio<T>
    {
        private readonly SessionProvider _sessionProvider;

        public DAO(SessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return _sessionProvider.GetCurrentSession(); }
        }

        #region IRepositorio<T> Members

        public void Save(T entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();
        }

        public T Get(int id)
        {
            return Session.Load<T>(id);
        }

        public void Delete(int id)
        {
            T entidade = Get(id);
            Delete(entidade);
        }

        public void Delete(T entidade)
        {
            Session.Delete(entidade);
            Session.Flush();
        }

        public IList<T> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }

        #endregion
    }
}