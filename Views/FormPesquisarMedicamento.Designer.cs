
namespace Bot_Idosos.Views
{
    partial class FormPesquisarMedicamento
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNomePesquisarMedicamento = new System.Windows.Forms.TextBox();
            this.buttonPesquisarMedicamento = new System.Windows.Forms.Button();
            this.labelNomeUtilizador = new System.Windows.Forms.Label();
            this.listViewPesquisarMedicamento = new System.Windows.Forms.ListView();
            this.columnHeaderNRegisto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubstancia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDossagem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmbalagem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCNPEM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderComercio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGenerico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFormaFarmaceutica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Insira o nome do Medicamento que quer pesquisar:\r\n";
            // 
            // textBoxNomePesquisarMedicamento
            // 
            this.textBoxNomePesquisarMedicamento.Location = new System.Drawing.Point(78, 43);
            this.textBoxNomePesquisarMedicamento.Name = "textBoxNomePesquisarMedicamento";
            this.textBoxNomePesquisarMedicamento.Size = new System.Drawing.Size(142, 20);
            this.textBoxNomePesquisarMedicamento.TabIndex = 20;
            // 
            // buttonPesquisarMedicamento
            // 
            this.buttonPesquisarMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPesquisarMedicamento.Location = new System.Drawing.Point(246, 41);
            this.buttonPesquisarMedicamento.Name = "buttonPesquisarMedicamento";
            this.buttonPesquisarMedicamento.Size = new System.Drawing.Size(92, 32);
            this.buttonPesquisarMedicamento.TabIndex = 19;
            this.buttonPesquisarMedicamento.Text = "Pesquisar";
            this.buttonPesquisarMedicamento.UseVisualStyleBackColor = true;
            this.buttonPesquisarMedicamento.Click += new System.EventHandler(this.buttonPesquisarMedicamento_Click);
            // 
            // labelNomeUtilizador
            // 
            this.labelNomeUtilizador.AutoSize = true;
            this.labelNomeUtilizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeUtilizador.Location = new System.Drawing.Point(12, 41);
            this.labelNomeUtilizador.Name = "labelNomeUtilizador";
            this.labelNomeUtilizador.Size = new System.Drawing.Size(60, 20);
            this.labelNomeUtilizador.TabIndex = 18;
            this.labelNomeUtilizador.Text = "Nome:";
            // 
            // listViewPesquisarMedicamento
            // 
            this.listViewPesquisarMedicamento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNRegisto,
            this.columnHeaderSubstancia,
            this.columnHeaderNome,
            this.columnHeaderFormaFarmaceutica,
            this.columnHeaderDossagem,
            this.columnHeaderEmbalagem,
            this.columnHeaderCNPEM,
            this.columnHeaderPreco,
            this.columnHeaderComercio,
            this.columnHeaderGenerico});
            this.listViewPesquisarMedicamento.HideSelection = false;
            this.listViewPesquisarMedicamento.Location = new System.Drawing.Point(16, 79);
            this.listViewPesquisarMedicamento.Name = "listViewPesquisarMedicamento";
            this.listViewPesquisarMedicamento.Size = new System.Drawing.Size(927, 276);
            this.listViewPesquisarMedicamento.TabIndex = 23;
            this.listViewPesquisarMedicamento.UseCompatibleStateImageBehavior = false;
            this.listViewPesquisarMedicamento.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNRegisto
            // 
            this.columnHeaderNRegisto.Text = "Número Registo";
            this.columnHeaderNRegisto.Width = 116;
            // 
            // columnHeaderSubstancia
            // 
            this.columnHeaderSubstancia.Text = "Substância";
            this.columnHeaderSubstancia.Width = 95;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome Medicamento";
            this.columnHeaderNome.Width = 129;
            // 
            // columnHeaderDossagem
            // 
            this.columnHeaderDossagem.Text = "Dossagem";
            this.columnHeaderDossagem.Width = 99;
            // 
            // columnHeaderEmbalagem
            // 
            this.columnHeaderEmbalagem.Text = "Embalagem";
            this.columnHeaderEmbalagem.Width = 94;
            // 
            // columnHeaderCNPEM
            // 
            this.columnHeaderCNPEM.Text = "CNPEM";
            this.columnHeaderCNPEM.Width = 79;
            // 
            // columnHeaderPreco
            // 
            this.columnHeaderPreco.Text = "Preço";
            this.columnHeaderPreco.Width = 65;
            // 
            // columnHeaderComercio
            // 
            this.columnHeaderComercio.Text = "Comercio";
            this.columnHeaderComercio.Width = 72;
            // 
            // columnHeaderGenerico
            // 
            this.columnHeaderGenerico.Text = "Genérico";
            this.columnHeaderGenerico.Width = 112;
            // 
            // columnHeaderFormaFarmaceutica
            // 
            this.columnHeaderFormaFarmaceutica.Text = "Forma Farmaceutica";
            this.columnHeaderFormaFarmaceutica.Width = 116;
            // 
            // FormPesquisarMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 367);
            this.Controls.Add(this.listViewPesquisarMedicamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNomePesquisarMedicamento);
            this.Controls.Add(this.buttonPesquisarMedicamento);
            this.Controls.Add(this.labelNomeUtilizador);
            this.Name = "FormPesquisarMedicamento";
            this.Text = "Pesquisar Medicamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNomePesquisarMedicamento;
        private System.Windows.Forms.Button buttonPesquisarMedicamento;
        private System.Windows.Forms.Label labelNomeUtilizador;
        private System.Windows.Forms.ListView listViewPesquisarMedicamento;
        private System.Windows.Forms.ColumnHeader columnHeaderNRegisto;
        private System.Windows.Forms.ColumnHeader columnHeaderSubstancia;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderDossagem;
        private System.Windows.Forms.ColumnHeader columnHeaderEmbalagem;
        private System.Windows.Forms.ColumnHeader columnHeaderCNPEM;
        private System.Windows.Forms.ColumnHeader columnHeaderPreco;
        private System.Windows.Forms.ColumnHeader columnHeaderComercio;
        private System.Windows.Forms.ColumnHeader columnHeaderGenerico;
        private System.Windows.Forms.ColumnHeader columnHeaderFormaFarmaceutica;
    }
}