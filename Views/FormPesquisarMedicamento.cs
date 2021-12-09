using ClosedXML.Excel;
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
    public partial class FormPesquisarMedicamento : Form
    {
        public FormPesquisarMedicamento()
        {
            InitializeComponent();
        }

        private void buttonPesquisarMedicamento_Click(object sender, EventArgs e)
        {
            //limpar a list view
            listViewPesquisarMedicamento.Items.Clear();

            using (StreamReader leitor = new StreamReader("allPackages.txt"))
            {
                
                //  File.ReadAllLines("ContasJogoMinas.txt");
                bool MedicamentoExiste = false;
                int nMedicamentosComEsseNome = 0;
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

                    if(nMedicamento == textBoxNomePesquisarMedicamento.Text)
                    {
                        MedicamentoExiste = true;
                        


                        //listview
                        string[] pr = new string[100];
                        pr[0] = nRegisto;
                        pr[1] = substancia;
                        pr[2] = nMedicamento;
                        pr[3] = formafarmaceutica;
                        pr[4] = dosagem;
                        pr[5] = tamanhoEmbalagem;
                        pr[6] = CNPEM;
                        pr[7] = preco;
                        pr[8] = comerc;
                        pr[9] = generico;

                        ListViewItem novoItem = new ListViewItem(pr);
                        listViewPesquisarMedicamento.Items.Add(novoItem);

                        //atribuir cor cinza cor branca
                        if (nMedicamentosComEsseNome % 2 == 0)
                        {
                            //é par, meter a cinza
                            listViewPesquisarMedicamento.Items[nMedicamentosComEsseNome].BackColor = System.Drawing.Color.LightGray;
                        }

                        nMedicamentosComEsseNome++;
                    }
                }
                leitor.Close();
                if (MedicamentoExiste == false)
                {
                    MessageBox.Show("Não encontramos o medicamento que deseja!!!");
                }
                else
                {
                    if (nMedicamentosComEsseNome == 1)
                    {
                        MessageBox.Show("Medicamento encontrado com sucesso!!!");
                    }
                    if (nMedicamentosComEsseNome > 1)
                    {
                        MessageBox.Show("Foram encontrados "+ nMedicamentosComEsseNome + " medicamentos com esse nome!!!");
                    }

                }

            }

        }
    }
}
