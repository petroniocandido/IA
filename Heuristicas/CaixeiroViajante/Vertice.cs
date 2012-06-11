using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixeiroViajante
{
    public class Vertice
    {
        public object Valor { get; set; }
        public Dictionary<Vertice, int> Vizinhos { get; set; }

        public Vertice(object val)
        {
            Valor = val;
            Vizinhos = new Dictionary<Vertice, int>();
        }

        public void Add(Vertice v, int valor)
        {
            if (!Vizinhos.Keys.Contains(v))
                Vizinhos.Add(v, valor);
        }

        public List<Aresta> Arestas()
        {
            List<Aresta> arestas = new List<Aresta>();
            foreach (KeyValuePair<Vertice, int> val in Vizinhos)
                arestas.Add(new Aresta() { CidadeOrigem = this, CidadeDestino = val.Key, Distancia = val.Value });

            return arestas;

        }
    }
}
