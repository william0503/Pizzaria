using Pizzaria.Dominio.Repositorios;

namespace Pizzaria.NHibernate.Helpers
{
    public class BancoDadosCreator : IBancoDadosCreator
    {
        public void AutoCriarBancoDeDados()
        {
            var sessionFactoryProvider = new SessionFactoryProvider();
            var sessionProvider = new SessionProvider(sessionFactoryProvider);
            sessionProvider.GetCurrentSession();
            sessionFactoryProvider.AutoCriarBancoDeDados();
        }
    }
}
