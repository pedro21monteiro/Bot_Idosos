
namespace Bot_Idosos.Views
{
    partial class FormMenuAjuda
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
            this.labelPrecisaAjuda = new System.Windows.Forms.Label();
            this.buttonProblemasLembrete = new System.Windows.Forms.Button();
            this.buttonAjudaEditarLembrete = new System.Windows.Forms.Button();
            this.buttonAjudaEstatisticas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPrecisaAjuda
            // 
            this.labelPrecisaAjuda.AutoSize = true;
            this.labelPrecisaAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecisaAjuda.Location = new System.Drawing.Point(19, 19);
            this.labelPrecisaAjuda.Name = "labelPrecisaAjuda";
            this.labelPrecisaAjuda.Size = new System.Drawing.Size(192, 18);
            this.labelPrecisaAjuda.TabIndex = 0;
            this.labelPrecisaAjuda.Text = ",Com que precisa de ajuda?";
            // 
            // buttonProblemasLembrete
            // 
            this.buttonProblemasLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProblemasLembrete.Location = new System.Drawing.Point(22, 54);
            this.buttonProblemasLembrete.Name = "buttonProblemasLembrete";
            this.buttonProblemasLembrete.Size = new System.Drawing.Size(260, 23);
            this.buttonProblemasLembrete.TabIndex = 1;
            this.buttonProblemasLembrete.Text = "Problemas a adicionar lembrete";
            this.buttonProblemasLembrete.UseVisualStyleBackColor = true;
            this.buttonProblemasLembrete.Click += new System.EventHandler(this.buttonProblemasLembrete_Click);
            // 
            // buttonAjudaEditarLembrete
            // 
            this.buttonAjudaEditarLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjudaEditarLembrete.Location = new System.Drawing.Point(22, 94);
            this.buttonAjudaEditarLembrete.Name = "buttonAjudaEditarLembrete";
            this.buttonAjudaEditarLembrete.Size = new System.Drawing.Size(260, 23);
            this.buttonAjudaEditarLembrete.TabIndex = 2;
            this.buttonAjudaEditarLembrete.Text = "Problemas a editar lembrete";
            this.buttonAjudaEditarLembrete.UseVisualStyleBackColor = true;
            this.buttonAjudaEditarLembrete.Click += new System.EventHandler(this.buttonAjudaEditarLembrete_Click);
            // 
            // buttonAjudaEstatisticas
            // 
            this.buttonAjudaEstatisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjudaEstatisticas.Location = new System.Drawing.Point(22, 133);
            this.buttonAjudaEstatisticas.Name = "buttonAjudaEstatisticas";
            this.buttonAjudaEstatisticas.Size = new System.Drawing.Size(260, 23);
            this.buttonAjudaEstatisticas.TabIndex = 3;
            this.buttonAjudaEstatisticas.Text = "Para que serve as estatisticas?";
            this.buttonAjudaEstatisticas.UseVisualStyleBackColor = true;
            this.buttonAjudaEstatisticas.Click += new System.EventHandler(this.buttonAjudaEstatisticas_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(22, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Preciso ajuda a apagar lembretes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMenuAjuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 217);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAjudaEstatisticas);
            this.Controls.Add(this.buttonAjudaEditarLembrete);
            this.Controls.Add(this.buttonProblemasLembrete);
            this.Controls.Add(this.labelPrecisaAjuda);
            this.Name = "FormMenuAjuda";
            this.Text = "Ajuda";
            this.Load += new System.EventHandler(this.FormMenuAjuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrecisaAjuda;
        private System.Windows.Forms.Button buttonProblemasLembrete;
        private System.Windows.Forms.Button buttonAjudaEditarLembrete;
        private System.Windows.Forms.Button buttonAjudaEstatisticas;
        private System.Windows.Forms.Button button1;
    }
}