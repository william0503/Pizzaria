using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Pizzaria.Dominio.Entidades
{
    public class Ingrediente
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        [ScriptIgnore]
        public virtual IList<Pizza> Pizzas { get; set; }
    }
}
