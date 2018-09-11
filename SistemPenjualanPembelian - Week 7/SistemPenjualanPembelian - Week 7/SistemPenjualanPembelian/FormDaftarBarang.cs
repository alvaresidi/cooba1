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
    public partial class FormDaftarBarang : Form
    {
        public FormDaftarBarang()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void FormDaftarBarang_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
            

            DaftarBarang daftar = new DaftarBarang();

            string hasil = daftar.BacaSemuaData();
           
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();
                
                for(int i=0; i<daftar.JumlahBarang; i++)
                {
                    string kodeBrg = daftar.ListBarang[i].KodeBarang;
                    string namaBrg = daftar.ListBarang[i].NamaBarang;
                    int hrgJual = daftar.ListBarang[i].HargaJual;
                    int stok = daftar.ListBarang[i].Stok;
                    string namaKategori = daftar.ListBarang[i].KategoriBarang.NamaKategori;
                    dataGridViewBarang.Rows.Add(kodeBrg, namaBrg, hrgJual, stok, namaKategori);
                }
                
            }
            else
            {
                MessageBox.Show("Gagal Menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarBarang daftar = new DaftarBarang();

            string kriteria = "";
            if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "B.KodeBarang";
            }
            else if (comboBoxCari.Text == "Nama Barang")
            {
                kriteria = "B.Nama";
            }
            else if (comboBoxCari.Text == "Harga Jual")
            {
                kriteria = "B.HargaJual";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "B.Stok";
            }
            else if (comboBoxCari.Text == "Kategori")
            {
                kriteria = "K.Nama";
            }
            

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < daftar.JumlahBarang; i++)
                {
                    string kodeBrg = daftar.ListBarang[i].KodeBarang;
                    string namaBrg = daftar.ListBarang[i].NamaBarang;
                    int hrgJual = daftar.ListBarang[i].HargaJual;
                    int stok = daftar.ListBarang[i].Stok;
                    string namaKategori = daftar.ListBarang[i].KategoriBarang.NamaKategori;
                    dataGridViewBarang.Rows.Add(kodeBrg, namaBrg, hrgJual, stok, namaKategori);
                }
            }
            else
            {
                MessageBox.Show("Gagal Mencari data. Pesan kesalahan = " + hasil, "Kesalahan");
            }

           

           
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusBarang frm = new FormHapusBarang();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBarang ftb = new FormTambahBarang();
            ftb.Owner = this;
            ftb.ShowDialog();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahBarang frm = new FormUbahBarang();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("Nama", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Stok", "Stok ");
            dataGridViewBarang.Columns.Add("NamaKategori", "Kategori");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "0,###";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
