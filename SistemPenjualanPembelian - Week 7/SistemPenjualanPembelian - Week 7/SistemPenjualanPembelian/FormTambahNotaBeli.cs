using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenjualanPembelian_LIB;

namespace SistemPenjualanPembelian
{
    public partial class FormTambahNotaBeli : Form
    {
        public FormTambahNotaBeli()
        {
            InitializeComponent();
        }

        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            DaftarNotaBeli daftar = new DaftarNotaBeli();
            string hasil = daftar.GenerateNoNota();
            if (hasil == "sukses")
            {
                textBoxNoNota.Text = daftar.NoNotaTerbaru;
                textBoxNoNota.Enabled = false;

            }
            else
            {
                MessageBox.Show("Generate Kode gagal dilakukan. Pesan Kesalahan= " + hasil);

            }

            dateTimePickerTanggal.Value = DateTime.Now;
            dateTimePickerTanggal.Enabled = false;

            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarSupplier daftarSp = new DaftarSupplier();
            hasil = daftarSp.BacaSemuaData();
            if (hasil == "sukses")
            {

                comboBoxSupplier.Items.Clear();
                for (int i = 0; i < daftarSp.JumlahSupplier; i++)
                {
                    comboBoxSupplier.Items.Add(daftarSp.ListSupplier[i].KodeSupplier + " - " + daftarSp.ListSupplier[i].NamaSupplier);
                    textBoxAlamat.Text = daftarSp.ListSupplier[i].AlamatSupplier;
                }
                comboBoxSupplier.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Data Pelanggan gagal ditampilkan di combobox. Pesan kesalahan " + hasil);
            }

            FormUtama frmUtama = (FormUtama)this.Owner.MdiParent;
            labelKodePegawai.Text = frmUtama.labelKodePegawai.Text;
            labelNamaPegawai.Text = frmUtama.labelNamaPegawai.Text;

            FormatDataGrid();

            textBoxKodeBarang.MaxLength = 5;
            textBoxKodeBarang.CharacterCasing = CharacterCasing.Upper;

        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaBeli", "Harga Beli");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaBeli"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaBeli"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewBarang.AllowUserToAddRows = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
             string kdSupplier = comboBoxSupplier.Text.Substring(0, 1);
            string nmSupplier = comboBoxSupplier.Text.Substring(4, comboBoxSupplier.Text.Length - 4);

            Supplier s = new Supplier();
            s.KodeSupplier = kdSupplier;
            s.NamaSupplier = nmSupplier;

            Pegawai pegawai = new Pegawai();
            pegawai.KodePegawai = labelKodePegawai.Text;
            pegawai.NamaPegawai = labelNamaPegawai.Text;

            List<NotaBeliDetil> listNotaDetil = new List<NotaBeliDetil>();

            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                Barang br = new Barang();
                br.KodeBarang = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                br.NamaBarang = dataGridViewBarang.Rows[i].Cells["Namabarang"].Value.ToString();
                int harga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaBeli"].Value.ToString());
                int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());

                NotaBeliDetil notaDetil = new NotaBeliDetil(br, harga, jumlah);
                listNotaDetil.Add(notaDetil);
            }

            NotaBeli nota = new NotaBeli(textBoxNoNota.Text, dateTimePickerTanggal.Value, s, pegawai, listNotaDetil);

            DaftarNotaBeli daftar = new DaftarNotaBeli();
            string hasilTambah = daftar.TambahData(nota);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("data nota jual telah tersimpan");
            }
            else
            {
                MessageBox.Show("data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kdSupplier = comboBoxSupplier.Text.Substring(0, 1);

            DaftarSupplier daftarSp = new DaftarSupplier();
            daftarSp.CariData("KodeSupplier", kdSupplier);
            textBoxAlamat.Text = daftarSp.ListSupplier[0].AlamatSupplier;
        }

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {
            textBoxKodeBarang.MaxLength = 5;
            
            if (textBoxKodeBarang.Text.Length == textBoxKodeBarang.MaxLength)
            {

               
                DaftarBarang df = new DaftarBarang();
                string hasil = df.CariData("KodeBarang", textBoxKodeBarang.Text);
                if (hasil == "sukses")
                {
                    if (df.JumlahBarang > 0)
                    {
                        textBoxKodeBarang.Text = df.ListBarang[0].KodeBarang;
                        textBoxNamaBarang.Text = df.ListBarang[0].NamaBarang;
                        textBoxHargaBeli.Text = df.ListBarang[0].HargaJual.ToString();

                        textBoxJumlah.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Kode Barang Tidak ditemkan");
                        textBoxKodeBarang.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah Sql gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewBarang.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;
        }
               

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            int subTotal = int.Parse(textBoxHargaBeli.Text) * int.Parse(textBoxJumlah.Text);
            dataGridViewBarang.Rows.Add(textBoxKodeBarang.Text, textBoxNamaBarang.Text, textBoxHargaBeli.Text, textBoxJumlah.Text, subTotal);

           
            

            textBoxKodeBarang.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxJumlah.Text = "";
            textBoxHargaBeli.Text = "";
            textBoxKodeBarang.Focus();
            labelGrandTotal.Text = HitungGrandTotal().ToString("0,###");
        }

       
    }
}
