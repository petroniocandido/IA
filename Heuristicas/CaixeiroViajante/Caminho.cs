using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    public class Caminho : Grafo, ISolucao
    {
        public int DistanciaTotal { get; set; }


        public List<IComponente> Componentes
        {
            get;
            set;
        }

        public float Avaliacao
        {
            get{ return DistanciaTotal; }
        }

        public void AddComponente(IComponente Componente)
        {
            if (Componente == null)
                return;

            Aresta aresta = (Aresta)Componente;
           
            if (!Componentes.Contains(Componente))
            {
                DistanciaTotal = DistanciaTotal + aresta.Distancia;
                Componentes.Add(aresta);
            }
        }

        public void RemoveComponente(IComponente Componente)
        {
            if (Componente == null)
                return;

            Aresta aresta = (Aresta)Componente;

            if (Componentes.Contains(Componente))
            {
                DistanciaTotal = DistanciaTotal - aresta.Distancia;
                Componentes.Remove(aresta);
            }            
        }
    }
   
}
