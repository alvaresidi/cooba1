namespace SistemPenjualanPembelian
{
    partial class FormTambahNotaBeli
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
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.buttonCetak = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.textBoxJumlah = new System.Windows.Forms.TextBox();
            this.textBoxHargaBeli = new System.Windows.Forms.TextBox();
            this.textBoxNamaBarang = new System.Windows.Forms.TextBox();
            this.textBoxKodeBarang = new System.Windows.Forms.TextBox();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelNamaPegawai = new System.Windows.Forms.Label();
            this.labelKodePegawai = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAlamat = new System.Windows.Forms.TextBox();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.textBoxNoNota = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Location = new System.Drawing.Point(402, 170);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(84, 13);
            this.labelGrandTotal.TabIndex = 93;
            this.labelGrandTotal.Text = "GRAND TOTAL";
            // 
            // buttonCetak
            // 
            this.buttonCetak.Location = new System.Drawing.Point(300, 406);
            this.buttonCetak.Name = "buttonCetak";
            this.buttonCetak.Size = new System.Drawing.Size(75, 23);
            this.buttonCetak.TabIndex = 92;
            this.buttonCetak.Text = "CETAK";
            this.buttonCetak.UseVisualStyleBackColor = true;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.Location = new System.Drawing.Point(163, 403);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 91;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = true;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.AllowUserToAddRows = false;
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(27, 251);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.Size = new System.Drawing.Size(538, 149);
            this.dataGridViewBarang.TabIndex = 90;
            // 
            // textBoxJumlah
            // 
            this.textBoxJumlah.Location = new System.Drawing.Point(415, 223);
            this.textBoxJumlah.Name = "textBoxJumlah";
            this.textBoxJumlah.Size = new System.Drawing.Size(100, 20);
            this.textBoxJumlah.TabIndex = 89;
            // 
            // textBoxHargaBeli
            // 
            this.textBoxHargaBeli.Location = new System.Drawing.Point(309, 223);
            this.textBoxHargaBeli.Name = "textBoxHargaBeli";
            this.textBoxHargaBeli.Size = new System.Drawing.Size(100, 20);
            this.textBoxHargaBeli.TabIndex = 88;
            // 
            // textBoxNamaBarang
            // 
            this.textBoxNamaBarang.Location = new System.Drawing.Point(134, 224);
            this.textBoxNamaBarang.Name = "textBoxNamaBarang";
            this.textBoxNamaBarang.Size = new System.Drawing.Size(168, 20);
            this.textBoxNamaBarang.TabIndex = 87;
            // 
            // textBoxKodeBarang
            // 
            this.textBoxKodeBarang.Location = new System.Drawing.Point(31, 225);
            this.textBoxKodeBarang.Name = "textBoxKodeBarang";
            this.textBoxKodeBarang.Size = new System.Drawing.Size(100, 20);
            this.textBoxKodeBarang.TabIndex = 86;
            this.textBoxKodeBarang.TextChanged += new System.EventHandler(this.textBoxKodeBarang_TextChanged);
            // 
            // buttonTambah
            // 
            this.buttonTambah.Location = new System.Drawing.Point(521, 218);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(44, 30);
            this.buttonTambah.TabIndex = 85;
            this.buttonTambah.Text = "+";
            this.buttonTambah.UseVisualStyleBackColor = true;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 84;
            this.label10.Text = "Jumlah";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 83;
            this.label9.Text = "Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = "Nama Barang";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 81;
            this.label7.Text = "KODE";
            // 
            // labelNamaPegawai
            // 
            this.labelNamaPegawai.AutoSize = true;
            this.labelNamaPegawai.Location = new System.Drawing.Point(137, 170);
            this.labelNamaPegawai.Name = "labelNamaPegawai";
            this.labelNamaPegawai.Size = new System.Drawing.Size(19, 13);
            this.labelNamaPegawai.TabIndex = 80;
            this.labelNamaPegawai.Text = "----";
            // 
            // labelKodePegawai
            // 
            this.labelKodePegawai.AutoSize = true;
            this.labelKodePegawai.Location = new System.Drawing.Point(91, 171);
            this.labelKodePegawai.Name = "labelKodePegawai";
            this.labelKodePegawai.Size = new System.Drawing.Size(10, 13);
            this.labelKodePegawai.TabIndex = 79;
            this.labelKodePegawai.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Pegawai : ";
            // 
            // textBoxAlamat
            // 
            this.textBoxAlamat.Location = new System.Drawing.Point(394, 88);
            this.textBoxAlamat.Multiline = true;
            this.textBoxAlamat.Name = "textBoxAlamat";
            this.textBoxAlamat.Size = new System.Drawing.Size(171, 52);
            this.textBoxAlamat.TabIndex = 77;
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(394, 51);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(171, 21);
            this.comboBoxSupplier.TabIndex = 76;
            this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Alamat :";
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(86, 81);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(133, 20);
            this.dateTimePickerTanggal.TabIndex = 74;
            // 
            // textBoxNoNota
            // 
            this.textBoxNoNota.Location = new System.Drawing.Point(86, 48);
            this.textBoxNoNota.Name = "textBoxNoNota";
            this.textBoxNoNota.Size = new System.Drawing.Size(133, 20);
            this.textBoxNoNota.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(569, 36);
            this.label4.TabIndex = 72;
            this.label4.Text = "TAMBAH NOTA BELI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tanggal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "No. Nota :";
            // 
            // FormTambahNotaBeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 446);
            this.Controls.Add(this.labelGrandTotal);
            this.Controls.Add(this.buttonCetak);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.dataGridViewBarang);
            this.Controls.Add(this.textBoxJumlah);
            this.Controls.Add(this.textBoxHargaBeli);
            this.Controls.Add(this.textBoxNamaBarang);
            this.Controls.Add(this.textBoxKodeBarang);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelNamaPegawai);
            this.Controls.Add(this.labelKodePegawai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAlamat);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.textBoxNoNota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTambahNotaBeli";
            this.Text = "FormTambahNotaBeli";
            this.Load += new System.EventHandler(this.FormTambahNotaBeli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGrandTotal;
        private System.Windows.Forms.Button buttonCetak;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.TextBox textBoxJumlah;
        private System.Windows.Forms.TextBox textBoxHargaBeli;
        private System.Windows.Forms.TextBox textBoxNamaBarang;
        private System.Windows.Forms.TextBox textBoxKodeBarang;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelNamaPegawai;
        private System.Windows.Forms.Label labelKodePegawai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAlamat;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.TextBox textBoxNoNota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}