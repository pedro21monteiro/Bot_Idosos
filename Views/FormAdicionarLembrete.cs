using Bot_Idosos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos.Views
{
    public partial class FormAdicionarLembrete : Form
    {       
        public FormAdicionarLembrete()
        {
            InitializeComponent();            
        }
        static int nMaximoLembretes = 20000;
        Horario[] CriarHorarios = new Horario[nMaximoLembretes];// o numero maximo de lembretes é 10000
        public bool AdicionouLembreteCorretamente = false;

        private void buttonAdicionarLembrete_Click(object sender, EventArgs e)
        {
            //depois tenho de por a ser um nome que exista no nosso ficheiro
            int numeroCaracteres = Convert.ToInt32(textBoxTextoLembrete.Text.Length.ToString());
            if (numericUpDownHorasLembrete.Value >=0 && numericUpDownHorasLembrete.Value <=23)
                {
                    //a data inicial tem de ser maior ou igual a data atual
                    if (numericUpDownMinutosLembrete.Value >= 0 && numericUpDownMinutosLembrete.Value <= 59)
                    {
                        //a data final tem de ser maior que a data inicial
                        if (textBoxTextoLembrete != null)
                        {
                            if(numeroCaracteres <= 80)
                            {
                            //Aqui vai ser gerado o horario deste lembrete 
                            if (AdicionarLembreteAoHorario() == true)
                            {
                                AdicionouLembreteCorretamente = true;
                                //esta função vai adicionar o ficheiro o _horario
                                MessageBox.Show("Lembrete adicionado à agenda com sucesso!!");

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao adicionar lembrete à agenda, excedeu o número máximo de lembretes !!!");
                            }
                            
                            }
                            else MessageBox.Show("O lembrete só pode ter no maximo 80 caracteres!!");
                    }
                        else MessageBox.Show("Tem de escrever alguma coisa no espaço de texto!!");
                    }
                    else MessageBox.Show("Insira os minutos de forma possivel(0-59)!!");
                }
                else MessageBox.Show("Insira uma hora possivel(0-24)!!");
            
        }
        public bool AdicionarLembreteAoHorario()
        {
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
            //verificar se excedeu o n maximo de lembretes
            if(i +1 < nMaximoLembretes - 1)
            {
                //criar a linha de texto que vou adicionar ao ficheiro
                CriarHorarios[i] = new Horario();
                //a data do ficheiro vai ser deste tipo 17/05/2021 16:38:10
                //criar o horio que vai para a string
                string horaDaTomaDia1 = dateTimePickerDataLembrete.Value.ToString();
                string horaDaTomaDia2 = horaDaTomaDia1.Remove(10, 9);

                //
                string HoraDaTomaHora1;
                string HoraDaTomaHora2;
                if (numericUpDownHorasLembrete.Value < 10)
                {
                    HoraDaTomaHora1 = "0" + numericUpDownHorasLembrete.Value.ToString() + ":";
                }
                else
                {
                    HoraDaTomaHora1 = numericUpDownHorasLembrete.Value.ToString() + ":";
                }
                if (numericUpDownMinutosLembrete.Value < 10)
                {
                    HoraDaTomaHora2 = "0" + numericUpDownMinutosLembrete.Value.ToString() + ":00";
                }
                else
                {
                    HoraDaTomaHora2 = numericUpDownMinutosLembrete.Value.ToString() + ":00";
                }

                //preencher o novo lembrete
                Horario horarioAdicionar = new Horario();
                horarioAdicionar.HoraToma = horaDaTomaDia2 + " " + HoraDaTomaHora1 + HoraDaTomaHora2;
                horarioAdicionar.Tipo = "Lembrete";
                horarioAdicionar._Medicamento.nomeMedicamento = "null";
                horarioAdicionar.TextoLembrete = textBoxTextoLembrete.Text;
                horarioAdicionar.TomouMedicamento = "null";
                

                int a;
                bool jaEscreveu = false;
                DateTime dateLembrete = DateTime.ParseExact(horarioAdicionar.HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                StreamWriter escritor = new StreamWriter("Horario.txt");
                if (i == 0)
                {
                    escritor.WriteLine(horarioAdicionar.HoraToma + ";" + horarioAdicionar.Tipo + ";"
                        + horarioAdicionar._Medicamento.nomeMedicamento + ";" + horarioAdicionar.TextoLembrete + ";"
                        + horarioAdicionar.TomouMedicamento + ";");
                }
                for (a = 0; a < i; a++)
                {
                    DateTime Data0 = DateTime.ParseExact(CriarHorarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    //vai meter na posição menor
                    if (DateTime.Compare(dateLembrete, Data0) < 0 && jaEscreveu == false)
                    {
                        //vai escrever o lembrete e depois o do for
                        escritor.WriteLine(horarioAdicionar.HoraToma + ";" + horarioAdicionar.Tipo + ";"
                        + horarioAdicionar._Medicamento.nomeMedicamento + ";" + horarioAdicionar.TextoLembrete + ";"
                        + horarioAdicionar.TomouMedicamento + ";");

                        escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                        + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                        + CriarHorarios[a].TomouMedicamento + ";");
                        jaEscreveu = true;
                        
                    }//se não for menor
                    else
                    {
                        escritor.WriteLine(CriarHorarios[a].HoraToma + ";" + CriarHorarios[a].Tipo + ";"
                       + CriarHorarios[a]._Medicamento.nomeMedicamento + ";" + CriarHorarios[a].TextoLembrete + ";"
                       + CriarHorarios[a].TomouMedicamento + ";");
                        //no final
                        //se a = i -1, e ainda não escreveu,, vai escrever no finaal
                        if(a == (i -1) && jaEscreveu == false){
                            escritor.WriteLine(horarioAdicionar.HoraToma + ";" + horarioAdicionar.Tipo + ";"
                        + horarioAdicionar._Medicamento.nomeMedicamento + ";" + horarioAdicionar.TextoLembrete + ";"
                        + horarioAdicionar.TomouMedicamento + ";");
                        }
                    }
                    
                }
                escritor.Close();

                return true;
            }
            else
            {
                return false;
            }


            
        }

        public int ContadorDeLinhasDeUmFicheiro(string filename)
        {
            TextReader Leitor = new StreamReader(filename, true);//Inicializa o Leitor
            int Linhas = 0;
            while (Leitor.Peek() != -1)
            {//Enquanto o arquivo não acabar, o Peek não retorna -1 sendo adequando para o loop while...
                Linhas++;//Incrementa 1 na contagem
                Leitor.ReadLine();//Avança uma linha no arquivo
            }
            Leitor.Close(); //Fecha o Leitor, dando acesso ao arquivo para outros programas....
            return Linhas;
        }

    }
}
