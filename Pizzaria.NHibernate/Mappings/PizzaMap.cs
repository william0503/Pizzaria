using FluentNHibernate.Mapping;
using Pizzaria.Dominio.Entidades;

namespace Pizzaria.NHibernate.Mappings
{
    public class PizzaMap : ClassMap<Pizza>
    {
        public PizzaMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Nome);
            Map(x => x.BordaRecheada);

            HasManyToMany(x => x.Ingredientes);
        }
    }
}
