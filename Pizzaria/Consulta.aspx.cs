﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pizzaria.Dominio.Entidades;
using Pizzaria.Dominio.Servicos;
using System.Linq;

namespace Pizzaria
{
    public partial class Consulta : System.Web.UI.Page
    {
        IAdministradorServico _administradorServico;

        protected void Page_Load(object sender, EventArgs e)
        {
            var container = Global.InicializarContainer();
            _administradorServico = container.Resolve<IAdministradorServico>();
            CarregaGrids();

        }

        public void CarregaGrids()
        {
            
            gridPizza.DataSource = _administradorServico.PesquisarPizzas();
            gridIngrediente.DataSource = _administradorServico.PesquisarIngredientes().Select(x => new PizzaModel(x));
            gridCardapio.DataSource = _administradorServico.PesquisarPizzas().Select(x => new IngredienteModel(x));
            gridPizza.DataBind();
            gridIngrediente.DataBind();
            gridCardapio.DataBind();

        }

        public struct PizzaModel
        {
             public PizzaModel(Ingrediente x) : this()
             {
                 Nome = x.Nome;
                 Pizzas = x.Pizzas.Select(y => y.Nome).ToList();

             }

            
            public string Nome { get; set; }
            public List<string> Pizzas { get; set; }
        }

        public struct IngredienteModel
        {
            public IngredienteModel(Pizza x)
                : this()
            {
                string ingredientes = null;
                int c = 0;
                if(x.Ingredientes!=null)
                {
                    foreach (var pIngrediente in x.Ingredientes)
                    {
                        ingredientes += pIngrediente.Nome;
                        if (c < x.Ingredientes.Count()-1)
                        {
                            ingredientes += ", "; 
                            c++;
                        }

                    }
                    Nome = x.Nome;
                    Ingrediente = ingredientes;
                }
               
            }


            public string Nome { get; set; }
            public string Ingrediente { get; set; }
        }

    }
}