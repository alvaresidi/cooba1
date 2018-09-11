namespace SistemPenjualanPembelian
{
    partial class FormUbahBarang
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
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStok = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHargaJual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKodeBarang = new System.Windows.Forms.TextBox();
            this.textBoxNamaBarang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonKeluar.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(387, 334);
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
            this.buttonKosongi.Location = new System.Drawing.Point(220, 334);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(112, 41);
            this.buttonKosongi.TabIndex = 32;
            this.buttonKosongi.Text = "&KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 36);
            this.label3.TabIndex = 34;
            this.label3.Text = "UBAH BARANG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSimpan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(101, 332);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(113, 41);
            this.buttonSimpan.TabIndex = 31;
            this.buttonSimpan.Text = "&SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxStok);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxHargaJual);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxKodeBarang);
            this.panel1.Controls.Add(this.textBoxNamaBarang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 224);
            this.panel1.TabIndex = 30;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(151, 172);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Kategori :";
            // 
            // textBoxStok
            // 
            this.textBoxStok.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStok.Location = new System.Drawing.Point(151, 135);
            this.textBoxStok.Name = "textBoxStok";
            this.textBoxStok.Size = new System.Drawing.Size(79, 26);
            this.textBoxStok.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Stok :";
            // 
            // textBoxHargaJual
            // 
            this.textBoxHargaJual.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHargaJual.Location = new System.Drawing.Point(151, 103);
            this.textBoxHargaJual.Name = "textBoxHargaJual";
            this.textBoxHargaJual.Size = new System.Drawing.Size(157, 26);
            this.textBoxHargaJual.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Harga Jual :";
            // 
            // textBoxKodeBarang
            // 
            this.textBoxKodeBarang.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKodeBarang.Location = new System.Drawing.Point(151, 31);
            this.textBoxKodeBarang.Name = "textBoxKodeBarang";
            this.textBoxKodeBarang.Size = new System.Drawing.Size(86, 26);
            this.textBoxKodeBarang.TabIndex = 18;
            this.textBoxKodeBarang.TextChanged += new System.EventHandler(this.textBoxKodeBarang_TextChanged);
            // 
            // textBoxNamaBarang
            // 
            this.textBoxNamaBarang.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNamaBarang.Location = new System.Drawing.Point(151, 71);
            this.textBoxNamaBarang.Name = "textBoxNamaBarang";
            this.textBoxNamaBarang.Size = new System.Drawing.Size(298, 26);
            this.textBoxNamaBarang.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nama Barang :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Kode Barang:";
            // 
            // FormUbahBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 387);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.Name = "FormUbahBarang";
            this.Text = "FormUbahBarang";
            this.Load += new System.EventHandler(this.FormUbahBarang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxStok;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxHargaJual;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxKodeBarang;
        public System.Windows.Forms.TextBox textBoxNamaBarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}