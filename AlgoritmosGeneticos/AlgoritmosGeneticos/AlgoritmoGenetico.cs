using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmosGeneticos
{
    public abstract class AlgoritmoGenetico
    {
        public int Geracoes { get; set; }
        public int TamanhoPopulacao { get; set; }
        public float TaxaCruzamento { get; set; }
        public float TaxaSelecao { get; set; }
        public float TaxaMutacao { get; set; }

        public List<IIndividuo> Populacao { get; set; }
        public IIndividuo Solucao { get; set; }

        public AlgoritmoGenetico()
        {
            Populacao = new List<IIndividuo>();
        }
        
        public void Selecao()
        {
            int qtdDescarte = (int)((float)TamanhoPopulacao * TaxaSelecao);
            int count = 0;

            Populacao = Populacao
                .OrderByDescending(x => x.Fitness)
                .Take(TamanhoPopulacao - qtdDescarte)
                .ToList();
        }

        private void AtualizaFitness()
        {
            foreach (IIndividuo individuo in Populacao)
            {
                individuo.Fitness = CalculaFitness(individuo);
                if (Solucao.Fitness < individuo.Fitness)
                    Solucao = individuo;
            }
        }

        public void Cruzamento()
        {
            int qtdCruzamento = (int)((float)TamanhoPopulacao * TaxaCruzamento);
            int qtdReposicao = (int)((float)TamanhoPopulacao * TaxaSelecao);

            List<IIndividuo> elite = Populacao.Take(qtdCruzamento).ToList();

            for(int filho = 0; filho < qtdReposicao; filho++)
                if(filho + 1 < qtdCruzamento)
                    Populacao.Add(RealizarCruzamento(elite[filho], elite[filho+1]));
                else
                    Populacao.Add(RealizarCruzamento(elite[filho], elite[0]));
        }

        public abstract IIndividuo RealizarCruzamento(IIndividuo a, IIndividuo b);


        public void Mutacao()
        {
            Random rnd = new Random();
            int qtdMutacao = (int)((float)TamanhoPopulacao * TaxaMutacao);
            List<int> indices = new List<int>();
            for (int mutante = 0; mutante < qtdMutacao; mutante++)
            {
                int indice = 0;
                do
                {
                    indice = rnd.Next(TamanhoPopulacao);                    
                } while (indices.Contains(indice));

                indices.Add(indice);
                RealizarMutacao(Populacao[indice]);
            }
        }

        public abstract void RealizarMutacao(IIndividuo a);

        public abstract void GerarPopulacaoInicial();
        public abstract bool CriterioParada();
        public abstract float CalculaFitness(IIndividuo ind);

        public void Executar()
        {
            GerarPopulacaoInicial();
            AtualizaFitness();
            while (!CriterioParada())
            {
                Selecao();
                Cruzamento();
                Mutacao();
                AtualizaFitness();
                Geracoes++;
            } 
        }

    }
}
