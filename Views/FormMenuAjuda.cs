using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos.Views
{
    public partial class FormMenuAjuda : Form
    {
        public FormMenuAjuda(string _nome)
        {
            InitializeComponent();
            Nome = _nome;
        }
        public string Nome;

        private void FormMenuAjuda_Load(object sender, EventArgs e)
        {
            labelPrecisaAjuda.Text = Nome + " ,Com que precisa de ajuda?";
        }

        private void buttonProblemasLembrete_Click(object sender, EventArgs e)
        {
            Hide();
            FormAjudaTextosAjuda f1 = new FormAjudaTextosAjuda(1);
            f1.ShowDialog();
            if(f1.clicouVoltar == true)
            {
                Show();
            }
            else
            {
                this.Close();
            }
            
        }

        private void buttonAjudaEditarLembrete_Click(object sender, EventArgs e)
        {
            Hide();
            FormAjudaTextosAjuda f1 = new FormAjudaTextosAjuda(2);
            f1.ShowDialog();
            if (f1.clicouVoltar == true)
            {
                Show();
            }
            else
            {
                this.Close();
            }
        }

        private void buttonAjudaEstatisticas_Click(object sender, EventArgs e)
        {
            Hide();
            FormAjudaTextosAjuda f1 = new FormAjudaTextosAjuda(3);
            f1.ShowDialog();
            if (f1.clicouVoltar == true)
            {
                Show();
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormAjudaTextosAjuda f1 = new FormAjudaTextosAjuda(4);
            f1.ShowDialog();
            if (f1.clicouVoltar == true)
            {
                Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
