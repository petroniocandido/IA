using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HeuristicaConstrutiva;

namespace ProblemaQuadroHorarios
{
    public class QuadroHorario : ISolucao
    {
        #region ISolucao Members

        public List<IComponente> Componentes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float Avaliacao
        {
            get { throw new NotImplementedException(); }
        }

        public void AddComponente(IComponente Componente)
        {
            throw new NotImplementedException();
        }

        public void RemoveComponente(IComponente Componente)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
