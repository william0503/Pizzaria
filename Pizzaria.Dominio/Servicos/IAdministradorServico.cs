using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Repositorios;

namespace Pizzaria.Dominio.Servicos
{
    public interface IAdministradorServico
    {
        void AutoCriarBancoDeDados();
        void InserirDadosTeste();
        IList<Pizza> PesquisarPizzas();
        void CriarIngrediente(string nome);
        IList<Ingrediente> PesquisarIngredientes();
        void CriarPizza(string nome, int ingrediente1, int ingrediente2, int ingrediente3);
    }

    public class AdministradorServico : IAdministradorServico
    {
        private IPizzaDAO _pizzaDao;
        private IIngredienteDAO _ingredienteDao;
        private readonly IBancoDadosCreator _bancoDadosCreator;

        public AdministradorServico(IPizzaDAO pizzaDao, IIngredienteDAO ingredienteDao, IBancoDadosCreator bancoDadosCreator)
        {
            _pizzaDao = pizzaDao;
            _ingredienteDao = ingredienteDao;
            _bancoDadosCreator = bancoDadosCreator;
        }


        public void AutoCriarBancoDeDados()
        {
            _bancoDadosCreator.AutoCriarBancoDeDados();
            
        }

        public IList<Pizza> PesquisarPizzas()
        {
            return _pizzaDao.GetAll();
        }

        public void CriarIngrediente(string nome)
        {
            var ingrediente = new Ingrediente();
            ingrediente.Nome = nome;
            _ingredienteDao.Save(ingrediente);
        }

        public IList<Ingrediente> PesquisarIngredientes()
        {
            return _ingredienteDao.GetAll();
        }



        public void CriarPizza(string nome, int pIngrediente1, int pIngrediente2, int pIngrediente3)
        {
            var pizza = new Pizza();
            pizza.Nome = nome;
            _pizzaDao.Save(pizza);

            var ingrediente1 = _ingredienteDao.Get(pIngrediente1);
            pizza.AcrescentarIngrediente(ingrediente1);
            _ingredienteDao.Save(ingrediente1);

            var ingrediente2 = _ingredienteDao.Get(pIngrediente2);
            pizza.AcrescentarIngrediente(ingrediente2);
            _ingredienteDao.Save(ingrediente2);

            var ingrediente3 = _ingredienteDao.Get(pIngrediente3);
            pizza.AcrescentarIngrediente(ingrediente3);
            _ingredienteDao.Save(ingrediente3);
        }

        public void InserirDadosTeste()
        {
            var pizza = new Pizza();
            pizza.Nome = "Muçarela";
            _pizzaDao.Save(pizza);

            var pIngrediente = new Ingrediente();
            pIngrediente.Nome = "Queijo";
            pizza.AcrescentarIngrediente(pIngrediente);
            _ingredienteDao.Save(pIngrediente);

            pIngrediente = new Ingrediente();
            pIngrediente.Nome = "Oregano";
            pizza.AcrescentarIngrediente(pIngrediente);
            _ingredienteDao.Save(pIngrediente);

            pIngrediente = new Ingrediente();
            pIngrediente.Nome = "Tomate";
            pizza.AcrescentarIngrediente(pIngrediente);
            _ingredienteDao.Save(pIngrediente);



        }
    }
}
