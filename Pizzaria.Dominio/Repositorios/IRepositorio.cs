using System.Collections.Generic;

namespace Pizzaria.Dominio.Repositorios
{
    public interface IRepositorio<T> 
    {
        void Save(T entity);
        T Get(int id);
        IList<T> GetAll();
        void Delete(int id);
        void Delete(T entity);
    }
}
