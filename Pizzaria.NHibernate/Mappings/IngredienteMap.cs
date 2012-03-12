using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;
using Pizzaria.Dominio;
using Pizzaria.Dominio.Entidades;

namespace Pizzaria.NHibernate.Mappings
{
    public class IngredienteMap : ClassMap<Ingrediente>
    {
        public IngredienteMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Nome);

            References(x => x.Pizza);
        }
    }
}
