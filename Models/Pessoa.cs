using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos.Models
{
    class Pessoa
    {
        public string Nome { get; set; }

        public string Apelido { get; set; }
        public int Idade { get; set; }
        public DateTime DataCriacaoConta { get; set; }
        public Horario[] InfoDaToma { get; set; }

        public int Alarme { get; set; }

        public string Foto { get; set; }//vai ter a string do caminho da foto

        //int numeroMaximoDeHorarios = 20000;
        public void ApagarConta()
        {
            //o apagar conta vai fazer com que se vá aos dois ficheiros(Conta.txt,Horario.txt) e se apague os dois
            StreamWriter escritor = new StreamWriter("Horario.txt");
            escritor.Close();
            escritor = new StreamWriter("Contas.txt");
            escritor.Close();
        }

        public void TrocarAlarme(int _nAlarme)
        {
            StreamReader ler = new StreamReader("Contas.txt");
            string InfoConta = ler.ReadLine();
            ler.Close();
            string[] valores = InfoConta.Split(';');
            string nomeConta = valores[0];
            string ApelidoConta = valores[1];
            string IdadeConta = valores[2];
            string DataCriacaoContaAntiga = valores[3];
            string Alarme = valores[4];
            string Foto = valores[5];

            //o d dentro do toString faz com que não meta as horas , apenas a data

            //escrever a conta criada
            //tem de ser um numero de 1 a 5 que são os 5 alarmes que existem
            if(_nAlarme > 0 && _nAlarme <6)
            {
                StreamWriter escritor = new StreamWriter("Contas.txt");
                escritor.WriteLine(nomeConta + ";" + ApelidoConta + ";" + IdadeConta + ";" + DataCriacaoContaAntiga + ";"
                    + _nAlarme.ToString() + ";" + Foto + ";");
                escritor.Close();
            }
        }

        public void AtualizarDadosPessoa()
        {
            StreamReader ler = new StreamReader("Contas.txt");
            string InfoConta = ler.ReadLine();
            ler.Close();
            string[] valores = InfoConta.Split(';');
            Nome = valores[0];
            Apelido = valores[1];
            Idade = Convert.ToInt32(valores[2]);
            DateTime Data = DateTime.ParseExact(valores[3], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DataCriacaoConta = Data;
            Alarme = Convert.ToInt32(valores[4]);
            Foto = valores[5];
        }

        //public void AtualizarFicheiroDeHistorico()
        //{
        //    //DateTime Data = DateTime.ParseExact(valores[0], "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //    //if (DateTime.Compare(Data, DateTime.Now) > 0)
        //    //{

        //    Horario[] Horarios = new Horario[numeroMaximoDeHorarios];
        //    Horario[] HorariosHistorico = new Horario[numeroMaximoDeHorarios];
        //    DateTime DataAgora = DateTime.Now;// fiz desta forma para não estar sempre a fazer o dtetime.now, e pq assim pode 
        //                                      //evitar erros

        //    //vai ler e guardar do ficheiro Horario
        //    int i = 0;//do horario
        //    int j = 0;//do historico

        //    using (StreamReader leitor = new StreamReader("Horario.txt"))
        //    {
        //        while (!leitor.EndOfStream)
        //        {
        //            string linha = leitor.ReadLine();
        //            string[] valores = linha.Split(';');

        //            //aqui esta as 5 parcelas que existem no horario
        //            //passar a data em string para datetime

        //            Horarios[i] = new Horario();
        //            Horarios[i].HoraToma = valores[0];
        //            Horarios[i].Tipo = valores[1];
        //            Horarios[i]._Medicamento.nomeMedicamento = valores[2];
        //            Horarios[i].TextoLembrete = valores[3];
        //            Horarios[i].TomouMedicamento = valores[4];//sim ou não

        //            i++;
        //        }
        //        leitor.Close();
        //    }
        //    //vai ler e guardar do ficheiro de Historico
        //    using (StreamReader leitor = new StreamReader("Historico.txt"))
        //    {
        //        while (!leitor.EndOfStream)
        //        {
        //            string linha = leitor.ReadLine();
        //            string[] valores = linha.Split(';');

        //            //aqui esta as 5 parcelas que existem no Historico
        //            //passar a data em string para datetime
        //            HorariosHistorico[j] = new Horario();
        //            HorariosHistorico[j].HoraToma = valores[0];
        //            HorariosHistorico[j].Tipo = valores[1];
        //            HorariosHistorico[j]._Medicamento.nomeMedicamento = valores[2];
        //            HorariosHistorico[j].TextoLembrete = valores[3];
        //            HorariosHistorico[j].TomouMedicamento = valores[4];//sim ou não

        //            j++;
        //        }
        //        leitor.Close();
        //    }
        //    //agora vamos contar quantos horarios já são depois da data atual, os que passarão para o historico
        //    int a;
        //    int NumeroHorariosPassarParaHistorico = 0;
        //    for (a = 0; a < i; a++)
        //    {
        //        DateTime Data = DateTime.ParseExact(Horarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //        if (DateTime.Compare(Data, DataAgora) < 0)
        //        {
        //            NumeroHorariosPassarParaHistorico++;
        //        }
        //    }
        //    //vamos verificar se excede os 20000 lugares
        //    int QuantosHorariosHistoricoExcedeu = 0;
        //    if ((j - 1) + NumeroHorariosPassarParaHistorico > numeroMaximoDeHorarios)//j pois foi o n linhas do leito do ficheiro historico
        //    {
        //        QuantosHorariosHistoricoExcedeu = ((j - 1) + NumeroHorariosPassarParaHistorico) - numeroMaximoDeHorarios;
        //    }


        //    //agora vamos passar para o historico os que são anteriores à data atual
        //    int b;
        //    StreamWriter escritorHistorico = new StreamWriter("Historico.txt");
        //    //no ficheiro historico primeiro vai escrever os historicos antigos
        //    for (b = QuantosHorariosHistoricoExcedeu; b < j; b++)//j pois é o numero de linhas do ficheiro historico
        //    {
        //        escritorHistorico.WriteLine(HorariosHistorico[b].HoraToma + ";" + HorariosHistorico[b].Tipo + ";"
        //                           + HorariosHistorico[b]._Medicamento.nomeMedicamento + ";" + HorariosHistorico[b].TextoLembrete + ";"
        //                           + HorariosHistorico[b].TomouMedicamento + ";");
        //    }
        //    //depois vai escrever os os horarios que já são anteriores à data atual
        //    for (a = 0; a < i; a++)// i pois é o numero de linhas do ficheiro horarios
        //    {
        //        DateTime Data = DateTime.ParseExact(Horarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //        if (DateTime.Compare(Data, DataAgora) < 0)
        //        {
        //            escritorHistorico.WriteLine(Horarios[a].HoraToma + ";" + Horarios[a].Tipo + ";"
        //                           + Horarios[a]._Medicamento.nomeMedicamento + ";" + Horarios[a].TextoLembrete + ";"
        //                           + Horarios[a].TomouMedicamento + ";");
        //        }
        //    }
        //    //no final fecha o escritor do ficheiro Historico
        //    escritorHistorico.Close();

        //    //------------------------Atualizar o Ficheiro dos horarios----------------------------------

        //    //agora nos ficheiros de horarios apenas vamos escrever os que são depois da data atual
        //    StreamWriter escritorHorarios = new StreamWriter("Horario.txt");
        //    for (a = 0; a < i; a++)// i pois é o numero de linhas do ficheiro horarios
        //    {
        //        DateTime Data = DateTime.ParseExact(Horarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //        if (DateTime.Compare(Data, DataAgora) > 0)
        //        {
        //            escritorHorarios.WriteLine(Horarios[a].HoraToma + ";" + Horarios[a].Tipo + ";"
        //                           + Horarios[a]._Medicamento.nomeMedicamento + ";" + Horarios[a].TextoLembrete + ";"
        //                           + Horarios[a].TomouMedicamento + ";");
        //        }
        //        escritorHorarios.Close();
        //    }
        //}
    }
}
