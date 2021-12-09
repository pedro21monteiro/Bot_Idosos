
namespace Bot_Idosos.Views
{
    partial class FormEstatisticas
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
            this.listViewEstatisticas = new System.Windows.Forms.ListView();
            this.columnHeaderTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNomeMedicamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTomados = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNaoTomados = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmEspera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPercentagemDeToma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.labelMes = new System.Windows.Forms.Label();
            this.buttonAnterior = new System.Windows.Forms.Button();
            this.buttonProximo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewEstatisticas
            // 
            this.listViewEstatisticas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTotal,
            this.columnHeaderNomeMedicamento,
            this.columnHeaderTomados,
            this.columnHeaderNaoTomados,
            this.columnHeaderEmEspera,
            this.columnHeaderPercentagemDeToma});
            this.listViewEstatisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEstatisticas.FullRowSelect = true;
            this.listViewEstatisticas.HideSelection = false;
            this.listViewEstatisticas.Location = new System.Drawing.Point(36, 66);
            this.listViewEstatisticas.MultiSelect = false;
            this.listViewEstatisticas.Name = "listViewEstatisticas";
            this.listViewEstatisticas.Size = new System.Drawing.Size(850, 234);
            this.listViewEstatisticas.TabIndex = 0;
            this.listViewEstatisticas.UseCompatibleStateImageBehavior = false;
            this.listViewEstatisticas.View = System.Windows.Forms.View.Details;
            this.listViewEstatisticas.SelectedIndexChanged += new System.EventHandler(this.listViewEstatisticas_SelectedIndexChanged);
            // 
            // columnHeaderTotal
            // 
            this.columnHeaderTotal.Text = "";
            // 
            // columnHeaderNomeMedicamento
            // 
            this.columnHeaderNomeMedicamento.Text = "Nome Medicamento";
            this.columnHeaderNomeMedicamento.Width = 191;
            // 
            // columnHeaderTomados
            // 
            this.columnHeaderTomados.Text = "Tomados";
            this.columnHeaderTomados.Width = 126;
            // 
            // columnHeaderNaoTomados
            // 
            this.columnHeaderNaoTomados.Text = "Não tomados";
            this.columnHeaderNaoTomados.Width = 137;
            // 
            // columnHeaderEmEspera
            // 
            this.columnHeaderEmEspera.Text = "Em espera";
            this.columnHeaderEmEspera.Width = 119;
            // 
            // columnHeaderPercentagemDeToma
            // 
            this.columnHeaderPercentagemDeToma.Text = "Percentagem de toma";
            this.columnHeaderPercentagemDeToma.Width = 195;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estatísticas dos meus medicamentos por mês:";
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMes.Location = new System.Drawing.Point(117, 45);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(37, 18);
            this.labelMes.TabIndex = 2;
            this.labelMes.Text = "Mês";
            // 
            // buttonAnterior
            // 
            this.buttonAnterior.Location = new System.Drawing.Point(36, 40);
            this.buttonAnterior.Name = "buttonAnterior";
            this.buttonAnterior.Size = new System.Drawing.Size(75, 23);
            this.buttonAnterior.TabIndex = 3;
            this.buttonAnterior.Text = "Anterior";
            this.buttonAnterior.UseVisualStyleBackColor = true;
            this.buttonAnterior.Click += new System.EventHandler(this.buttonAnterior_Click);
            // 
            // buttonProximo
            // 
            this.buttonProximo.Location = new System.Drawing.Point(227, 40);
            this.buttonProximo.Name = "buttonProximo";
            this.buttonProximo.Size = new System.Drawing.Size(75, 23);
            this.buttonProximo.TabIndex = 4;
            this.buttonProximo.Text = "Proximo";
            this.buttonProximo.UseVisualStyleBackColor = true;
            this.buttonProximo.Click += new System.EventHandler(this.buttonProximo_Click);
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 323);
            this.Controls.Add(this.buttonProximo);
            this.Controls.Add(this.buttonAnterior);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewEstatisticas);
            this.Name = "FormEstatisticas";
            this.Text = "Estatísticas";
            this.Load += new System.EventHandler(this.FormEstatisticas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewEstatisticas;
        private System.Windows.Forms.ColumnHeader columnHeaderNomeMedicamento;
        private System.Windows.Forms.ColumnHeader columnHeaderTomados;
        private System.Windows.Forms.ColumnHeader columnHeaderEmEspera;
        private System.Windows.Forms.ColumnHeader columnHeaderNaoTomados;
        private System.Windows.Forms.ColumnHeader columnHeaderPercentagemDeToma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeaderTotal;
        private System.Windows.Forms.Label labelMes;
        private System.Windows.Forms.Button buttonAnterior;
        private System.Windows.Forms.Button buttonProximo;
    }
}