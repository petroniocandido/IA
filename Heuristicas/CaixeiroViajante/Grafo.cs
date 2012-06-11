using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixeiroViajante
{
    public class Grafo
    {
        public List<Vertice> Vertices { get; set; }

        public Grafo()
        {
            Vertices = new List<Vertice>();
        }

        public void AddAresta(Vertice A, Vertice B, int valor)
        {
            A.Add(B, valor);
            B.Add(A, valor);
        }
    }
}
