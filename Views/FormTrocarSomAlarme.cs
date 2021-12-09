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
    public partial class FormTrocarSomAlarme : Form
    {
        public FormTrocarSomAlarme()
        {
            InitializeComponent();
        }
        Pessoa pessoa = new Pessoa();
        public bool AlarmeTrocadoComSucesso = false;
        SoundPlayer AlarmeSound = new SoundPlayer();

        private void checkBoxAlarme1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAlarme2.Checked = false;
            checkBoxAlarme3.Checked = false;
            checkBoxAlarme4.Checked = false;
            checkBoxAlarme5.Checked = false;
        }

        private void checkBoxAlarme2_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAlarme1.Checked = false;
            checkBoxAlarme3.Checked = false;
            checkBoxAlarme4.Checked = false;
            checkBoxAlarme5.Checked = false;
        }

        private void checkBoxAlarme3_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAlarme1.Checked = false;
            checkBoxAlarme2.Checked = false;
            checkBoxAlarme4.Checked = false;
            checkBoxAlarme5.Checked = false;
        }

        private void checkBoxAlarme5_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAlarme1.Checked = false;
            checkBoxAlarme2.Checked = false;
            checkBoxAlarme3.Checked = false;
            checkBoxAlarme4.Checked = false;
        }

        private void checkBoxAlarme4_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAlarme1.Checked = false;
            checkBoxAlarme2.Checked = false;
            checkBoxAlarme3.Checked = false;
            checkBoxAlarme5.Checked = false;
        }

        private void pictureBoxAlarme1_Click(object sender, EventArgs e)
        {
            AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.Alarme1);
            AlarmeSound.Play();
        }

        private void pictureBoxAlarme2_Click(object sender, EventArgs e)
        {
            AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeGalo);
            AlarmeSound.Play();
        }

        private void pictureBoxAlarme3_Click(object sender, EventArgs e)
        {
            AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeEminem);
            AlarmeSound.Play();
        }

        private void pictureBoxAlarme4_Click(object sender, EventArgs e)
        {
            AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeTornado);
            AlarmeSound.Play();
        }

        private void pictureBoxAlarme5_Click(object sender, EventArgs e)
        {
            AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeStillDre);
            AlarmeSound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numeroOpcoesClicadas = 0;
            if (checkBoxAlarme1.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxAlarme2.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxAlarme3.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxAlarme4.Checked == true)
            {
                numeroOpcoesClicadas++;
            }
            if (checkBoxAlarme5.Checked == true)
            {
                numeroOpcoesClicadas++;
            }

            if (numeroOpcoesClicadas == 0)
            {
                MessageBox.Show("Tem de escolher uma opção(1, 2, 3, 4 ou 5)!!");
            }
            else
            {
                //troca o alarme
                TrocarAlarmeNoForm();
                AlarmeTrocadoComSucesso = true;
                MessageBox.Show("Alarme trocado com sucesso !!");
                AlarmeSound.Stop();
                this.Close();
            }
        }

        private void TrocarAlarmeNoForm()
        {
            if(checkBoxAlarme1.Checked == true)
            {
                pessoa.TrocarAlarme(1);
            }
            if (checkBoxAlarme2.Checked == true)
            {
                pessoa.TrocarAlarme(2);
            }
            if (checkBoxAlarme3.Checked == true)
            {
                pessoa.TrocarAlarme(3);
            }
            if (checkBoxAlarme4.Checked == true)
            {
                pessoa.TrocarAlarme(4);
            }
            if (checkBoxAlarme5.Checked == true)
            {
                pessoa.TrocarAlarme(5);
            }
        }

    }
}
