using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Repositorios;

namespace Pizzaria.Dominio.Servicos
{
    public class PizzaServico
    {
        private readonly IPizzaDAO _pizzaDAO;

        public PizzaServico(IPizzaDAO pizzaDAO)
        {
            _pizzaDAO = pizzaDAO;
        }

        public Pizza PesquisarID(int id)
        {
            return _pizzaDAO.Get(id);
        }

        public IList<Pizza> PesquisarTodos()
        {
            return _pizzaDAO.GetAll();
        }
    }
}
