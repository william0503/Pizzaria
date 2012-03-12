using NHibernate;

namespace Pizzaria.NHibernate.Helpers
{
    public class SessionProvider
    {
        private readonly ISessionFactory _sessionFactory;
        private ISession _session;

        public SessionProvider(SessionFactoryProvider sessionFactoryProvider)
        {
            _sessionFactory = sessionFactoryProvider.GetSessionFactory();
        }

        public ISession GetCurrentSession()
        {
            return _session ?? (_session = _sessionFactory.OpenSession());
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }
    }
}
