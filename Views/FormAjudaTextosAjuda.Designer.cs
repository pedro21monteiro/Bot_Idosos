
namespace Bot_Idosos.Views
{
    partial class FormAjudaTextosAjuda
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
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBoxPause = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlay = new System.Windows.Forms.PictureBox();
            this.pictureBoxSom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(13, 190);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 0;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(435, 171);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBoxPause
            // 
            this.pictureBoxPause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPause.Image = global::Bot_Idosos.Properties.Resources.Pause;
            this.pictureBoxPause.Location = new System.Drawing.Point(454, 67);
            this.pictureBoxPause.Name = "pictureBoxPause";
            this.pictureBoxPause.Size = new System.Drawing.Size(52, 45);
            this.pictureBoxPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPause.TabIndex = 7;
            this.pictureBoxPause.TabStop = false;
            this.pictureBoxPause.Click += new System.EventHandler(this.pictureBoxPause_Click);
            // 
            // pictureBoxPlay
            // 
            this.pictureBoxPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPlay.Image = global::Bot_Idosos.Properties.Resources.play;
            this.pictureBoxPlay.Location = new System.Drawing.Point(454, 118);
            this.pictureBoxPlay.Name = "pictureBoxPlay";
            this.pictureBoxPlay.Size = new System.Drawing.Size(52, 46);
            this.pictureBoxPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlay.TabIndex = 6;
            this.pictureBoxPlay.TabStop = false;
            this.pictureBoxPlay.Click += new System.EventHandler(this.pictureBoxPlay_Click);
            // 
            // pictureBoxSom
            // 
            this.pictureBoxSom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSom.Image = global::Bot_Idosos.Properties.Resources.ImagemDeSom;
            this.pictureBoxSom.Location = new System.Drawing.Point(454, 13);
            this.pictureBoxSom.Name = "pictureBoxSom";
            this.pictureBoxSom.Size = new System.Drawing.Size(52, 48);
            this.pictureBoxSom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSom.TabIndex = 5;
            this.pictureBoxSom.TabStop = false;
            this.pictureBoxSom.Click += new System.EventHandler(this.pictureBoxSom_Click);
            // 
            // FormAjudaTextosAjuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 225);
            this.Controls.Add(this.pictureBoxPause);
            this.Controls.Add(this.pictureBoxPlay);
            this.Controls.Add(this.pictureBoxSom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonVoltar);
            this.Name = "FormAjudaTextosAjuda";
            this.Text = "Ajuda ";
            this.Load += new System.EventHandler(this.FormAjudaAdicionaLembrete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBoxSom;
        private System.Windows.Forms.PictureBox pictureBoxPlay;
        private System.Windows.Forms.PictureBox pictureBoxPause;
    }
}