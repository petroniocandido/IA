using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoritmosGeneticos
{
    public interface IIndividuo
    {
        object[] Cromossomos { get; set; }
        int TamanhoCromossomo { get; set; }
        float Fitness { get; set; }
        void CalculaFitness();
    }
}
