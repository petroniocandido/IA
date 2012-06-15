using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;

namespace ProblemaMochila
{
    public class GeraMochila : AlgoritmoGenetico
    {
        public GeraMochila(int t)
        {
            Solucao = new Mochila(TamanhoIndividuo);
            CapacidadeMochila = t;
        }

        public List<Item> Itens = new List<Item>();
        public int CapacidadeMochila { get; set; }
        float maxFitness = 0f;
        int geracoesSemMelhoria = 0;

        public void AddItem(Item i)
        {
            if (!Itens.Contains(i))
            {
                i.ID = Itens.Count+1;
                Itens.Add(i);
                TamanhoIndividuo++;
            }
        }

        public override IIndividuo RealizarCruzamento(IIndividuo a, IIndividuo b)
        {
            IIndividuo novo = new Mochila(TamanhoIndividuo);
            int modulo = TamanhoIndividuo % 2;
            int metade = (TamanhoIndividuo - modulo) / 2;

            for (int indice = 0; indice < metade; indice++)
                novo.Cromossomos[indice] = a.Cromossomos[indice];

            for (int indice = metade; indice < TamanhoIndividuo; indice++)
                novo.Cromossomos[indice] = b.Cromossomos[indice];

            return novo;
        }

        public override void RealizarMutacao(IIndividuo a)
        {
            Random rnd = new Random();
            a.Cromossomos[rnd.Next(TamanhoIndividuo)] = rnd.Next(2);
        }

        public override void GerarPopulacaoInicial()
        {
            Random rnd = new Random();
            int modulo = TamanhoIndividuo % 2;
            int metade = (TamanhoIndividuo - modulo) / 2;
            for (int individuo = 0; individuo < TamanhoPopulacao; individuo++)
            {
                IIndividuo ind = new Mochila(TamanhoIndividuo);
                for (int cromossomo = 0; cromossomo < metade; cromossomo++)
                {
                    if (((Mochila)ind).Peso < CapacidadeMochila)
                    {
                        int ativa = rnd.Next(2);
                        ind.Cromossomos[cromossomo] = ativa;
                        if (ativa > 0)
                        {
                            ((Mochila)ind).Peso += Itens[cromossomo].Peso;
                        }
                        
                        ativa = rnd.Next(2);
                        ind.Cromossomos[cromossomo+metade] = ativa;
                        if (ativa > 0)
                        {
                            ((Mochila)ind).Peso += Itens[cromossomo+metade].Peso;
                        }
                    }
                    else
                    {
                        ind.Cromossomos[cromossomo] = 0;
                        ind.Cromossomos[cromossomo + metade] = 0;
                    }

                    if (modulo > 0)
                    {
                        int ativa = rnd.Next(2);
                        ind.Cromossomos[TamanhoIndividuo-1] = ativa;
                        if (ativa > 0)
                        {
                            ((Mochila)ind).Peso += Itens[TamanhoIndividuo - 1].Peso;
                        }
                    }

                }
                Populacao.Add(ind);
            }
        }

        public override bool CriterioParada()
        {            
            if(Solucao.Fitness > maxFitness)
            {
                maxFitness = Solucao.Fitness;
                geracoesSemMelhoria = 0;
            }
            else 
                geracoesSemMelhoria++;

            return (geracoesSemMelhoria > 100);            
        }

        public override float CalculaFitness(IIndividuo ind)
        {
            int peso = 0;
            int utilidade = 0;
            float fitness = 0;
            for (int cromossomo = 0; cromossomo < TamanhoIndividuo; cromossomo++)
            {
                if ((int)ind.Cromossomos[cromossomo] > 0)
                {
                    peso = peso + Itens[cromossomo].Peso;
                    utilidade = utilidade + Itens[cromossomo].Utilidade;
                }
            }
            ((Mochila)ind).Peso = peso;
            ((Mochila)ind).Utilidade = utilidade;
            fitness = (float)utilidade;
            if (peso > CapacidadeMochila)
                fitness = -fitness;
            return fitness;
        }
    }
}
