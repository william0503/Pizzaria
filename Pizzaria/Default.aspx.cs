using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NHibernate;
using Pizzaria.Dominio.Entidades;
using Pizzaria.NHibernate.Helpers;

namespace Pizzaria
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["insertNewPizza"] != null)
            {
                int p = InsertNewPizza();

                Response.Write(String.Format("Pizza inserida com sucesso! Codigo {0}", p.ToString()));
                Response.End();
            }
        }

        private static int InsertNewPizza()
        {
            var provider = new SessionFactoryProvider();
            var sessionProvider = new SessionProvider(provider);
            var sessaoAtual = sessionProvider.GetCurrentSession();

            var pizza = new Pizza {Nome = "Muçarela"};
            sessaoAtual.Save(pizza);

            var ingrediente1 = new Ingrediente {Nome = "Queijo"};
            var ingrediente2 = new Ingrediente {Nome = "Oregano"};
            var ingrediente3 = new Ingrediente {Nome = "Tomate"};

            pizza.AcrescentarIngrediente(ingrediente1);
            pizza.AcrescentarIngrediente(ingrediente2);
            pizza.AcrescentarIngrediente(ingrediente3);

            sessaoAtual.Save(ingrediente1);
            sessaoAtual.Save(ingrediente2);
            sessaoAtual.Save(ingrediente3);

            sessaoAtual.Clear();

            Pizza p = sessaoAtual.Get<Pizza>(pizza.Id);

            return p.Id;
        }
    }
}
