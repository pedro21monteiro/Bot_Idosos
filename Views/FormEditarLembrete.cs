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
    public partial class FormEditarLembrete : Form
    {
        public FormEditarLembrete(string _HoraToma, string _Tipo, string _nomeMedicamento, string _textoLembrete, string _TomouMedicamento)//depois adicionar o tomouMedicamento
        {
            InitializeComponent();
            InicializarView(_HoraToma, _Tipo, _nomeMedicamento, _textoLembrete, _TomouMedicamento);
        }
      
        
        Horario horario = new Horario();
        public bool LembreteEditadoCorretamente = false;
        public void InicializarView(string _HoraToma, string _Tipo, string _nomeMedicamento, string _textoLembrete, string _TomouMedicamento)
        {


            //gerar o horario que vai ser editado
            horario.HoraToma = _HoraToma;
            horario.Tipo = _Tipo;
            horario._Medicamento.nomeMedicamento = _nomeMedicamento;
            horario.TextoLembrete = _textoLembrete;
            horario.TomouMedicamento = _TomouMedicamento;

            //Inicilizar as componentes da form
            DateTime Data = DateTime.ParseExact(_HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePickerDataEditarLembrete.Value = Data;
            numericUpDownHorasEditarLembrete.Value = Data.Hour;
            numericUpDownMinutosEditarLembrete.Value = Data.Minute;
            if(_Tipo == "Medicamento")
            {
                textBoxTextoEditarLembrete.Text = "Tomar " + _nomeMedicamento;
            }
            if (_Tipo == "Lembrete")
            {
                textBoxTextoEditarLembrete.Text = _textoLembrete;
            }
        }

        private void buttonEditarLembrete_Click(object sender, EventArgs e)
        {
            //depois tenho de por a ser um nome que exista no nosso ficheiro
            int numeroCaracteres = Convert.ToInt32(textBoxTextoEditarLembrete.Text.Length.ToString());
            if (numericUpDownHorasEditarLembrete.Value >= 0 && numericUpDownHorasEditarLembrete.Value <= 23)
            {
                //a data inicial tem de ser maior ou igual a data atual
                if (numericUpDownMinutosEditarLembrete.Value >= 0 && numericUpDownMinutosEditarLembrete.Value <= 59)
                {
                    //a data final tem de ser maior que a data inicial
                    if (textBoxTextoEditarLembrete != null)
                    {
                        if (numeroCaracteres <= 80)
                        {
                            //Aqui vai ser gerado o horario deste lembrete 

                            EditarLembreteDoHorario();

                            LembreteEditadoCorretamente = true;
                            //esta função vai adicionar o ficheiro o _horario
                            MessageBox.Show("Lembrete editado com sucesso!!");

                            this.Close();
                        }
                        else MessageBox.Show("O lembrete só pode ter no maximo 80 caracteres!!");
                    }
                    else MessageBox.Show("Tem de escrever alguma coisa no espaço de texto!!");
                }
                else MessageBox.Show("Insira os minutos de forma possivel(0-59)!!");
            }
            else MessageBox.Show("Insira uma hora possivel(0-24)!!");
        }

        public void EditarLembreteDoHorario()
        {
            //vai ler o ficheiro e apagar o que é igual aquela posição, depois vai atualizar os proximos eventos
            // e a listbox do calendar picker

            //vamos ler e não vamos escrever os que são lembretes
            Horario[] horarios = new Horario[20000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            //ao ler não vai guardar a posição a apagar
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                bool JaApagou = false;
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    if (valores[0] != horario.HoraToma
                   || valores[1] != horario.Tipo
                   || valores[2] != horario._Medicamento.nomeMedicamento
                   || valores[3] != horario.TextoLembrete
                   || valores[4] != horario.TomouMedicamento
                   || JaApagou == true)
                    {
                        //se tiver algum diferente vai guardar
                        horarios[i] = new Horario();
                        horarios[i].HoraToma = valores[0];
                        horarios[i].Tipo = valores[1];
                        horarios[i]._Medicamento.nomeMedicamento = valores[2];
                        horarios[i].TextoLembrete = valores[3];
                        horarios[i].TomouMedicamento = valores[4];

                        i++;
                    }
                    else
                    {
                        JaApagou = true;
                    }
                }
                leitor.Close();
            }

            //vai gerar o novo horario
            //criar a linha de texto que vou adicionar ao ficheiro
            Horario horarioEditado = new Horario();
            //a data do ficheiro vai ser deste tipo 17/05/2021 16:38:10
            //criar o horio que vai para a string
            string horaDaTomaDia1 = dateTimePickerDataEditarLembrete.Value.ToString();
            string horaDaTomaDia2 = horaDaTomaDia1.Remove(10, 9);

            //
            string HoraDaTomaHora1;
            string HoraDaTomaHora2;
            if (numericUpDownHorasEditarLembrete.Value < 10)
            {
                HoraDaTomaHora1 = "0" + numericUpDownHorasEditarLembrete.Value.ToString() + ":";
            }
            else
            {
                HoraDaTomaHora1 = numericUpDownHorasEditarLembrete.Value.ToString() + ":";
            }
            if (numericUpDownMinutosEditarLembrete.Value < 10)
            {
                HoraDaTomaHora2 = "0" + numericUpDownMinutosEditarLembrete.Value.ToString() + ":00";
            }
            else
            {
                HoraDaTomaHora2 = numericUpDownMinutosEditarLembrete.Value.ToString() + ":00";
            }

            //ao editar se for um medicamento vai transformar em um lembrete
            horarioEditado.HoraToma = horaDaTomaDia2 + " " + HoraDaTomaHora1 + HoraDaTomaHora2;
            horarioEditado.Tipo = "Lembrete";
            horarioEditado._Medicamento.nomeMedicamento = "null";
            horarioEditado.TextoLembrete = textBoxTextoEditarLembrete.Text;
            horarioEditado.TomouMedicamento = "null";

            //vai escrever o novo horario no ficheiro
            int a;
            bool jaEscreveu = false;
            DateTime dateLembrete = DateTime.ParseExact(horarioEditado.HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            StreamWriter escritor = new StreamWriter("Horario.txt");
            for (a = 0; a < i; a++)
            {
                DateTime Data0 = DateTime.ParseExact(horarios[a].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                //vai meter na posição menor
                if (DateTime.Compare(dateLembrete, Data0) < 0 && jaEscreveu == false)
                {
                    //vai escrever o lembrete e depois o do for
                    escritor.WriteLine(horarioEditado.HoraToma + ";" + horarioEditado.Tipo + ";"
                    + horarioEditado._Medicamento.nomeMedicamento + ";" + horarioEditado.TextoLembrete + ";"
                    + horarioEditado.TomouMedicamento + ";");

                    escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                    + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                    + horarios[a].TomouMedicamento + ";");
                    jaEscreveu = true;

                }//se não for menor
                else
                {
                    escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                   + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                   + horarios[a].TomouMedicamento + ";");
                    //no final
                    //se a = i -1, e ainda não escreveu,, vai escrever no finaal
                    if (a == (i - 1) && jaEscreveu == false)
                    {
                        escritor.WriteLine(horarioEditado.HoraToma + ";" + horarioEditado.Tipo + ";"
                    + horarioEditado._Medicamento.nomeMedicamento + ";" + horarioEditado.TextoLembrete + ";"
                    + horarioEditado.TomouMedicamento + ";");
                    }
                }

            }
            escritor.Close();
        }
    }
}
