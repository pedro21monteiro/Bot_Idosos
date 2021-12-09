
namespace Bot_Idosos.Views
{
    partial class FormAdicionarLembrete
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
            this.labelDataLembrete = new System.Windows.Forms.Label();
            this.dateTimePickerDataLembrete = new System.Windows.Forms.DateTimePicker();
            this.textBoxTextoLembrete = new System.Windows.Forms.TextBox();
            this.buttonAdicionarLembrete = new System.Windows.Forms.Button();
            this.labelHorasLembrete = new System.Windows.Forms.Label();
            this.numericUpDownHorasLembrete = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinutosLembrete = new System.Windows.Forms.NumericUpDown();
            this.labelMinutosLembrete = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasLembrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutosLembrete)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDataLembrete
            // 
            this.labelDataLembrete.AutoSize = true;
            this.labelDataLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataLembrete.Location = new System.Drawing.Point(23, 22);
            this.labelDataLembrete.Name = "labelDataLembrete";
            this.labelDataLembrete.Size = new System.Drawing.Size(53, 20);
            this.labelDataLembrete.TabIndex = 28;
            this.labelDataLembrete.Text = "Data:";
            // 
            // dateTimePickerDataLembrete
            // 
            this.dateTimePickerDataLembrete.Location = new System.Drawing.Point(82, 22);
            this.dateTimePickerDataLembrete.Name = "dateTimePickerDataLembrete";
            this.dateTimePickerDataLembrete.Size = new System.Drawing.Size(157, 20);
            this.dateTimePickerDataLembrete.TabIndex = 26;
            // 
            // textBoxTextoLembrete
            // 
            this.textBoxTextoLembrete.Location = new System.Drawing.Point(95, 48);
            this.textBoxTextoLembrete.Name = "textBoxTextoLembrete";
            this.textBoxTextoLembrete.Size = new System.Drawing.Size(396, 20);
            this.textBoxTextoLembrete.TabIndex = 24;
            // 
            // buttonAdicionarLembrete
            // 
            this.buttonAdicionarLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarLembrete.Location = new System.Drawing.Point(197, 74);
            this.buttonAdicionarLembrete.Name = "buttonAdicionarLembrete";
            this.buttonAdicionarLembrete.Size = new System.Drawing.Size(92, 32);
            this.buttonAdicionarLembrete.TabIndex = 23;
            this.buttonAdicionarLembrete.Text = "Adicionar";
            this.buttonAdicionarLembrete.UseVisualStyleBackColor = true;
            this.buttonAdicionarLembrete.Click += new System.EventHandler(this.buttonAdicionarLembrete_Click);
            // 
            // labelHorasLembrete
            // 
            this.labelHorasLembrete.AutoSize = true;
            this.labelHorasLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHorasLembrete.Location = new System.Drawing.Point(245, 22);
            this.labelHorasLembrete.Name = "labelHorasLembrete";
            this.labelHorasLembrete.Size = new System.Drawing.Size(62, 20);
            this.labelHorasLembrete.TabIndex = 29;
            this.labelHorasLembrete.Text = "Horas:";
            // 
            // numericUpDownHorasLembrete
            // 
            this.numericUpDownHorasLembrete.Location = new System.Drawing.Point(313, 22);
            this.numericUpDownHorasLembrete.Name = "numericUpDownHorasLembrete";
            this.numericUpDownHorasLembrete.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownHorasLembrete.TabIndex = 30;
            // 
            // numericUpDownMinutosLembrete
            // 
            this.numericUpDownMinutosLembrete.Location = new System.Drawing.Point(445, 22);
            this.numericUpDownMinutosLembrete.Name = "numericUpDownMinutosLembrete";
            this.numericUpDownMinutosLembrete.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownMinutosLembrete.TabIndex = 32;
            // 
            // labelMinutosLembrete
            // 
            this.labelMinutosLembrete.AutoSize = true;
            this.labelMinutosLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinutosLembrete.Location = new System.Drawing.Point(365, 22);
            this.labelMinutosLembrete.Name = "labelMinutosLembrete";
            this.labelMinutosLembrete.Size = new System.Drawing.Size(77, 20);
            this.labelMinutosLembrete.TabIndex = 31;
            this.labelMinutosLembrete.Text = "Minutos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Lembrete:";
            // 
            // FormAdicionarLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownMinutosLembrete);
            this.Controls.Add(this.labelMinutosLembrete);
            this.Controls.Add(this.numericUpDownHorasLembrete);
            this.Controls.Add(this.labelHorasLembrete);
            this.Controls.Add(this.labelDataLembrete);
            this.Controls.Add(this.dateTimePickerDataLembrete);
            this.Controls.Add(this.textBoxTextoLembrete);
            this.Controls.Add(this.buttonAdicionarLembrete);
            this.Name = "FormAdicionarLembrete";
            this.Text = "Adicionar Lembrete";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasLembrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutosLembrete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDataLembrete;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataLembrete;
        private System.Windows.Forms.TextBox textBoxTextoLembrete;
        private System.Windows.Forms.Button buttonAdicionarLembrete;
        private System.Windows.Forms.Label labelHorasLembrete;
        private System.Windows.Forms.NumericUpDown numericUpDownHorasLembrete;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutosLembrete;
        private System.Windows.Forms.Label labelMinutosLembrete;
        private System.Windows.Forms.Label label1;
    }
}