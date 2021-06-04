using System;
using System.Collections.Generic;


namespace ApplicationSeries.Interfaces 
{
    public interface IRepositorio<L>
    {
        List<L> Lista();
        L RetornaPorId(int id);
        void Insere(L entidade);
        void Exclui(int id);
        void Atualizar(int id, L entidade);
        int ProximoId();
    }




}
