using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Repositorios;
using Pizzaria.NHibernate;
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
