using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;

namespace ProblemaMochila
{
    public class Mochila : IIndividuo
    {
        public Mochila(int t)
        {
            Cromossomos = new object[t];
        }

        public object[] Cromossomos
        {
            get;
            set;
        }

        public int TamanhoCromossomo
        {
            get;
            set;
        }

        public int Peso
        {
            get;
            set;
        }

        public int Utilidade
        {
            get;
            set;
        }

        public float Fitness
        {
            get;
            set;
        }

    }
}
