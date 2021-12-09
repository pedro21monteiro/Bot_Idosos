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
    public partial class FormEstatisticas : Form
    {
        public FormEstatisticas()
        {
            InitializeComponent();
        }
        private DateTime Hoje;
        

        
        private void FormEstatisticas_Load(object sender, EventArgs e)
        {
            //Vai entrar a data de hoje
            Hoje = DateTime.Now;
           AtualizarListBoxEstatisticas(Hoje);
        }

        private void AtualizarListBoxEstatisticas(DateTime date)
        {
            listViewEstatisticas.Items.Clear();
            Estatisticas[] VetorEstatisticas = new Estatisticas[100];//meti cem, depois meto um limite de 100 medicamentos

            //buscar o mes e o ano de hoje
            string dataHoje = date.ToString().Remove(10, 9);
            string mesAno = dataHoje.Remove(0, 3);


            //Atribuir mes à label
            string mes = mesAno.Remove(2, 5);
            if(mes == "01")
            {
                labelMes.Text = "Janeiro";
            }
            if (mes == "02")
            {
                labelMes.Text = "Fevereiro";
            }
            if (mes == "03")
            {
                labelMes.Text = "Março";
            }
            if (mes == "04")
            {
                labelMes.Text = "Abril";
            }
            if (mes == "05")
            {
                labelMes.Text = "Maio";
            }
            if (mes == "06")
            {
                labelMes.Text = "Junho";
            }
            if (mes == "07")
            {
                labelMes.Text = "Julho";
            }
            if (mes == "08")
            {
                labelMes.Text = "Agosto";
            }
            if (mes == "09")
            {
                labelMes.Text = "Setembro";
            }
            if (mes == "10")
            {
                labelMes.Text = "Outubro";
            }
            if (mes == "11")
            {
                labelMes.Text = "Novembro";
            }
            if (mes == "12")
            {
                labelMes.Text = "Dezembro";
            }
            //adicionaar o ano
            labelMes.Text = labelMes.Text + "/" + Hoje.Year.ToString();

            int i = 0;//vai guardar quantos medicamentos existem
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');
                    //só vai procurar pelo mes de hoje

                    string dataFicheiro = valores[0].Remove(10, 9);//vlores 0 é data toma
                    string mesAnoFicheiro = dataFicheiro.Remove(0, 3);
                    if (mesAno == mesAnoFicheiro)
                    {
                        //aqui esta as 4 parcelas que existem no horario
                        //passar a data em string para datetime

                        if (i == 0 && valores[2] != "null")//quer dizer que ainda não existe nenhum medicamentos
                        {
                            //para ver o que é cada valores[i]
                            //CriarHorarios[i] = new Horario();
                            ////CriarHorarios[i].HoraToma = valores[0]; nao é necessario
                            //CriarHorarios[i].Tipo = valores[1];// verificar se é medicamento
                            //CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                            //CriarHorarios[i].TextoLembrete = valores[3];
                            //CriarHorarios[i].TomouMento = valores[4];edicam
                            //i++;
                            //vai guardar o 1º nome de medicamento
                            VetorEstatisticas[i] = new Estatisticas();
                            VetorEstatisticas[i].NomeMedicamento = valores[2];
                            VetorEstatisticas[i].Tomados = 0;
                            VetorEstatisticas[i].Espera = 0;
                            VetorEstatisticas[i].NaoTomados = 0;

                            if (valores[4] == "Sim") //valores 4 é o tomou medicamento
                            {
                                VetorEstatisticas[i].Tomados++;
                            }
                            if (valores[4] == "Pendente") //valores 4 é o tomou medicamento
                            {
                                VetorEstatisticas[i].Espera++;
                            }
                            if (valores[4] == "Nao") //valores 4 é o tomou medicamento
                            {
                                VetorEstatisticas[i].NaoTomados++;
                            }
                            //no final aumentasse o i o que quer dizer que já existe 1
                            i++;
                        }
                        else     //se for maior que 0
                        {
                            //vai ler todas as posições e vai ver se alguma tem o nome igual

                            bool medicamentoComMesmoNome = false;
                            for (int j = 0; j < i; j++)
                            {
                                //verificar se tem algum elemento no vetor estatistica com o nome igual
                                if (VetorEstatisticas[j].NomeMedicamento == valores[2])
                                {
                                    medicamentoComMesmoNome = true;
                                    //vai guardar aqueles valores naquele medicamento
                                    if (valores[4] == "Sim") //valores 4 é o tomou medicamento
                                    {
                                        VetorEstatisticas[j].Tomados++;
                                    }
                                    if (valores[4] == "Pendente") //valores 4 é o tomou medicamento
                                    {
                                        VetorEstatisticas[j].Espera++;
                                    }
                                    if (valores[4] == "Nao") //valores 4 é o tomou medicamento
                                    {
                                        VetorEstatisticas[j].NaoTomados++;
                                    }
                                }
                            }
                            //no final do ciclo for se não encontrar nenhum medicamento com o mesmo nome vai
                            //adicionar esse medicamento
                            if (medicamentoComMesmoNome == false && valores[2] != "null")//ver se não é medicamento
                            {
                                //adicionar esse medicamento
                                VetorEstatisticas[i] = new Estatisticas();
                                VetorEstatisticas[i].NomeMedicamento = valores[2];
                                VetorEstatisticas[i].Tomados = 0;
                                VetorEstatisticas[i].Espera = 0;
                                VetorEstatisticas[i].NaoTomados = 0;

                                if (valores[4] == "Sim") //valores 4 é o tomou medicamento
                                {
                                    VetorEstatisticas[i].Tomados++;
                                }
                                if (valores[4] == "Pendente") //valores 4 é o tomou medicamento
                                {
                                    VetorEstatisticas[i].Espera++;
                                }
                                if (valores[4] == "Nao") //valores 4 é o tomou medicamento
                                {
                                    VetorEstatisticas[i].NaoTomados++;
                                }
                                //no final aumentasse o i o que quer dizer que já existe 1
                                i++;
                            }
                        }
                    }                  
                }
                leitor.Close();
            }
            //no final vou criar no vetor estatisticas o total

            int totalTomados = 0, totalNaoTomados = 0, totalEspera = 0;
            for (int j = 0; j < i; j++)
            {
                totalTomados = totalTomados + VetorEstatisticas[j].Tomados;
                totalNaoTomados = totalNaoTomados + VetorEstatisticas[j].NaoTomados;
                totalEspera = totalEspera + VetorEstatisticas[j].Espera;
                
            }
            VetorEstatisticas[i] = new Estatisticas();
            VetorEstatisticas[i].NomeMedicamento = (i).ToString();//i numero de medicamentos que existem nas estatisticas
            VetorEstatisticas[i].Tomados = totalTomados;
            VetorEstatisticas[i].NaoTomados = totalNaoTomados;
            VetorEstatisticas[i].Espera = totalEspera;
            i++;

            //no final vou preencher o listbox
            string[] pr = new string[100];
            for(int j = 0; j < i; j++)
            {
                if(j != (i - 1))//se não for o total
                {
                    pr[0] = ""; //nada espaço do total
                  
                }
                else//se for o total
                {
                    pr[0] = "Total:";
                }
                pr[1] = VetorEstatisticas[j].NomeMedicamento;
                pr[2] = VetorEstatisticas[j].Tomados.ToString();
                pr[3] = VetorEstatisticas[j].NaoTomados.ToString();
                pr[4] = VetorEstatisticas[j].Espera.ToString();
                double percentagem;
               
                //se ainda estao todos em espera a toma de medicamento fica a 100%
                if(VetorEstatisticas[j].Tomados == 0 && VetorEstatisticas[j].NaoTomados == 0)
                {
                    percentagem = 100;
                }
                else
                {
                    percentagem = ((Convert.ToDouble(VetorEstatisticas[j].Tomados)) /
                   (Convert.ToDouble(VetorEstatisticas[j].Tomados) + Convert.ToDouble(VetorEstatisticas[j].NaoTomados))) * 100;
                }
               
                
                pr[5] = percentagem.ToString("F") + " %";

                //adicionar o item
                ListViewItem novoItem = new ListViewItem(pr);
                listViewEstatisticas.Items.Add(novoItem);


                //atribuir cor cinza e branco entre as tabelas
                if (j % 2 == 0)
                {
                    //é par, meter a cinza
                    listViewEstatisticas.Items[j].BackColor = System.Drawing.Color.LightGray;
                }
            }
           
        }

        private void listViewEstatisticas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonProximo_Click(object sender, EventArgs e)
        {
            Hoje = Hoje.AddMonths(1);
            AtualizarListBoxEstatisticas(Hoje);
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            Hoje = Hoje.AddMonths(-1);
            AtualizarListBoxEstatisticas(Hoje);
        }
    }
}


   