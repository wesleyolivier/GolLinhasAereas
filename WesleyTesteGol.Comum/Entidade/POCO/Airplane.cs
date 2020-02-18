using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesleyTesteGol.Comum.Entidade.POCO
{
    public class Airplane
    {
        public int Codigo { get; set; }
        public string Modelo { get; set; }

        public int QuantidadePassageiros { get; set; }

        public DateTime DataCriacaoRegistro { get; set; }
    }
}
