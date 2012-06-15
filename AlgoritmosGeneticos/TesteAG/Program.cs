using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;
using QuadroHorarios;

namespace TesteAG
{
    class Program
    {
        static void Main(string[] args)
        {
            GeraQuadroHorarios qh = new GeraQuadroHorarios()
            {
                TamanhoPopulacao = 10,
                TaxaCruzamento = 0.5f,
                TaxaMutacao = 0.3f,
                TaxaSelecao = 0.5f                
            };

            qh.AddHorario("SEG12");
            qh.AddHorario("SEG34");
            qh.AddHorario("TER12");
            qh.AddHorario("TER34");
            qh.AddHorario("QUA12");
            qh.AddHorario("QUA34");
            qh.AddHorario("QUI12");
            qh.AddHorario("QUI34");
            qh.AddHorario("SEX12");
            qh.AddHorario("SEX34");

            qh.AddProfessor("P1");
            qh.AddProfessor("P2");
            qh.AddProfessor("P3");
            qh.AddProfessor("P4");
            qh.AddProfessor("P5");

            qh.AddRestricao("P1", "SEG12");
            qh.AddRestricao("P1", "TER12");
            qh.AddRestricao("P1", "QUI12");

            qh.AddRestricao("P2", "SEX34");
            qh.AddRestricao("P2", "QUI34");
            qh.AddRestricao("P2", "TER34");

            qh.AddRestricao("P3", "QUA12");
            qh.AddRestricao("P3", "QUA34");
            qh.AddRestricao("P3", "TER34");

            qh.AddRestricao("P4", "SEX34");
            qh.AddRestricao("P4", "QUI12");
            qh.AddRestricao("P4", "SEG12");

            qh.AddRestricao("P5", "TER12");
            qh.AddRestricao("P5", "QUI12");
            qh.AddRestricao("P5", "QUA12");

            /*qh.GerarPopulacaoInicial();

            foreach (IIndividuo i in qh.Populacao)
                i.Fitness = qh.CalculaFitness(i);
             */
            qh.Executar();

            String h1 = "|";
            String v1 = "|";
            String h2 = "|";
            String v2 = "|";
            for (int hor = 0; hor < qh.Horarios.Count; hor += 2)
            {
                h1 = h1 + "\t" + qh.Horarios[hor] + "\t|";
                v1 = v1 + "\t" + qh.Solucao.Cromossomos[hor] + "\t|";
                h2 = h2 + "\t" + qh.Horarios[hor+1] + "\t|";
                v2 = v2 + "\t" + qh.Solucao.Cromossomos[hor+1] + "\t|";
            }
            Console.Write(h1 + "\n" + v1 + "\n" + h2 + "\n" + v2 + "\n");
            Console.Write("Gerações: " + qh.Geracoes);

            Console.ReadLine();
        }
    }
}
