using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Repositorios;
using Pizzaria.NHibernate.Helpers;

namespace Pizzaria.NHibernate.Repositorios
{
    public class PizzaDAO : DAO<Pizza>, IPizzaDAO
    {
        public PizzaDAO(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}
