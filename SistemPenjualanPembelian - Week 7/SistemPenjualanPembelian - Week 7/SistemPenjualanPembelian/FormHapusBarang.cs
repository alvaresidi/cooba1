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
    public partial class FormHapusBarang : Form
    {
        public FormHapusBarang()
        {
            InitializeComponent();
        }

        private void FormHapusBarang_Load(object sender, EventArgs e)
        {
            textBoxKodeBarang.MaxLength = 5;

            DaftarKategori daftarKat = new DaftarKategori();
            string hasil = daftarKat.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBox1.Items.Clear();

                for (int i = 0; i < daftarKat.JumlahKategoriBarang; i++)
                {
                    comboBox1.Items.Add(daftarKat.DaftarKategoriBarang[i].KodeKategori + " - " + daftarKat.DaftarKategoriBarang[i].NamaKategori);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di combobox. pesan kesalahan : " + hasil);
            }
        }

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeBarang.Text.Length == textBoxKodeBarang.MaxLength)
            {
                DaftarBarang daftar = new DaftarBarang();
                string hasil = daftar.CariData("KodeBarang", textBoxKodeBarang.Text);
               

                if (hasil == "sukses")
                {
                    if (daftar.JumlahBarang > 0)
                    {
                        textBoxNamaBarang.Text = daftar.ListBarang[0].NamaBarang;
                        textBoxHargaJual.Text = daftar.ListBarang[0].HargaJual.ToString();
                        textBoxStok.Text = daftar.ListBarang[0].Stok.ToString();
                        Kategori katBarang = daftar.ListBarang[0].KategoriBarang;
                        comboBox1.SelectedItem = katBarang.KodeKategori + " - " + katBarang.NamaKategori;
                       // textBoxNamaBarang.Focus();

                        textBoxNamaBarang.Enabled = false;
                        textBoxHargaJual.Enabled = false;
                        textBoxStok.Enabled = false;
                        comboBox1.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show(" Kode Barang tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNamaBarang.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah Sql gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            int hrgJual = int.Parse(textBoxHargaJual.Text);
            int stk = int.Parse(textBoxStok.Text);

            string kodeKategori = comboBox1.Text.Substring(0, 2);
            string namaKategori = comboBox1.Text.Substring(5, comboBox1.Text.Length - 5);

            Kategori katBarang = new Kategori(kodeKategori, namaKategori);

            Barang brg = new Barang(textBoxKodeBarang.Text, textBoxNamaBarang.Text, hrgJual, stk, katBarang);

            DaftarBarang daftar = new DaftarBarang();

            string hasilTambah = daftar.HapusData(brg);
            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data barang telah disimpan", "Info");


                buttonKosongi_Click(buttonHapus, e);
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. pesan kesalahan : " + hasilTambah, "kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeBarang.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxHargaJual.Text = "";
            textBoxStok.Text = "";
            comboBox1.SelectedIndex = -1;
            textBoxNamaBarang.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBarang frm = (FormDaftarBarang)this.Owner;
            frm.FormDaftarBarang_Load(sender, e);
            this.Close();
        }
    }
}
