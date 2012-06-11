using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HeuristicaConstrutiva;

namespace ProblemaQuadroHorarios
{
    public class ConstroiQuadroHorario : HeuristicaConstrutiva.HeuristicaConstrutiva
    {

        public List<Horario> Horarios { get; set; }
        public List<Professor> Professores { get; set; }

        public List<Alocacao> ListaTabu { get; set; }

        public QuadroHorario Quadro { get; set; }

        public void AddRestricao(Professor p, Horario h)
        {
            p.Restricoes.Add(h);
            h.Restricoes.Add(p);

            p.Restricoes.Count();
            h.Restricoes.Count();
        }

        public override List<IComponente> GerarComponentes()
        {
            throw new NotImplementedException();
        }

        public override IComponente EscolheMelhorComponente(List<IComponente> Componentes)
        {
            throw new NotImplementedException();
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
