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
    public partial class FormAdicionarMedicamento : Form
    {
        public FormAdicionarMedicamento()
        {
            InitializeComponent();
        }
        
        Medicamentos medicamentos = new Medicamentos();
        public bool AdicionouMedicamentoCorretamente = false;
        int nMaximoLembretes = 20000;

        //esta função vai ao ficheiro dos medicamentos e vê se existe algum com esse nome se não existir não deixa criar horario

        private void buttonAdicionarMedicamento_Click(object sender, EventArgs e)
        {
            //depois tenho de por a ser um nome que exista no nosso ficheiro
            //numero de opçoes clicadas só pode ser 1

            //pictureBoxLoading.Image = Bot_Idosos.Properties.Resources.loading;

            int numeroOpcoesClicadas = 0;
            if(checkBoxOpcao1.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxOpcao2.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxOpcao3.Checked == true)
            {
                numeroOpcoesClicadas++;
            }


            if (medicamentos.MedicamentoExiste(textBoxNomeMedicamento.Text) == true)
            {
                //depois verificar se escolheu opção 1 ou 2 ou 3
                //se não escolheu nenhuma opção
                if (numeroOpcoesClicadas == 0)
                {
                    MessageBox.Show("Tem de escolher uma opção(1, 2 ou 3)!!");
                }
                if (numeroOpcoesClicadas > 1)
                {
                    MessageBox.Show("Só pode escolher uma opção!!");
                }
                else
                {
                    if (checkBoxOpcao1.Checked == true)
                    {
                        //vai fazer a função 1
                        if (comboBoxVezesToma.SelectedItem != null)
                        {
                            if (numericUpDownHorasAdicionarMedicamento.Value >= 0 && numericUpDownHorasAdicionarMedicamento.Value <= 23)
                            {
                                //a data inicial tem de ser maior ou igual a data atual
                                if (dateTimePickerDataIniciaOpcao1.Value >= DateTime.Today)
                                {
                                    //a data final tem de ser maior que a data inicial
                                    if (dateTimePickerDataFinalOpcao1.Value > dateTimePickerDataIniciaOpcao1.Value)
                                    {
                                        //Aqui vai ser gerado o horario para aquele medicamento e gravado no ficheiro do horario 
                                        

                                        if (gerarHorarioDoMedicamentoOpcao1() == true)
                                        {
                                            AdicionouMedicamentoCorretamente = true;
                                            MessageBox.Show("Medicamento adicionado à agenda com sucesso !!!");
                                            this.Close();
                                        }
                                        else
                                        {
                                           
                                           MessageBox.Show("Erro ao adicionar medicmento à agenda, excedeu o número máximo de lembretes !!!");

                                        }
                                        
                                    }
                                    else MessageBox.Show("Insira uma data final valida!!");
                                }
                                else MessageBox.Show("Insira uma data inicial valida!!");
                            }
                            else MessageBox.Show("Insira um numero válido(0-23)!!");
                        }
                        else MessageBox.Show("Tem de selecionar quantas vezes vai tomar esse medicamento!!");
                    }

                    if (checkBoxOpcao2.Checked == true)
                    {
                        //vai fazer a função 2
                        if (checkedListBoxHorasToma.CheckedItems.Count != 0)
                        {
                            //a data inicial tem de ser maior ou igual a data atual
                            if (dateTimePickerDataInicialOpcao2.Value >= DateTime.Today)
                            {
                                //a data final tem de ser maior que a data inicial
                                if (dateTimePickerDataFilnalOpcao2.Value > dateTimePickerDataInicialOpcao2.Value)
                                {
                                    
                                    if (gerarHorarioDoMedicamentoOpcao2() == true)
                                    {
                                        AdicionouMedicamentoCorretamente = true;
                                        MessageBox.Show("Medicamento adicionado à agenda com sucesso !!!");
                                        this.Close();
                                    }
                                    else
                                    {
                                        
                                        MessageBox.Show("Erro ao adicionar medicmento à agenda, excedeu o número máximo de lembretes !!!");
                                    }
                                }
                                else MessageBox.Show("Insira uma data final valida!!");
                            }
                            else MessageBox.Show("Insira uma data inicial valida!!");
                        }
                        else MessageBox.Show("Tem de selecionar pelo menos uma hora para esse medicamento!!");
                    }

                    if (checkBoxOpcao3.Checked == true)
                    {
                        if (dateTimePickerDataLembrete.Value >= DateTime.Today)
                        {
                            if (numericUpDownHorasLembrete.Value >= 0 && numericUpDownHorasLembrete.Value <= 23)
                            {
                                //a data inicial tem de ser maior ou igual a data atual
                                if (numericUpDownMinutosLembrete.Value >= 0 && numericUpDownMinutosLembrete.Value <= 59)
                                {
                                    //a data para a toma do medicamento tem de ser maior que a data atual
                                    if (verificarSeDataDaOpcao3EMaiorQueDataAtual() == true)
                                    {
                                       
                                        if (gerarHorarioDoMedicamentoOpcao3() == true)
                                        {
                                            AdicionouMedicamentoCorretamente = true;
                                            MessageBox.Show("Medicamento adicionado à agenda com sucesso !!!");
                                            this.Close();
                                        }
                                        else
                                        {
                                           
                                            MessageBox.Show("Erro ao adicionar medicmento à agenda, excedeu o número máximo de lembretes !!!");
                                        }
                                    }
                                    else MessageBox.Show("Insira uma hora maior que a hora atual!!");
                                }
                                else MessageBox.Show("Insira os minutos de forma possivel(0-59)!!");
                            }
                            else MessageBox.Show("Insira uma hora possivel(0-24)!!");
                        }
                        else MessageBox.Show("Insira uma data maior que a data atual!!");
                    }
                }
            }
            else MessageBox.Show("Esse Medicamento não existe!!");

            //no final a imagem load desaparece
            //pictureBoxLoading.Image = null;

        }

        private bool gerarHorarioDoMedicamentoOpcao1()
        {
            Horario[] CriarHorariosMedicamento = new Horario[nMaximoLembretes];
            DateTime DataAgora = DateTime.Now;
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    CriarHorariosMedicamento[i] = new Horario();
                    CriarHorariosMedicamento[i].HoraToma = valores[0];
                    CriarHorariosMedicamento[i].Tipo = valores[1];
                    CriarHorariosMedicamento[i]._Medicamento.nomeMedicamento = valores[2];
                    CriarHorariosMedicamento[i].TextoLembrete = valores[3];
                    CriarHorariosMedicamento[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }
            //criar as linhas de texto que vou adicionar ao ficheiro
            //vamos
            DateTime dataInicial = dateTimePickerDataIniciaOpcao1.Value.Date.AddHours(Convert.ToDouble(numericUpDownHorasAdicionarMedicamento.Value));//Convert.ToInt32
            DateTime dataFinal = dateTimePickerDataFinalOpcao1.Value.Date.AddHours(23);//para nao ser as 24 do dia seguinte
            //valor de quantas vezes ao dia( de quantas em quantas horas)
            double horas = 0;
            
            switch (comboBoxVezesToma.Text)
            {
                case "1 vez por dia":
                    horas = 24;
                    break;
                case "2 vezes por dia":
                    horas = 12;
                    break;
                case "3 vezes por dia":
                    horas = 8;
                    break;
                case "4 vezes por dia":
                    horas = 6;
                    break;
                case "6 vezes por dia":
                    horas = 4;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            //verificar quantos horarios novos serao gerados
            DateTime dataInicialContar = dataInicial;

            int nNovosHorarios = 0;
            while (DateTime.Compare(dataFinal, dataInicialContar) > 0)
            {           
                dataInicialContar = dataInicialContar.AddHours(horas);
                nNovosHorarios++;
            }   
            
            if(nNovosHorarios + i < nMaximoLembretes - 1)
            {
                //adicionar os novos horarios
                while (DateTime.Compare(dataFinal, dataInicial) > 0)
                {

                    CriarHorariosMedicamento[i] = new Horario();
                    //criar os itens que vamso escrever no ficheiro
                    CriarHorariosMedicamento[i].HoraToma = dataInicial.ToString();
                    CriarHorariosMedicamento[i].Tipo = "Medicamento";
                    CriarHorariosMedicamento[i]._Medicamento.nomeMedicamento = textBoxNomeMedicamento.Text;
                    CriarHorariosMedicamento[i].TextoLembrete = "null";
                    CriarHorariosMedicamento[i].TomouMedicamento = "Pendente";

                    i++;
                    dataInicial = dataInicial.AddHours(horas);


                }
                //escrever os horarios que já existem e os novos horarios
                int numeroDeHorariosDepoisDaDataAtual = i - 1;
                Horario HorarioFor = new Horario();
                int j, h;
                for (j = 0; j < numeroDeHorariosDepoisDaDataAtual; j++)
                {
                    for (h = 0; h < numeroDeHorariosDepoisDaDataAtual; h++)
                    {
                        DateTime Data0 = DateTime.ParseExact(CriarHorariosMedicamento[h].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime Data1 = DateTime.ParseExact(CriarHorariosMedicamento[h + 1].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        if (DateTime.Compare(Data0, Data1) > 0)
                        {

                            HorarioFor = CriarHorariosMedicamento[h + 1];
                            CriarHorariosMedicamento[h + 1] = CriarHorariosMedicamento[h];
                            CriarHorariosMedicamento[h] = HorarioFor;
                        }
                    }
                }
                //escrever no ficheiro
                int a;
                StreamWriter escritor = new StreamWriter("Horario.txt");
                for (a = 0; a < i; a++)
                {
                    escritor.WriteLine(CriarHorariosMedicamento[a].HoraToma + ";" + CriarHorariosMedicamento[a].Tipo + ";"
                        + CriarHorariosMedicamento[a]._Medicamento.nomeMedicamento + ";" + CriarHorariosMedicamento[a].TextoLembrete + ";"
                        + CriarHorariosMedicamento[a].TomouMedicamento + ";");


                }
                escritor.Close();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        private bool gerarHorarioDoMedicamentoOpcao2()
        {
            Horario[] CriarHorariosMedicamento = new Horario[20000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    CriarHorariosMedicamento[i] = new Horario();
                    CriarHorariosMedicamento[i].HoraToma = valores[0];
                    CriarHorariosMedicamento[i].Tipo = valores[1];
                    CriarHorariosMedicamento[i]._Medicamento.nomeMedicamento = valores[2];
                    CriarHorariosMedicamento[i].TextoLembrete = valores[3];
                    CriarHorariosMedicamento[i].TomouMedicamento = valores[4];
                    //adicionar o tomou medicamento

                    i++;
                }
                leitor.Close();
            }
            // adicionar os novos horarios
            DateTime dataInicial = dateTimePickerDataInicialOpcao2.Value.Date;
            DateTime dataFinal = dateTimePickerDataFilnalOpcao2.Value.Date;

            //verificar quantos horarios novos serao gerados
            DateTime dataInicialContar = dataInicial;
            int nNovosHorarios = 0;
            while (DateTime.Compare(dataFinal, dataInicialContar) >= 0)
            { //verificar quais as horas que o idoso clicou
                int b = 0;
                for (b = 0; b < checkedListBoxHorasToma.CheckedIndices.Count; b++)
                {
                    nNovosHorarios++;
                }
                //no final aumenta um dia
                dataInicialContar = dataInicialContar.AddDays(1);
            }
            if (nNovosHorarios + i < nMaximoLembretes - 1)
            {
                while (DateTime.Compare(dataFinal, dataInicial) >= 0)
                { //verificar quais as horas que o idoso clicou
                    int b = 0;
                    for (b = 0; b < checkedListBoxHorasToma.CheckedIndices.Count; b++)
                    {
                        //adicionar ao vetor o que se vai escrever
                        CriarHorariosMedicamento[i] = new Horario();
                        CriarHorariosMedicamento[i].HoraToma = dataInicial.ToShortDateString() + " " + checkedListBoxHorasToma.CheckedItems[b].ToString() + ":00";
                        CriarHorariosMedicamento[i].Tipo = "Medicamento";
                        CriarHorariosMedicamento[i]._Medicamento.nomeMedicamento = textBoxNomeMedicamento.Text;
                        CriarHorariosMedicamento[i].TextoLembrete = "null";
                        CriarHorariosMedicamento[i].TomouMedicamento = "Pendente";
                        //adicionar o tomou medicamento

                        i++;
                    }
                    //no final aumenta um dia
                    dataInicial = dataInicial.AddDays(1);
                }
                //escrever os horarios que já existem e os novos horarios
                Horario HorarioFor = new Horario();
                int j, h;
                int numeroDeHorariosDepoisDaDataAtual = i - 1;
                for (j = 0; j < numeroDeHorariosDepoisDaDataAtual; j++)
                {
                    for (h = 0; h < numeroDeHorariosDepoisDaDataAtual; h++)
                    {
                        DateTime Data0 = DateTime.ParseExact(CriarHorariosMedicamento[h].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime Data1 = DateTime.ParseExact(CriarHorariosMedicamento[h + 1].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        if (DateTime.Compare(Data0, Data1) > 0)
                        {

                            HorarioFor = CriarHorariosMedicamento[h + 1];
                            CriarHorariosMedicamento[h + 1] = CriarHorariosMedicamento[h];
                            CriarHorariosMedicamento[h] = HorarioFor;
                        }
                    }
                }

                //escrever os horarios que já existem e os novos horarios
                int a;
                StreamWriter escritor = new StreamWriter("Horario.txt");
                for (a = 0; a < i; a++)
                {
                    escritor.WriteLine(CriarHorariosMedicamento[a].HoraToma + ";" + CriarHorariosMedicamento[a].Tipo + ";"
                        + CriarHorariosMedicamento[a]._Medicamento.nomeMedicamento + ";" + CriarHorariosMedicamento[a].TextoLembrete + ";"
                        + CriarHorariosMedicamento[a].TomouMedicamento + ";");


                }
                escritor.Close();

                return true;
            }
            else
            {
                return false;
            }

               

        }
        private bool gerarHorarioDoMedicamentoOpcao3()
        {
            Horario[] CriarHorarios = new Horario[20000];
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

            //verificar se não excede o número máximo de lembretes
            if(i + 1 < nMaximoLembretes - 1)
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


                Horario horarioAdicionar = new Horario();
                //preencher o novo lembrete
                horarioAdicionar.HoraToma = horaDaTomaDia2 + " " + HoraDaTomaHora1 + HoraDaTomaHora2;
                horarioAdicionar.Tipo = "Medicamento";
                horarioAdicionar._Medicamento.nomeMedicamento = textBoxNomeMedicamento.Text;
                horarioAdicionar.TextoLembrete = "null";
                horarioAdicionar.TomouMedicamento = "Pendente";
                //a função em baixo converte string para dateTime
                //DateTime Data = DateTime.ParseExact(CriarHorarios[i].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                //MessageBox.Show(Data.ToString());
                //escrever os horarios que já existem e o novo horario
                //escrever os horarios que já existem e os novos horarios

                //ordenar os horarios


                int a;
                bool jaEscreveu = false;
                DateTime dateLembrete = DateTime.ParseExact(horarioAdicionar.HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                StreamWriter escritor = new StreamWriter("Horario.txt");
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
                        if (a == (i - 1) && jaEscreveu == false)
                        {
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

        private bool verificarSeDataDaOpcao3EMaiorQueDataAtual()
        {
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

            string horaFinal = horaDaTomaDia2 + " " + HoraDaTomaHora1 + HoraDaTomaHora2;

            DateTime Data = DateTime.ParseExact(horaFinal, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            if(DateTime.Compare(Data, DateTime.Now) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void FormAdicionarMedicamento_Load(object sender, EventArgs e)
        {
           
        }
    }
}
