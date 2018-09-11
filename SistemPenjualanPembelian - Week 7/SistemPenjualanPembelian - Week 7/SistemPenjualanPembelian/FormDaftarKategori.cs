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
    public partial class FormDaftarKategori : Form
    {
        public FormDaftarKategori()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKategori frm = new FormTambahKategori();
            frm.Owner = this;
            frm.Show();
            
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKategori frm = new FormUbahKategori();
            frm.Owner = this;
            frm.Show();
            
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKategori frm = new FormHapusKategori();
            frm.Owner = this;
            frm.Show();
           
        }

        public void FormDaftarKategori_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            DaftarKategori daftar = new DaftarKategori();

            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                FormatDataGrid();

                

                for(int i=0;i<daftar.JumlahKategoriBarang;i++)
                {
                    string kdKategori = daftar.DaftarKategoriBarang[i].KodeKategori;
                    string nm = daftar.DaftarKategoriBarang[i].NamaKategori;
                    dataGridViewBarang.Rows.Add(kdKategori, nm);
                }
               
            }
            else
            {
                MessageBox.Show("Gagal menampilkan data. Pesan kesalahan = " + hasil, "kesalahan");
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarKategori daftar = new DaftarKategori();

            string kriteria = "";
            if (comboBoxCari.Text == "Kode Kategori")
            {
                kriteria = "KodeKategori";
            }
            else if (comboBoxCari.Text == "Nama Kategori")
            {
                kriteria = "Nama";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            if (hasil == "sukses")
            {
                dataGridViewBarang.DataSource = daftar.DaftarKategoriBarang;
            }
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeKategori", "Kode Kategori");
            dataGridViewBarang.Columns.Add("Nama", "Nama");
           

            dataGridViewBarang.Columns["KodeKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           

            
        }

    }
}
