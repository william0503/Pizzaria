using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Servicos;

namespace Pizzaria
{
    public partial class GridConsultaAvancada : System.Web.UI.Page
    {
        
            
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultaPizzaPorIngrediente(Convert.ToInt32(Request["ingrediente"]));
        }

        public void ConsultaPizzaPorIngrediente(int id)
        {
            var container = Global.InicializarContainer();
            var  administradorServico = container.Resolve<IAdministradorServico>();
            Ingrediente ingrediente = administradorServico.PesquisarIngredientesPorId(id);
            var pizzas = ingrediente.Pizzas;
            GridConsulta.DataSource = pizzas;
            GridConsulta.DataBind();
        }
    }
}