using System;
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

        private int InsertNewPizza()
        {
            var provider = new SessionFactoryProvider();
            var sessionProvider = new SessionProvider(provider);
            var sessaoAtual = sessionProvider.GetCurrentSession();

            if (Request.Form["Nome"] != null)
            {
                string nome = Request.Form["Nome"].ToString();

                var pizza = new Pizza {Nome = nome};
                sessaoAtual.Save(pizza);

                var ingrediente1 = new Ingrediente { Nome = Request.Form["I1"].ToString() };
                var ingrediente2 = new Ingrediente { Nome = Request.Form["I2"].ToString() };
                var ingrediente3 = new Ingrediente { Nome = Request.Form["I3"].ToString() };

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
            else
            {
                return 0;
            }
        }
    }
}
