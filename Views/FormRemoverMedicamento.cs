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
    public partial class FormRemoverMedicamento : Form
    {
        public FormRemoverMedicamento()
        {
            InitializeComponent();
        }
        Medicamentos medicamentos = new Medicamentos();
        public bool RemoveuMedicamentoCorretamente = false;

        private void buttonRemoverMedicamento_Click(object sender, EventArgs e)
        {
            //aqui vamos ter de meter a ser obrigatorio meter um nome de um medicamento que exista
            if (medicamentos.MedicamentoExiste(textBoxNomeRemoverMedicamento.Text) == true)
            {

                //Aqui vai ser a remoção do medicamento do horario, o horario esta no ficheiro 
                medicamentos.removerMedicamentoDoHorario(textBoxNomeRemoverMedicamento.Text);
                RemoveuMedicamentoCorretamente = true;
                MessageBox.Show("Medicamento removido da agenda com sucesso !!!");
                this.Close();

            }
            else MessageBox.Show("Esse medicamento não existe!!");
        }

        
    }
}
