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
    public partial class FormTambahNotaJual : Form
    {
        public FormTambahNotaJual()
        {
            InitializeComponent();
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            DaftarNotaJual daftar = new DaftarNotaJual();
            string hasil = daftar.GenerateNoNota();
            if(hasil=="sukses")
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

            comboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;
            DaftarPelanggan daftarPlg = new DaftarPelanggan();
            hasil = daftarPlg.BacaSemuaData();
            if(hasil=="sukses")
            {
                
                comboBoxPelanggan.Items.Clear();
                for(int i=0;i<daftarPlg.JumlahPelanggan;i++)
                {
                    comboBoxPelanggan.Items.Add(daftarPlg.ListPelanggan[i].KodePelanggan + " - " + daftarPlg.ListPelanggan[i].NamaPelanggan);
                    textBoxAlamat.Text = daftarPlg.ListPelanggan[i].AlamatPelanggan;
                }
                comboBoxPelanggan.SelectedIndex = 0;
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
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Jumlah", " Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            dataGridViewBarang.AllowUserToAddRows = false;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string kdPelanggan = comboBoxPelanggan.Text.Substring(0, 1);
            string nmPelanggan = comboBoxPelanggan.Text.Substring(4, comboBoxPelanggan.Text.Length - 4);

            Pelanggan pelanggan = new Pelanggan();
            pelanggan.KodePelanggan = kdPelanggan;
            pelanggan.NamaPelanggan = nmPelanggan;

            Pegawai pegawai = new Pegawai();
            pegawai.KodePegawai = labelKodePegawai.Text;
            pegawai.NamaPegawai = labelNamaPegawai.Text;

            List<DetilNotaJual> listNotaDetil = new List<DetilNotaJual>();

            for(int i=0;i<dataGridViewBarang.Rows.Count;i++)
            {
                Barang br = new Barang();
                br.KodeBarang = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                br.NamaBarang = dataGridViewBarang.Rows[i].Cells["Namabarang"].Value.ToString();
                int harga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaJual"].Value.ToString());
                int jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());

                DetilNotaJual notaDetil = new DetilNotaJual(br,harga,jumlah);
                listNotaDetil.Add(notaDetil);

            }

            NotaJual nota = new NotaJual(textBoxNoNota.Text,dateTimePickerTanggal.Value,pelanggan,pegawai,listNotaDetil);

            DaftarNotaJual daftar = new DaftarNotaJual();
            string hasilTambah = daftar.TambahData(nota);

            if(hasilTambah=="sukses")
            {
                MessageBox.Show("data nota jual telah tersimpan");
            }
            else
            {
                MessageBox.Show("data nota jual gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }

        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kodePelanggan = comboBoxPelanggan.Text.Substring(0, 1);

            DaftarPelanggan daftarPlg = new DaftarPelanggan();
            daftarPlg.CariData("KodePelanggan", kodePelanggan);
            textBoxAlamat.Text = daftarPlg.ListPelanggan[0].AlamatPelanggan;
        }

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {

            if(textBoxKodeBarang.Text.Length==textBoxKodeBarang.MaxLength)
            {
                DaftarBarang daftar = new DaftarBarang();
                string hasil = daftar.CariData("KodeBarang", textBoxKodeBarang.Text);
                if(hasil=="sukses")
                {
                    if(daftar.JumlahBarang>0)
                    {
                        textBoxKodeBarang.Text = daftar.ListBarang[0].KodeBarang;
                        textBoxNamaBarang.Text = daftar.ListBarang[0].NamaBarang;
                        textBoxHarga.Text = daftar.ListBarang[0].HargaJual.ToString();
                        
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
            for(int i=0; i<dataGridViewBarang.Rows.Count;i++)
            {
                int subTotal = int.Parse(dataGridViewBarang.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal = grandTotal + subTotal;
            }
            return grandTotal;

            
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            int subTotal = int.Parse(textBoxHarga.Text) * int.Parse(textBoxJumlah.Text);
            dataGridViewBarang.Rows.Add(textBoxKodeBarang.Text, textBoxNamaBarang.Text, textBoxHarga.Text, textBoxJumlah.Text, subTotal);

            labelGrandTotal.Text = HitungGrandTotal().ToString("0,###");

            textBoxKodeBarang.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxJumlah.Text = "";
            textBoxHarga.Text = "";
            textBoxKodeBarang.Focus();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

    }
}
