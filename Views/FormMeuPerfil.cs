using Bot_Idosos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos.Views
{
    public partial class FormMeuPerfil : Form
    {
        public FormMeuPerfil()
        {
            InitializeComponent();
        }
        Pessoa pessoa = new Pessoa();
        SoundPlayer AlarmeSound = new SoundPlayer();

        private void FormMeuPerfil_Load(object sender, EventArgs e)
        {
            pessoa.AtualizarDadosPessoa();
            //preencher os parametros de escrita
            preencherOsParametros();
        }
     

        private void preencherOsParametros()
        {
            textBoxNome.Text = pessoa.Nome;
            textBoxApelido.Text = pessoa.Apelido;
            textBoxIdade.Text = pessoa.Idade.ToString();
            textBoxDataCriacaoConta.Text = pessoa.DataCriacaoConta.ToString().Remove(10, 9);
            if (pessoa.Foto == "default")
            {
                //imagem por default a anonima
                pictureBoxFotoEditar.Image = Bot_Idosos.Properties.Resources.anonimo;
            }
            else
            {
                pictureBoxFotoEditar.ImageLocation = pessoa.Foto;
            }
            //inicializar o som
            int nAlarme = pessoa.Alarme;

            if (nAlarme == 1)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.Alarme1);
            }
            if (nAlarme == 2)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeGalo);
            }
            if (nAlarme == 3)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeEminem);
            }
            if (nAlarme == 4)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeTornado);
            }
            if (nAlarme == 5)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeStillDre);
            }
            

        }

        private void pictureBoxAlarme_Click(object sender, EventArgs e)
        {
            AlarmeSound.Play();
        }
    }
}
