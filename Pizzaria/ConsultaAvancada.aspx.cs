using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Servicos;

namespace Pizzaria
{
    public partial class ConsultaAvancada : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IAdministradorServico _administradorServico;
            var container = Global.InicializarContainer();
            _administradorServico = container.Resolve<IAdministradorServico>();
            
            DropDownListIngrediente.DataSource = _administradorServico.PesquisarIngredientes();

            DropDownListIngrediente.DataBind();

            if (Request.QueryString["Consulta"] != null)
            {
                
            }
            
        }

    }
}