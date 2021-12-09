using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Idosos.Models
{
    class Medicamentos
    {
        //public int nRegisto { get; set; }

        public string nRegisto { get; set; }
        public string substancia { get; set; }
        public string nomeMedicamento { get; set; }
        public string formafarmaceutica { get; set; }
        public string dosagem { get; set; }
        public string tamanhoEmbalagem { get; set; }
        public string CNPEM { get; set; }
        public string preco { get; set; }
        public string comerc { get; set; }
        public string generico { get; set; }
        //metodo construtor
        public Medicamentos()
        {
            nRegisto = "";
            substancia = "";
            nomeMedicamento = "";
            formafarmaceutica = "";
            dosagem = "";
            tamanhoEmbalagem = "";
            CNPEM = "";
            preco = "";
            comerc = "";
            generico = "";
        }

        public bool MedicamentoExiste(string nomeMedicamento)
        {
            bool MedicamentoExiste = false;
            int nMedicamentosComEsseNome = 0;
            using (StreamReader leitor = new StreamReader("allPackages.txt"))
            {
                //  File.ReadAllLines("ContasJogoMinas.txt");

                while (!leitor.EndOfStream)
                {

                    string linha = leitor.ReadLine();

                    string[] valores = linha.Split('\t');

                    string nRegisto = valores[0];
                    string substancia = valores[1];
                    string nMedicamento = valores[2];
                    string formafarmaceutica = valores[3];
                    string dosagem = valores[4];
                    string tamanhoEmbalagem = valores[5];
                    string CNPEM = valores[6];
                    string preco = valores[7];
                    string naointeressa1 = valores[8];
                    string naointeressa2 = valores[9];
                    string naointeressa3 = valores[10];
                    string comerc = valores[11];
                    string generico = valores[12];

                    if (nMedicamento == nomeMedicamento)
                    {
                        MedicamentoExiste = true;
                        nMedicamentosComEsseNome++;
                    }
                }
                leitor.Close();
            }
            if (MedicamentoExiste == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void removerMedicamentoDoHorario(string nomeMedicamento)
        {
            Horario[] CriarHorarios = new Horario[10000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    CriarHorarios[i] = new Horario();
                    CriarHorarios[i].HoraToma = valores[0];
                    CriarHorarios[i].Tipo = valores[1];
                    CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                    CriarHorarios[i].TextoLembrete = valores[3];
                    CriarHorarios[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }
            //não vai escrever no ficheiro os medicamentos com o nome que pretendemos remover
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {
                if (CriarHorarios[a]._Medicamento.nomeMedicamento != nomeMedicamento)
                {
                    escritor.WriteLine(
                          CriarHorarios[a].HoraToma + ";" 
                        + CriarHorarios[a].Tipo + ";"
                        + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" 
                        + CriarHorarios[a].TextoLembrete + ";"
                        +CriarHorarios[a].TomouMedicamento + ";");
                }              
            }
            escritor.Close();

        }

        public void removerTodosHorarios()
        {
            //abre para escrever no ficheiro e não escreve nada
            StreamWriter escritor = new StreamWriter("Horario.txt");
            escritor.Close();
        }

        public void removerTodosLembretes()
        {
            //vamos ler e não vamos escrever os que são lembretes
            Horario[] CriarHorarios = new Horario[10000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    CriarHorarios[i] = new Horario();
                    CriarHorarios[i].HoraToma = valores[0];
                    CriarHorarios[i].Tipo = valores[1];
                    CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                    CriarHorarios[i].TextoLembrete = valores[3];
                    CriarHorarios[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }
            //não vai escrever no ficheiro os medicamentos com o nome que pretendemos remover
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {
                if (CriarHorarios[a].Tipo != "Lembrete")
                {
                    escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                                       + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                                       + CriarHorarios[a].TomouMedicamento + ";");
                }
            }
            escritor.Close();
        }
        //neste é o contrario só escreve os que são lembretes
        public void removerTodosMedicamentos()
        {
            Horario[] CriarHorarios = new Horario[10000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    CriarHorarios[i] = new Horario();
                    CriarHorarios[i].HoraToma = valores[0];
                    CriarHorarios[i].Tipo = valores[1];
                    CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                    CriarHorarios[i].TextoLembrete = valores[3];
                    CriarHorarios[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }
            //não vai escrever no ficheiro os medicamentos com o nome que pretendemos remover
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {
                if (CriarHorarios[a].Tipo != "Medicamento")
                {
                    escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                                       + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                                       + CriarHorarios[a].TomouMedicamento + ";");
                }
            }
            escritor.Close();
        }

        public void removerLembretesAntigos()
        {
            Horario[] CriarHorarios = new Horario[10000];
            //ler o ficheiro e guardar todos os eventos que a data sejam superiores à atual
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo Horario existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    //passar a data em string para datetime
                    DateTime Data = DateTime.ParseExact(valores[0], "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    if (DateTime.Compare(Data, DateTime.Now) > 0)
                    {
                        CriarHorarios[i] = new Horario();
                        CriarHorarios[i].HoraToma = valores[0];
                        CriarHorarios[i].Tipo = valores[1];
                        CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                        CriarHorarios[i].TextoLembrete = valores[3];
                        CriarHorarios[i].TomouMedicamento = valores[4];

                        i++;
                    }
                }
                leitor.Close();
            }
            //no final vai escrever no ficheiro apenas os que são maiores que a data atual
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {                
                    escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                                       + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                                       + CriarHorarios[a].TomouMedicamento + ";");                
            }
            escritor.Close();
        }

        public void MeterTomasDeMedicamentoPendentesAVermelho()//vermelho é não tomou
        {
            Horario[] CriarHorarios = new Horario[20000];
            DateTime DataHoje = DateTime.Now;
            //ler o ficheiro e guardar todos os eventos que a data sejam superiores à atual
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo Horario existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 5 parcelas que existem no horario
                    //passar a data em string para datetim
                    
                        CriarHorarios[i] = new Horario();
                        CriarHorarios[i].HoraToma = valores[0];
                        CriarHorarios[i].Tipo = valores[1];
                        CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                        CriarHorarios[i].TextoLembrete = valores[3];
                        CriarHorarios[i].TomouMedicamento = valores[4];

                        i++;
                }
                leitor.Close();
            }
            //no final vai escrever no ficheiro apenas os que são maiores que a data atual
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {
                DateTime Data = DateTime.ParseExact(CriarHorarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(Data, DataHoje) < 0 && CriarHorarios[a].TomouMedicamento == "Pendente")
                {
                    escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                                   + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                                   + "Nao;");
                }
                else
                {
                    escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                                   + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                                   + CriarHorarios[a].TomouMedicamento + ";");
                }
            }
            escritor.Close();
        }




    }

    
}
