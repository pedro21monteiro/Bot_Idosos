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

using System.Speech.Synthesis;//sintetizador de voz


namespace Bot_Idosos.Views
{
    public partial class FormRegistar : Form
    {
        public FormRegistar()
        {
            InitializeComponent();
        }
        public bool ContaCriadaCorretamente = false;
        public static string Caminho = System.Environment.CurrentDirectory;
        public static string CaminhoFotos = Caminho + @"\Fotos\";
        //---
        string origemCompleto = "";
        string foto = "";
        string pastaDestino = CaminhoFotos;
        string destinoCompleto = "";

        //sintetizador de voz
        SpeechSynthesizer sintetizadorDeVoz = new SpeechSynthesizer();

        public void CriarAContaEmFicheiro(int _tipoFoto)//0- default, 1- foto inserida pelo utilizador
        {
            string nome = textBoxNomeRegistar.Text;
            string apelido = textBoxApelidoRegistar.Text;
            string idadeString = numericUpDownIdadeRegistar.Value.ToString();
            //o d dentro do toString faz com que não meta as horas , apenas a data
            string dataRegistoString = DateTime.Today.ToString("d");
            //escrever a conta criada
            StreamWriter escritor = new StreamWriter("Contas.txt");
            if(_tipoFoto == 0)
            {
                escritor.WriteLine(nome + ";" + apelido + ";" + idadeString + ";" + dataRegistoString + ";" + "1;"+"default;");
            }
            if(_tipoFoto == 1)
            {
                escritor.WriteLine(nome + ";" + apelido + ";" + idadeString + ";" + dataRegistoString + ";" + "1;" + destinoCompleto +";");
            }
           
            //1 por o alarme por default é 1
            escritor.Close();
        }
        private void buttonRegistar_Click(object sender, EventArgs e)
        {
            if (textBoxNomeRegistar.Text.Length >= 3)
            {
                if (textBoxApelidoRegistar.Text.Length >= 3)
                {
                    if (numericUpDownIdadeRegistar.Value >= 0 || numericUpDownIdadeRegistar.Value <= 140)
                    {
                        //verificar se ele meteu foto
                        if (destinoCompleto == "") //não existe
                        { 
                         
                            if (MessageBox.Show("Sem foto selecionada , deseja continuar ?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                             return;
                            }
                        }
                        if (destinoCompleto != "")
                        {
                            System.IO.File.Copy(origemCompleto, destinoCompleto, true);
                            if (File.Exists(destinoCompleto))//verifica se foi copiado
                            {
                                pictureBoxFotoRegistar.ImageLocation = destinoCompleto;
                            }
                            else
                            {
                                if(MessageBox.Show("Erro a localizar foto , deseja continuar ?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                        //se chega a esta parte vai poder criar a conta de 2 maneiras, com a imagem default ou com propria imagem
                        if (destinoCompleto == "")
                        {
                            CriarAContaEmFicheiro(0);//conta criada com imagem default
                        }
                        else
                        {
                            CriarAContaEmFicheiro(1);//conta criad com imagem personalizada
                        }
                        ContaCriadaCorretamente = true;
                        MessageBox.Show("Conta criada com sucesso !!!");
                        //no final de fazer o registo abre a view principal e fecha a view de registo
                        this.Close();

                    }
                    else MessageBox.Show("Insira uma idade valida");
                }
                else MessageBox.Show("Apelido tem de ter no minimo 3 caracteres");
            }
            else MessageBox.Show("Nome tem de ter no minimo 3 caracteres");

        }

        private void buttonAdicionarFotoRegistar_Click(object sender, EventArgs e)
        {
            //Video parte1
            //https://www.youtube.com/watch?v=8zzLV09UoyU
            //Video parte2
            //https://www.youtube.com/watch?v=wM4awxPNZNs

           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//se o ficheiro foi submetido com sucesso
            {
                origemCompleto = openFileDialog1.FileName;//Filename retorna caminho completo e nome do arcivo
                foto = openFileDialog1.SafeFileName;//savefilename só pega o nome do arquivo
                destinoCompleto = pastaDestino + foto;

            }
            if (File.Exists(destinoCompleto))//verificar se o file destino existe
            {
                if(MessageBox.Show("Arquivo já existe desja substituir ?", "Substituir", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }                      
            }
            pictureBoxFotoRegistar.ImageLocation = origemCompleto;
            //pictureBoxFotoRegistar.ImageLocation = destinoCompleto;

            //System.IO.File.Copy(origemCompleto, destinoCompleto, true);
            //if (File.Exists(destinoCompleto))//verifica se foi copiado
            //{
            //    pictureBoxFotoRegistar.ImageLocation = destinoCompleto;
            //}
            //else
            //{
            //    MessageBox.Show("Arquivo não copiado");
            //}
        }
    }
}
