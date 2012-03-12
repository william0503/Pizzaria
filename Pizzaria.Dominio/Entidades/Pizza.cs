using System.Collections.Generic;

namespace Pizzaria.Dominio.Entidades
{
    public class Pizza
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IList<Ingrediente> Ingredientes { get; set; }

        public virtual void AcrescentarIngrediente(Ingrediente ingrediente)
        {
            if (Ingredientes == null)
            {
                Ingredientes = new List<Ingrediente>();
            }
            ingrediente.Pizza = this;
            Ingredientes.Add(ingrediente);
        }
    };
}
