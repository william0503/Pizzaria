using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Repositorios;
using Pizzaria.NHibernate.Helpers;

namespace Pizzaria.NHibernate.Repositorios
{
    public class IngredienteDAO : DAO<Ingrediente>, IIngredienteDAO
    {
        public IngredienteDAO(SessionProvider sessionProvider)
            : base (sessionProvider)
        {
        }

    }
}
