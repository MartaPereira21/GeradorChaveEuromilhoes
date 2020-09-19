using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromilhoes
{
    public class Euromilhoes
    {
        public EuromilhosEstrelaseNumeros EuromilhosSorteado { get; set; }
        public EuromilhosEstrelaseNumeros EuromilhosInserido { get; set; }


        public EuromilhosEstrelaseNumeros NumerosEstrelasIguas{ get; set; }

    }
    public class EuromilhosEstrelaseNumeros
    {
        public List<int> Numeros { get; set; }
        public List<int>  Estrelas { get; set; }
    }

}
