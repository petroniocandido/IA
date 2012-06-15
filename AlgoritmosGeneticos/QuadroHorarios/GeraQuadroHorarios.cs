using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;

namespace QuadroHorarios
{
    public class GeraQuadroHorarios : AlgoritmoGenetico
    {
        public List<String> Professores { get; set; }
        public List<String> Horarios { get; set; }
        public Dictionary<String, int> HorariosRev { get; set; }
        public List<String> Restricoes { get; set; }

        public int TamanhoIndividuo { get; set; }

        public GeraQuadroHorarios()
        {
            Professores = new List<string>();
            HorariosRev = new Dictionary<string, int>();
            Horarios = new List<string>();
            Restricoes = new List<string>();
            Solucao = new QuadroHorarios(TamanhoIndividuo);
        }

        public void AddHorario(String hor)
        {
            if (!HorariosRev.ContainsKey(hor))
            {
                HorariosRev.Add(hor, Horarios.Count);
                Horarios.Add(hor);
                TamanhoIndividuo = Horarios.Count;                
            }
        }

        public void AddProfessor(String prof)
        {
            if (!Professores.Contains(prof))
                Professores.Add(prof);
        }

        public void AddRestricao(String hor, String prof)
        {
            if (!Restricoes.Contains(hor+"_"+prof))
                Restricoes.Add(hor + "_" + prof);
        }

        public override IIndividuo RealizarCruzamento(IIndividuo a, IIndividuo b)
        {
            IIndividuo novo = new QuadroHorarios(TamanhoIndividuo);
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
            a.Cromossomos[rnd.Next(TamanhoIndividuo - 1)] = Professores[rnd.Next(Professores.Count)];
        }

        public override void GerarPopulacaoInicial()
        {
            Random rnd = new Random();
            for (int individuo = 0; individuo < TamanhoPopulacao; individuo++)
            {
                List<String> profs = new List<string>();
                IIndividuo ind = new QuadroHorarios(TamanhoIndividuo);
                for(int cromossomo = 0; cromossomo < TamanhoIndividuo; cromossomo++)
                {
                    String p;
                    do {
                        p = Professores[rnd.Next(Professores.Count)];
                    }while(profs.Count(x => x == p) > 1);

                    profs.Add(p);
                    ind.Cromossomos[cromossomo] = p;
                    
                }
                Populacao.Add(ind);
            }
           
        }

        public override float CalculaFitness(IIndividuo ind)
        {
            float fitness = 0;
            List<String> profs = new List<string>();
            for (int cromossomo = 0; cromossomo < TamanhoIndividuo; cromossomo++)
            {
                String prof = (String)ind.Cromossomos[cromossomo];
                String hor = Horarios[cromossomo];

                profs.Add(prof);

                if (profs.Count(x => x == prof) < 3)
                {
                    if (Restricoes.Contains(prof + "_" + hor))
                        fitness = fitness - 1;
                    else
                        fitness++;
                }
                else
                {
                    fitness = fitness - 1;
                }
            }
            return fitness;
        }

        public override bool CriterioParada()
        {
            return Solucao.Fitness == 10;
        }
    }
}
