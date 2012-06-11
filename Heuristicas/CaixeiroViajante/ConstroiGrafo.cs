using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeuristicaConstrutiva;

namespace CaixeiroViajante
{
    public class ConstroiGrafo : HeuristicaConstrutiva.HeuristicaConstrutiva
    {
        public List<Aresta> Arestas { get; set; }
        public Queue<Vertice> VerticesJaVizitados { get; set; }
        public Vertice CidadeInicial { get; set; }
        public int QtdeCidades { get; set; }
        public Caminho Grafo
        {
            get
            {
                return (Caminho)Solucao;
            }
        }

        public ConstroiGrafo(int qtdCidade) 
        {
            QtdeCidades = qtdCidade;
            Arestas = new List<Aresta>();
            VerticesJaVizitados = new Queue<Vertice>();
        }

       

        public override List<IComponente> GerarComponentes()
        {
            List<IComponente> arestas = new List<IComponente>();
            if (Arestas.Count == 0)
            {
                foreach (Aresta a in CidadeInicial.Arestas())
                    if (!VerificaSeJaFoiVizitado(a))
                        arestas.Add(a);
            }
            else
                foreach (Aresta a in VerticesJaVizitados.Last().Arestas())
                    if (!VerificaSeJaFoiVizitado(a)) 
                        arestas.Add(a);
            return arestas;
        }

        bool VerificaSeJaFoiVizitado(Aresta a)
        {
            if (a.CidadeDestino.Equals(CidadeInicial))
                if (VerticesJaVizitados.Count == QtdeCidades)
                    return false;

            foreach (Vertice cidade in VerticesJaVizitados)
                if (a.CidadeDestino.Equals(cidade))
                    return true;
            return false;
        }

        public override IComponente EscolheMelhorComponente(List<IComponente> Componentes)
        {
            Aresta melhor = (Aresta)Componentes.FirstOrDefault();
            foreach (Aresta aresta in Componentes)
            {
                if (melhor != null)
                    if ((int)melhor.Valor < (int)aresta.Valor)
                        melhor = aresta;
            }
            return melhor;
        }

        public override ISolucao CriaSolucaoVazia()
        {
            throw new NotImplementedException();
        }
        

        public override bool VerificaSolucaoCompleta()
        {
            throw new NotImplementedException();
        }
    }
}
