using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Idosos.Models
{
    class Horario
    {
        //depois secalhar meto em date time e converto 
        public string HoraToma { get; set; }
        public string Tipo { get; set; } //"Medicamento" ou "lembrete"
        public Medicamentos _Medicamento { get; set; }
     
        public string TextoLembrete { get; set; }

        public string TomouMedicamento { get; set; }//"Sim" ou "Não" ou "Pendente" ou "null" quando é um lembrete
                                                    //verde    vermelho  amarelo       

        //metodo construtor
        public Horario()
        {
            HoraToma = "";
            Tipo = "";
            _Medicamento = new Medicamentos();
            TextoLembrete = "";
            TomouMedicamento = "";
        }
    }
}
