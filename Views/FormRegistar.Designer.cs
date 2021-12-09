
namespace Bot_Idosos.Views
{
    partial class FormRegistar
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
            this.labelNomeUtilizador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRegistar = new System.Windows.Forms.Button();
            this.textBoxApelidoRegistar = new System.Windows.Forms.TextBox();
            this.textBoxNomeRegistar = new System.Windows.Forms.TextBox();
            this.numericUpDownIdadeRegistar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAdicionarFotoRegistar = new System.Windows.Forms.Button();
            this.pictureBoxFotoRegistar = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdadeRegistar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoRegistar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNomeUtilizador
            // 
            this.labelNomeUtilizador.AutoSize = true;
            this.labelNomeUtilizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeUtilizador.Location = new System.Drawing.Point(29, 23);
            this.labelNomeUtilizador.Name = "labelNomeUtilizador";
            this.labelNomeUtilizador.Size = new System.Drawing.Size(60, 20);
            this.labelNomeUtilizador.TabIndex = 1;
            this.labelNomeUtilizador.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apelido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Idade:";
            // 
            // buttonRegistar
            // 
            this.buttonRegistar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistar.Location = new System.Drawing.Point(108, 362);
            this.buttonRegistar.Name = "buttonRegistar";
            this.buttonRegistar.Size = new System.Drawing.Size(92, 32);
            this.buttonRegistar.TabIndex = 5;
            this.buttonRegistar.Text = "Registar";
            this.buttonRegistar.UseVisualStyleBackColor = true;
            this.buttonRegistar.Click += new System.EventHandler(this.buttonRegistar_Click);
            // 
            // textBoxApelidoRegistar
            // 
            this.textBoxApelidoRegistar.Location = new System.Drawing.Point(95, 62);
            this.textBoxApelidoRegistar.Name = "textBoxApelidoRegistar";
            this.textBoxApelidoRegistar.Size = new System.Drawing.Size(142, 24);
            this.textBoxApelidoRegistar.TabIndex = 7;
            // 
            // textBoxNomeRegistar
            // 
            this.textBoxNomeRegistar.Location = new System.Drawing.Point(95, 25);
            this.textBoxNomeRegistar.Name = "textBoxNomeRegistar";
            this.textBoxNomeRegistar.Size = new System.Drawing.Size(142, 24);
            this.textBoxNomeRegistar.TabIndex = 8;
            // 
            // numericUpDownIdadeRegistar
            // 
            this.numericUpDownIdadeRegistar.Location = new System.Drawing.Point(95, 95);
            this.numericUpDownIdadeRegistar.Name = "numericUpDownIdadeRegistar";
            this.numericUpDownIdadeRegistar.Size = new System.Drawing.Size(59, 24);
            this.numericUpDownIdadeRegistar.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Foto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNomeUtilizador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownIdadeRegistar);
            this.groupBox1.Controls.Add(this.textBoxApelidoRegistar);
            this.groupBox1.Controls.Add(this.textBoxNomeRegistar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 151);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obrigatório preencher";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxFotoRegistar);
            this.groupBox2.Controls.Add(this.buttonAdicionarFotoRegistar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 187);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Não obrigatório preencher";
            // 
            // buttonAdicionarFotoRegistar
            // 
            this.buttonAdicionarFotoRegistar.Location = new System.Drawing.Point(85, 139);
            this.buttonAdicionarFotoRegistar.Name = "buttonAdicionarFotoRegistar";
            this.buttonAdicionarFotoRegistar.Size = new System.Drawing.Size(142, 23);
            this.buttonAdicionarFotoRegistar.TabIndex = 11;
            this.buttonAdicionarFotoRegistar.Text = "Adicionar Foto";
            this.buttonAdicionarFotoRegistar.UseVisualStyleBackColor = true;
            this.buttonAdicionarFotoRegistar.Click += new System.EventHandler(this.buttonAdicionarFotoRegistar_Click);
            // 
            // pictureBoxFotoRegistar
            // 
            this.pictureBoxFotoRegistar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFotoRegistar.Image = global::Bot_Idosos.Properties.Resources.anonimo;
            this.pictureBoxFotoRegistar.Location = new System.Drawing.Point(95, 23);
            this.pictureBoxFotoRegistar.Name = "pictureBoxFotoRegistar";
            this.pictureBoxFotoRegistar.Size = new System.Drawing.Size(104, 110);
            this.pictureBoxFotoRegistar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFotoRegistar.TabIndex = 20;
            this.pictureBoxFotoRegistar.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png";
            // 
            // FormRegistar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRegistar);
            this.Name = "FormRegistar";
            this.Text = "Registar";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdadeRegistar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoRegistar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNomeUtilizador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRegistar;
        private System.Windows.Forms.TextBox textBoxApelidoRegistar;
        private System.Windows.Forms.TextBox textBoxNomeRegistar;
        private System.Windows.Forms.NumericUpDown numericUpDownIdadeRegistar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAdicionarFotoRegistar;
        private System.Windows.Forms.PictureBox pictureBoxFotoRegistar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}