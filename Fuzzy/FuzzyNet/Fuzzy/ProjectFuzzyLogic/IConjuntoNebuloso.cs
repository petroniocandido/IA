using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzyLogic
{
    public interface IConjuntoNebuloso
    {
        float Uniao();
        float Interseccao();
        float Complemento();
        float Negacao();
    }
}
