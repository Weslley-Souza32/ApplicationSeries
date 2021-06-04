using ApplicationSeries.Interfaces;
using System;
using System.Collections.Generic;


namespace ApplicationSeries
{
    // Ao herdar a interface IRepositorio nossa classe RepositorioSeries e obrigada a usar os metodos da Interface IRepositorio.
    public class RepositorioSeries : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();

        public void Atualizar(int id, Series objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }


        public Series RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}
