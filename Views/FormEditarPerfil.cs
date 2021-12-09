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
    public partial class FormEditarPerfil : Form
    {
        


        public FormEditarPerfil()
        {
            InitializeComponent();
        }
        public bool PerfilEditadoCorretamente = false;
        Pessoa pessoa = new Pessoa();
        //--
        public static string Caminho = System.Environment.CurrentDirectory;
        public static string CaminhoFotos = Caminho + @"\Fotos\";
        //---
        string origemCompleto = "";
        string foto = "";
        string pastaDestino = CaminhoFotos;
        string destinoCompleto = "";

        public void EditarAContaEmFicheiro()
        {
            //escrever a conta editada
            pessoa.Nome = textBoxNomeFormEditarPerfil.Text;
            pessoa.Apelido = textBoxApelidoFormEditarPerfil.Text;
            pessoa.Idade = Convert.ToInt32(numericUpDownIdadeIdadeFormEditarPerfil.Value);

            StreamWriter escritor = new StreamWriter("Contas.txt");
            escritor.WriteLine(pessoa.Nome + ";" + pessoa.Apelido + ";" + pessoa.Idade.ToString() + ";" + pessoa.DataCriacaoConta.ToString().Remove(10, 9) + ";"
                + pessoa.Alarme.ToString() +";" + pessoa.Foto + ";");
            escritor.Close();
        }
        private void buttonEditarFormEditarPerfil_Click(object sender, EventArgs e)
        {
            if (textBoxNomeFormEditarPerfil.Text.Length >= 3)
            {
                if (textBoxApelidoFormEditarPerfil.Text.Length >= 3)
                {
                    if (numericUpDownIdadeIdadeFormEditarPerfil.Value >= 0 || numericUpDownIdadeIdadeFormEditarPerfil.Value <= 140)
                    {

                        if (destinoCompleto == "" && pessoa.Foto == "default") //não existe
                        {

                            if (MessageBox.Show("Sem foto selecionada , deseja continuar ?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        if (destinoCompleto != "" )
                        {
                            System.IO.File.Copy(origemCompleto, destinoCompleto, true);
                            if (File.Exists(destinoCompleto))//verifica se foi copiado
                            {
                                pictureBoxFotoEditar.ImageLocation = destinoCompleto;
                                pessoa.Foto = destinoCompleto;
                            }
                            else
                            {
                                if (MessageBox.Show("Erro a localizar foto , deseja continuar ?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                        //se chega a esta parte vai poder criar a conta de 2 maneiras, com a imagem default ou com propria imagem
                        if (destinoCompleto == "")
                        {
                            EditarAContaEmFicheiro();//conta criada com imagem default
                        }
                        else
                        {
                            EditarAContaEmFicheiro();//conta criad com imagem personalizada
                        }
                        PerfilEditadoCorretamente = true;
                        MessageBox.Show("Conta editada com sucesso !!!");
                        //no final de fazer o registo abre a view principal e fecha a view de registo
                        this.Close();
                    }
                    else MessageBox.Show("Insira uma idade valida");
                }
                else MessageBox.Show("Apelido tem de ter no minimo 3 caracteres");
            }
            else MessageBox.Show("Nome tem de ter no minimo 3 caracteres");
        }

        private void FormEditarPerfil_Load(object sender, EventArgs e)
        {
            //a dar load atualizar a pessoa
            pessoa.AtualizarDadosPessoa();
            //preencher os parametros de escrita
            preencherOsParametros();
        }
        private void preencherOsParametros()
        {
            textBoxNomeFormEditarPerfil.Text = pessoa.Nome;
            textBoxApelidoFormEditarPerfil.Text = pessoa.Apelido;
            numericUpDownIdadeIdadeFormEditarPerfil.Value = pessoa.Idade;
            if (pessoa.Foto == "default")
            {
                //imagem por default a anonima
                pictureBoxFotoEditar.Image = Bot_Idosos.Properties.Resources.anonimo;
            }
            else
            {
                pictureBoxFotoEditar.ImageLocation = pessoa.Foto;
            }

        }

        private void buttonAdicionarFotoPerfil_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//se o ficheiro foi submetido com sucesso
            {
                origemCompleto = openFileDialog1.FileName;//Filename retorna caminho completo e nome do arquivo
                foto = openFileDialog1.SafeFileName;//savefilename só pega o nome do arquivo
                destinoCompleto = pastaDestino + foto;

            }
            if (File.Exists(destinoCompleto))//verificar se o file destino existe
            {
                if (MessageBox.Show("Arquivo já existe desja substituir ?", "Substituir", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            pictureBoxFotoEditar.ImageLocation = origemCompleto;
            pessoa.Foto = origemCompleto;
        }

        private void buttonRemoverFoto_Click(object sender, EventArgs e)
        {
            pessoa.Foto = "default";
            pictureBoxFotoEditar.Image = Bot_Idosos.Properties.Resources.anonimo;
        }

        private void pictureBoxMicroNome_Click(object sender, EventArgs e)
        {
            
        }
    }
}
