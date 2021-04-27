using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornarPorId (int Id);
        void inserir (T entidade);
        void Exclui (int Id);
        void Atualizar (int id, T entidade);
        int Proximo();      
    }
}