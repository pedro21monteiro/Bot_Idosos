using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Bot_Idosos.Views
{
    public partial class FormAjudaTextosAjuda : Form
    {
        SpeechSynthesizer speech;

        public FormAjudaTextosAjuda(int _texto)
        {
            InitializeComponent();
            Texto = _texto;
            speech = new SpeechSynthesizer();
        }
        public int Texto;
        public bool clicouVoltar = false;

        private void FormAjudaAdicionaLembrete_Load(object sender, EventArgs e)
        {

            if(Texto == 1)
            {
                textBox1.Text = "Insira novamente o nome do medicamento e procure-o na lista que lhe aparece selecionando-o."
             + Environment.NewLine
             + "De seguida escolha uma das opçoes e selecione/ escolha o horário e data."
             + Environment.NewLine   
             ;
            }if(Texto == 2)
            {
                textBox1.Text = "Seleciona o horário e a data pretendida e escreva o que quiser.";
            }
            if (Texto == 3)
            {
                textBox1.Text = "A medida que vai adicionando os medicamentos, é mostrado a percentagem ,de acordo com o mês em que o seu medicamento foi tomado.";
            }
            if (Texto == 4)
            {
                textBox1.Text = "1-Apagar os lembretes "
                    + Environment.NewLine
                    + "Tem como função apagar todos os lembretes adicionados"
                    + Environment.NewLine
                    + "2 - Apagar os lembretes de medicamentos"
                    + Environment.NewLine
                    + "Tem como função apagar todos os lembretes dos medicamentos adicionados até a data atual"
                    + Environment.NewLine
                    + "3 - Apagar os lembretes personalizados"
                    + Environment.NewLine
                    + "Tem como função apagar todos os lembretes personalizados"
                    + Environment.NewLine
                    + "4 - Apagar os lembretes antigos"
                    + Environment.NewLine
                    + "Tem como função apagar todos lembretes existentes anteriores à data atual";
            }

        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Speaking)
            {
                speech.Pause();
            }
            clicouVoltar = true;
            this.Close();
        }

        

        private void pictureBoxSom_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                speech.SelectVoice("Microsoft Maria Desktop");
                speech.SpeakAsync(textBox1.Text);
            }
        }

        private void pictureBoxPause_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Speaking)
            {
                speech.Pause();
            }
        }

        private void pictureBoxPlay_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Paused)
            {
                speech.Resume();
            }
        }
    }
}
