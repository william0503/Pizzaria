using System;
using Pizzaria.Dominio.Servicos;

namespace Pizzaria
{
    public partial class CriarBD : System.Web.UI.Page
    {
        private IAdministradorServico _administradorServico;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["bdCreate"] != null)
            {
                var container = Global.InicializarContainer();
                _administradorServico = container.Resolve<IAdministradorServico>();

                _administradorServico.AutoCriarBancoDeDados();
                _administradorServico.InserirDadosTeste();
                
            }

            
        }
        
    }
}
