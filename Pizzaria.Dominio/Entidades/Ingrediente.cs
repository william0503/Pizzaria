namespace Pizzaria.Dominio.Entidades
{
    public class Ingrediente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
