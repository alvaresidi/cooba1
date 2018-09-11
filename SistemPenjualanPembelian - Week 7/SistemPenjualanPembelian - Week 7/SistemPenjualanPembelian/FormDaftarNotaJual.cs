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
    public partial class FormDaftarNotaJual : Form
    {
        public FormDaftarNotaJual()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual ftb = new FormTambahNotaJual();
            ftb.Owner = this;
            ftb.ShowDialog();
        }

        private void FormDaftarNotaJual_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;


            DaftarNotaJual df = new DaftarNotaJual();

            string hasil = df.BacaSemuaData();

            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < df.JumlahNotaJual; i++)
                {
                    string kodeBrg = df.ListNotaJual[i].NoNota;
                    DateTime tgl = df.ListNotaJual[i].Tanggal;
                    string kdPelanggan = df.ListNotaJual[i].Pelanggan.KodePelanggan;
                    string nmPelanggan = df.ListNotaJual[i].Pelanggan.NamaPelanggan;
                    string alamatPlg = df.ListNotaJual[i].Pelanggan.AlamatPelanggan;
                    string kdPegawai = df.ListNotaJual[i].Pegawai.KodePegawai;
                    string nmPegawai = df.ListNotaJual[i].Pegawai.NamaPegawai;

                   
                    dataGridViewBarang.Rows.Add(kodeBrg, tgl, kdPelanggan, nmPelanggan, alamatPlg,kdPegawai,nmPegawai);
                }

            }
            else
            {
                MessageBox.Show("Gagal Menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("NoNota", "Kode Barang");
            dataGridViewBarang.Columns.Add("Tanggal", "Tanggal");
            dataGridViewBarang.Columns.Add("KodePelanggan", "Kode Pelanggan");
            dataGridViewBarang.Columns.Add("Nama", "Nama Pelanggan");
            dataGridViewBarang.Columns.Add("Alamat", "Alamat Pelanggan");
            dataGridViewBarang.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewBarang.Columns.Add("Nama", " Nama Pegawai");

           

            dataGridViewBarang.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

           

            dataGridViewBarang.AllowUserToAddRows = false;
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarNotaJual daftar = new DaftarNotaJual();

            string kriteria = "";
            

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < daftar.JumlahNotaJual; i++)
                {
                    string noNota = daftar.ListNotaJual[i].NoNota;
                    DateTime tgl = daftar.ListNotaJual[i].Tanggal;
                    string kdPlg = daftar.ListNotaJual[i].Pelanggan.KodePelanggan;
                    string nmPlg = daftar.ListNotaJual[i].Pelanggan.NamaPelanggan;
                    string al = daftar.ListNotaJual[i].Pelanggan.AlamatPelanggan;
                    string kdPeg = daftar.ListNotaJual[i].Pegawai.KodePegawai;
                    string nmPeg = daftar.ListNotaJual[i].Pegawai.NamaPegawai;
                    
                    
                    dataGridViewBarang.Rows.Add(noNota, tgl, kdPlg, nmPlg, al,kdPeg,nmPeg);
                }
            }
            else
            {
                MessageBox.Show("Gagal Mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
           
        }

    }
}
