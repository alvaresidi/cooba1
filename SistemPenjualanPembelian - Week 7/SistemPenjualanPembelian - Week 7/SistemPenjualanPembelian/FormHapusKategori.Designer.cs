namespace SistemPenjualanPembelian
{
    partial class FormHapusKategori
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.textBoxNamaKategori = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxKodeKategori = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(383, 201);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(112, 41);
            this.buttonKeluar.TabIndex = 33;
            this.buttonKeluar.Text = "&KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonKosongi.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(216, 201);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(112, 41);
            this.buttonKosongi.TabIndex = 32;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // textBoxNamaKategori
            // 
            this.textBoxNamaKategori.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNamaKategori.Location = new System.Drawing.Point(158, 72);
            this.textBoxNamaKategori.Name = "textBoxNamaKategori";
            this.textBoxNamaKategori.Size = new System.Drawing.Size(298, 26);
            this.textBoxNamaKategori.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 36);
            this.label3.TabIndex = 34;
            this.label3.Text = "HAPUS KATEGORI BARANG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nama Kategori :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kode Kategori :";
            // 
            // buttonHapus
            // 
            this.buttonHapus.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonHapus.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHapus.ForeColor = System.Drawing.Color.White;
            this.buttonHapus.Location = new System.Drawing.Point(97, 201);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(113, 41);
            this.buttonHapus.TabIndex = 31;
            this.buttonHapus.Text = "&HAPUS";
            this.buttonHapus.UseVisualStyleBackColor = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxKodeKategori);
            this.panel1.Controls.Add(this.textBoxNamaKategori);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 138);
            this.panel1.TabIndex = 30;
            // 
            // textBoxKodeKategori
            // 
            this.textBoxKodeKategori.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKodeKategori.Location = new System.Drawing.Point(158, 32);
            this.textBoxKodeKategori.Name = "textBoxKodeKategori";
            this.textBoxKodeKategori.Size = new System.Drawing.Size(52, 26);
            this.textBoxKodeKategori.TabIndex = 0;
            this.textBoxKodeKategori.TextChanged += new System.EventHandler(this.textBoxKodeKategori_TextChanged);
            // 
            // FormHapusKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(507, 253);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonHapus);
            this.Controls.Add(this.panel1);
            this.Name = "FormHapusKategori";
            this.Text = "Hapus Kategori Barang";
            this.Load += new System.EventHandler(this.FormHapusKategori_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        public System.Windows.Forms.TextBox textBoxNamaKategori;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox textBoxKodeKategori;
    }
}