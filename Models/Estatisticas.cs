using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Idosos.Models
{
    class Estatisticas
    {
        public string NomeMedicamento { get; set; }
        public int Tomados { get; set; } 
        public int Espera { get; set; }

        public int NaoTomados { get; set; }

        public int Percentagem { get; set; }
    }
}
