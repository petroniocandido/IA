using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
   
    public class Aresta : IComponente
    {
        public Vertice CidadeOrigem { get; set; }
        public Vertice CidadeDestino { get; set; }
        public int Distancia { get; set; }

        public Aresta()
        {
            Distancia = 0;
        }

        public object Valor
        {
            get
            {
                return Distancia;
            }
        }

        object IComponente.Valor
        {
            get { throw new NotImplementedException(); }
        }
    }
}
