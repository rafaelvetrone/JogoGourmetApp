using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmetApp
{
    public abstract class BaseNode
    {     
        public abstract string PratoNome { get; set; }

        public abstract BaseNode PratoParentNode { get; set; }  

        public abstract bool Perguntar();
    }
}
