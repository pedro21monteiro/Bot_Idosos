
namespace Bot_Idosos.Views
{
    partial class FormAdicionarMedicamento
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
            this.textBoxNomeMedicamento = new System.Windows.Forms.TextBox();
            this.buttonAdicionarMedicamento = new System.Windows.Forms.Button();
            this.labelvezezpordia = new System.Windows.Forms.Label();
            this.labelNomeMedicamento = new System.Windows.Forms.Label();
            this.comboBoxVezesToma = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataInicialOpcao2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataFilnalOpcao2 = new System.Windows.Forms.DateTimePicker();
            this.labelDataInicialToma = new System.Windows.Forms.Label();
            this.labelDataFinal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownHorasAdicionarMedicamento = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxOpcao1 = new System.Windows.Forms.CheckBox();
            this.dateTimePickerDataFinalOpcao1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataIniciaOpcao1 = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxHorasToma = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxOpcao2 = new System.Windows.Forms.CheckBox();
            this.checkBoxOpcao3 = new System.Windows.Forms.CheckBox();
            this.numericUpDownMinutosLembrete = new System.Windows.Forms.NumericUpDown();
            this.labelMinutosLembrete = new System.Windows.Forms.Label();
            this.numericUpDownHorasLembrete = new System.Windows.Forms.NumericUpDown();
            this.labelHorasLembrete = new System.Windows.Forms.Label();
            this.labelDataLembrete = new System.Windows.Forms.Label();
            this.dateTimePickerDataLembrete = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasAdicionarMedicamento)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutosLembrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasLembrete)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNomeMedicamento
            // 
            this.textBoxNomeMedicamento.Location = new System.Drawing.Point(243, 24);
            this.textBoxNomeMedicamento.Name = "textBoxNomeMedicamento";
            this.textBoxNomeMedicamento.Size = new System.Drawing.Size(142, 20);
            this.textBoxNomeMedicamento.TabIndex = 15;
            // 
            // buttonAdicionarMedicamento
            // 
            this.buttonAdicionarMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarMedicamento.Location = new System.Drawing.Point(475, 397);
            this.buttonAdicionarMedicamento.Name = "buttonAdicionarMedicamento";
            this.buttonAdicionarMedicamento.Size = new System.Drawing.Size(92, 32);
            this.buttonAdicionarMedicamento.TabIndex = 13;
            this.buttonAdicionarMedicamento.Text = "Adicionar";
            this.buttonAdicionarMedicamento.UseVisualStyleBackColor = true;
            this.buttonAdicionarMedicamento.Click += new System.EventHandler(this.buttonAdicionarMedicamento_Click);
            // 
            // labelvezezpordia
            // 
            this.labelvezezpordia.AutoSize = true;
            this.labelvezezpordia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvezezpordia.Location = new System.Drawing.Point(6, 68);
            this.labelvezezpordia.Name = "labelvezezpordia";
            this.labelvezezpordia.Size = new System.Drawing.Size(133, 20);
            this.labelvezezpordia.TabIndex = 11;
            this.labelvezezpordia.Text = "Quantas vezes:";
            // 
            // labelNomeMedicamento
            // 
            this.labelNomeMedicamento.AutoSize = true;
            this.labelNomeMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeMedicamento.Location = new System.Drawing.Point(46, 22);
            this.labelNomeMedicamento.Name = "labelNomeMedicamento";
            this.labelNomeMedicamento.Size = new System.Drawing.Size(197, 20);
            this.labelNomeMedicamento.TabIndex = 10;
            this.labelNomeMedicamento.Text = "Nome do Medicamento:";
            // 
            // comboBoxVezesToma
            // 
            this.comboBoxVezesToma.FormattingEnabled = true;
            this.comboBoxVezesToma.Items.AddRange(new object[] {
            "1 vez por dia",
            "2 vezes por dia",
            "3 vezes por dia",
            "4 vezes por dia",
            "6 vezes por dia"});
            this.comboBoxVezesToma.Location = new System.Drawing.Point(145, 67);
            this.comboBoxVezesToma.Name = "comboBoxVezesToma";
            this.comboBoxVezesToma.Size = new System.Drawing.Size(194, 26);
            this.comboBoxVezesToma.TabIndex = 16;
            // 
            // dateTimePickerDataInicialOpcao2
            // 
            this.dateTimePickerDataInicialOpcao2.Location = new System.Drawing.Point(117, 207);
            this.dateTimePickerDataInicialOpcao2.Name = "dateTimePickerDataInicialOpcao2";
            this.dateTimePickerDataInicialOpcao2.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerDataInicialOpcao2.TabIndex = 17;
            // 
            // dateTimePickerDataFilnalOpcao2
            // 
            this.dateTimePickerDataFilnalOpcao2.Location = new System.Drawing.Point(117, 234);
            this.dateTimePickerDataFilnalOpcao2.Name = "dateTimePickerDataFilnalOpcao2";
            this.dateTimePickerDataFilnalOpcao2.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerDataFilnalOpcao2.TabIndex = 18;
            // 
            // labelDataInicialToma
            // 
            this.labelDataInicialToma.AutoSize = true;
            this.labelDataInicialToma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataInicialToma.Location = new System.Drawing.Point(6, 207);
            this.labelDataInicialToma.Name = "labelDataInicialToma";
            this.labelDataInicialToma.Size = new System.Drawing.Size(105, 20);
            this.labelDataInicialToma.TabIndex = 19;
            this.labelDataInicialToma.Text = "Data Inicial:";
            // 
            // labelDataFinal
            // 
            this.labelDataFinal.AutoSize = true;
            this.labelDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataFinal.Location = new System.Drawing.Point(6, 234);
            this.labelDataFinal.Name = "labelDataFinal";
            this.labelDataFinal.Size = new System.Drawing.Size(97, 20);
            this.labelDataFinal.TabIndex = 20;
            this.labelDataFinal.Text = "Data Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Horas Inicio:";
            // 
            // numericUpDownHorasAdicionarMedicamento
            // 
            this.numericUpDownHorasAdicionarMedicamento.Location = new System.Drawing.Point(145, 104);
            this.numericUpDownHorasAdicionarMedicamento.Name = "numericUpDownHorasAdicionarMedicamento";
            this.numericUpDownHorasAdicionarMedicamento.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownHorasAdicionarMedicamento.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxOpcao1);
            this.groupBox1.Controls.Add(this.dateTimePickerDataFinalOpcao1);
            this.groupBox1.Controls.Add(this.labelvezezpordia);
            this.groupBox1.Controls.Add(this.dateTimePickerDataIniciaOpcao1);
            this.groupBox1.Controls.Add(this.numericUpDownHorasAdicionarMedicamento);
            this.groupBox1.Controls.Add(this.comboBoxVezesToma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 269);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opção 1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Data Final:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Data Inicial:";
            // 
            // checkBoxOpcao1
            // 
            this.checkBoxOpcao1.AutoSize = true;
            this.checkBoxOpcao1.Location = new System.Drawing.Point(78, 39);
            this.checkBoxOpcao1.Name = "checkBoxOpcao1";
            this.checkBoxOpcao1.Size = new System.Drawing.Size(84, 22);
            this.checkBoxOpcao1.TabIndex = 23;
            this.checkBoxOpcao1.Text = "Opção 1";
            this.checkBoxOpcao1.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDataFinalOpcao1
            // 
            this.dateTimePickerDataFinalOpcao1.Location = new System.Drawing.Point(128, 190);
            this.dateTimePickerDataFinalOpcao1.Name = "dateTimePickerDataFinalOpcao1";
            this.dateTimePickerDataFinalOpcao1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerDataFinalOpcao1.TabIndex = 28;
            // 
            // dateTimePickerDataIniciaOpcao1
            // 
            this.dateTimePickerDataIniciaOpcao1.Location = new System.Drawing.Point(128, 163);
            this.dateTimePickerDataIniciaOpcao1.Name = "dateTimePickerDataIniciaOpcao1";
            this.dateTimePickerDataIniciaOpcao1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerDataIniciaOpcao1.TabIndex = 27;
            // 
            // checkedListBoxHorasToma
            // 
            this.checkedListBoxHorasToma.FormattingEnabled = true;
            this.checkedListBoxHorasToma.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.checkedListBoxHorasToma.Location = new System.Drawing.Point(10, 96);
            this.checkedListBoxHorasToma.Name = "checkedListBoxHorasToma";
            this.checkedListBoxHorasToma.Size = new System.Drawing.Size(317, 80);
            this.checkedListBoxHorasToma.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Insira as horas da toma:";
            // 
            // checkBoxOpcao2
            // 
            this.checkBoxOpcao2.AutoSize = true;
            this.checkBoxOpcao2.Location = new System.Drawing.Point(117, 38);
            this.checkBoxOpcao2.Name = "checkBoxOpcao2";
            this.checkBoxOpcao2.Size = new System.Drawing.Size(84, 22);
            this.checkBoxOpcao2.TabIndex = 24;
            this.checkBoxOpcao2.Text = "Opção 2";
            this.checkBoxOpcao2.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpcao3
            // 
            this.checkBoxOpcao3.AutoSize = true;
            this.checkBoxOpcao3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOpcao3.Location = new System.Drawing.Point(86, 36);
            this.checkBoxOpcao3.Name = "checkBoxOpcao3";
            this.checkBoxOpcao3.Size = new System.Drawing.Size(84, 22);
            this.checkBoxOpcao3.TabIndex = 27;
            this.checkBoxOpcao3.Text = "Opção 3";
            this.checkBoxOpcao3.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMinutosLembrete
            // 
            this.numericUpDownMinutosLembrete.Location = new System.Drawing.Point(232, 108);
            this.numericUpDownMinutosLembrete.Name = "numericUpDownMinutosLembrete";
            this.numericUpDownMinutosLembrete.Size = new System.Drawing.Size(46, 24);
            this.numericUpDownMinutosLembrete.TabIndex = 38;
            // 
            // labelMinutosLembrete
            // 
            this.labelMinutosLembrete.AutoSize = true;
            this.labelMinutosLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinutosLembrete.Location = new System.Drawing.Point(149, 108);
            this.labelMinutosLembrete.Name = "labelMinutosLembrete";
            this.labelMinutosLembrete.Size = new System.Drawing.Size(77, 20);
            this.labelMinutosLembrete.TabIndex = 37;
            this.labelMinutosLembrete.Text = "Minutos:";
            // 
            // numericUpDownHorasLembrete
            // 
            this.numericUpDownHorasLembrete.Location = new System.Drawing.Point(86, 108);
            this.numericUpDownHorasLembrete.Name = "numericUpDownHorasLembrete";
            this.numericUpDownHorasLembrete.Size = new System.Drawing.Size(46, 24);
            this.numericUpDownHorasLembrete.TabIndex = 36;
            // 
            // labelHorasLembrete
            // 
            this.labelHorasLembrete.AutoSize = true;
            this.labelHorasLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHorasLembrete.Location = new System.Drawing.Point(11, 105);
            this.labelHorasLembrete.Name = "labelHorasLembrete";
            this.labelHorasLembrete.Size = new System.Drawing.Size(62, 20);
            this.labelHorasLembrete.TabIndex = 35;
            this.labelHorasLembrete.Text = "Horas:";
            // 
            // labelDataLembrete
            // 
            this.labelDataLembrete.AutoSize = true;
            this.labelDataLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataLembrete.Location = new System.Drawing.Point(11, 70);
            this.labelDataLembrete.Name = "labelDataLembrete";
            this.labelDataLembrete.Size = new System.Drawing.Size(53, 20);
            this.labelDataLembrete.TabIndex = 34;
            this.labelDataLembrete.Text = "Data:";
            // 
            // dateTimePickerDataLembrete
            // 
            this.dateTimePickerDataLembrete.Location = new System.Drawing.Point(80, 70);
            this.dateTimePickerDataLembrete.Name = "dateTimePickerDataLembrete";
            this.dateTimePickerDataLembrete.Size = new System.Drawing.Size(198, 24);
            this.dateTimePickerDataLembrete.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDataFinal);
            this.groupBox2.Controls.Add(this.checkedListBoxHorasToma);
            this.groupBox2.Controls.Add(this.labelDataInicialToma);
            this.groupBox2.Controls.Add(this.dateTimePickerDataFilnalOpcao2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBoxOpcao2);
            this.groupBox2.Controls.Add(this.dateTimePickerDataInicialOpcao2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(412, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 279);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opção2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Escolha uma das seguinte opções para preencher seu horario:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxOpcao3);
            this.groupBox3.Controls.Add(this.dateTimePickerDataLembrete);
            this.groupBox3.Controls.Add(this.labelDataLembrete);
            this.groupBox3.Controls.Add(this.numericUpDownMinutosLembrete);
            this.groupBox3.Controls.Add(this.labelHorasLembrete);
            this.groupBox3.Controls.Add(this.labelMinutosLembrete);
            this.groupBox3.Controls.Add(this.numericUpDownHorasLembrete);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(784, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 279);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opção3";
            // 
            // FormAdicionarMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxNomeMedicamento);
            this.Controls.Add(this.buttonAdicionarMedicamento);
            this.Controls.Add(this.labelNomeMedicamento);
            this.Name = "FormAdicionarMedicamento";
            this.Text = "Adicionar Medicamento";
            this.Load += new System.EventHandler(this.FormAdicionarMedicamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasAdicionarMedicamento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinutosLembrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorasLembrete)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeMedicamento;
        private System.Windows.Forms.Button buttonAdicionarMedicamento;
        private System.Windows.Forms.Label labelvezezpordia;
        private System.Windows.Forms.Label labelNomeMedicamento;
        private System.Windows.Forms.ComboBox comboBoxVezesToma;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInicialOpcao2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFilnalOpcao2;
        private System.Windows.Forms.Label labelDataInicialToma;
        private System.Windows.Forms.Label labelDataFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownHorasAdicionarMedicamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBoxHorasToma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxOpcao2;
        private System.Windows.Forms.CheckBox checkBoxOpcao1;
        private System.Windows.Forms.CheckBox checkBoxOpcao3;
        private System.Windows.Forms.NumericUpDown numericUpDownMinutosLembrete;
        private System.Windows.Forms.Label labelMinutosLembrete;
        private System.Windows.Forms.NumericUpDown numericUpDownHorasLembrete;
        private System.Windows.Forms.Label labelHorasLembrete;
        private System.Windows.Forms.Label labelDataLembrete;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataLembrete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFinalOpcao1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataIniciaOpcao1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}