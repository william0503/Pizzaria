using System.Collections.Generic;

namespace Pizzaria.Dominio.Entidades
{
    public class Ingrediente
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual IList<Pizza> Pizzas { get; set; }
    }
}
