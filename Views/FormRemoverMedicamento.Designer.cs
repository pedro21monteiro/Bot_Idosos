
namespace Bot_Idosos.Views
{
    partial class FormRemoverMedicamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNomeRemoverMedicamento = new System.Windows.Forms.TextBox();
            this.buttonRemoverMedicamento = new System.Windows.Forms.Button();
            this.labelNomeUtilizador = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNomeRemoverMedicamento
            // 
            this.textBoxNomeRemoverMedicamento.Location = new System.Drawing.Point(78, 43);
            this.textBoxNomeRemoverMedicamento.Name = "textBoxNomeRemoverMedicamento";
            this.textBoxNomeRemoverMedicamento.Size = new System.Drawing.Size(142, 20);
            this.textBoxNomeRemoverMedicamento.TabIndex = 15;
            // 
            // buttonRemoverMedicamento
            // 
            this.buttonRemoverMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoverMedicamento.Location = new System.Drawing.Point(128, 77);
            this.buttonRemoverMedicamento.Name = "buttonRemoverMedicamento";
            this.buttonRemoverMedicamento.Size = new System.Drawing.Size(92, 32);
            this.buttonRemoverMedicamento.TabIndex = 13;
            this.buttonRemoverMedicamento.Text = "Remover";
            this.buttonRemoverMedicamento.UseVisualStyleBackColor = true;
            this.buttonRemoverMedicamento.Click += new System.EventHandler(this.buttonRemoverMedicamento_Click);
            // 
            // labelNomeUtilizador
            // 
            this.labelNomeUtilizador.AutoSize = true;
            this.labelNomeUtilizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeUtilizador.Location = new System.Drawing.Point(12, 41);
            this.labelNomeUtilizador.Name = "labelNomeUtilizador";
            this.labelNomeUtilizador.Size = new System.Drawing.Size(60, 20);
            this.labelNomeUtilizador.TabIndex = 10;
            this.labelNomeUtilizador.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(497, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Insira o nome do Medicamento que quer tirar da sua agenda:";
            // 
            // FormRemoverMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 121);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNomeRemoverMedicamento);
            this.Controls.Add(this.buttonRemoverMedicamento);
            this.Controls.Add(this.labelNomeUtilizador);
            this.Name = "FormRemoverMedicamento";
            this.Text = "Remover Medicamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeRemoverMedicamento;
        private System.Windows.Forms.Button buttonRemoverMedicamento;
        private System.Windows.Forms.Label labelNomeUtilizador;
        private System.Windows.Forms.Label label3;
    }
}