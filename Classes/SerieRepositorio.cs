using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int Id)
        {
            listaSerie[Id].Exclui();
        }

        public void inserir(Serie objeto)
        {
           listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int Proximo()
        {
           return listaSerie.Count;
        }

        public Serie RetornarPorId(int Id)
        {
            return listaSerie[Id];
        }
    }
}