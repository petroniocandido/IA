using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;

namespace QuadroHorarios
{
    public class QuadroHorarios : IIndividuo
    {

        public QuadroHorarios()
        {
         
        }
        public QuadroHorarios(int t)
        {
            TamanhoCromossomo = t;
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

        public float Fitness
        {
            get;
            set;
        }

       

    }
}
