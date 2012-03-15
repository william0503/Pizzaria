using System.Collections.Generic;

namespace Pizzaria.Dominio.Entidades
{
    public class Pizza
    {
        public virtual int Id { get;private set; }
        public virtual string Nome { get; set; }
        public virtual IList<Ingrediente> Ingredientes { get; set; }

        public virtual void AcrescentarIngrediente(Ingrediente ingrediente)
        {
            if (Ingredientes == null)
            {
                Ingredientes = new List<Ingrediente>();
            }

            if (ingrediente.Pizzas == null)
            {
                ingrediente.Pizzas = new List<Pizza>();
            }

            ingrediente.Pizzas.Add(this);
            //Ingredientes.Add(ingrediente);
            
        }
    }
}
