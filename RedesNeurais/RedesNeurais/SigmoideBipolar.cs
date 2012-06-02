using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class SigmoideBipolar : IFuncaoAtivacao
    {
        #region IFuncaoAtivacao Members

        public double Ativacao(double a)
        {
            return (2 / (1 + Math.Exp(-0.005 * a))) - 1;
        }

        public double Derivada(double a)
        {
            return (0.005 / 2) * ((1 + Ativacao(a)) * (1 - Ativacao(a)));
        }

        #endregion
    }
}
