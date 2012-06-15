using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemaMochila
{
    public class Item
    {
        public int ID { get; set; }
        public String Descricao { get; set; }
        public int Peso { get; set; }
        public int Utilidade { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Item cast = (Item)obj;
            if (cast == null) return false;

            return ID.Equals(cast.ID);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public override string ToString()
        {
            return Descricao;
        }

    }
}
