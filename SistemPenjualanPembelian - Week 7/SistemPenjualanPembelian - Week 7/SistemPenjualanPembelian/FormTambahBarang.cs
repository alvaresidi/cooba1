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
    public partial class FormTambahBarang : Form
    {
        public FormTambahBarang()
        {
            InitializeComponent();
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            DaftarBarang daftar = new DaftarBarang();
            string hasil = daftar.GenerateKode();
            if(hasil=="sukses")
            {
                textBoxKodeBarang.Text = daftar.KodeTerbaru;
                textBoxKodeBarang.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. pesan kesalahan = " + hasil);
            }

            DaftarKategori daftarKat = new DaftarKategori();
            hasil = daftarKat.BacaSemuaData();
            if(hasil=="sukses")
            {
                comboBox1.Items.Clear();
                for(int i = 0; i<daftarKat.JumlahKategoriBarang;i++)
                {
                    comboBox1.Items.Add(daftarKat.DaftarKategoriBarang[i].KodeKategori + " - " + daftarKat.DaftarKategoriBarang[i].NamaKategori);

                }

            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di combobox. peasan kesalahan = " + hasil);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            int hrgJual = int.Parse(textBoxHargaJual.Text);
            int stk = int.Parse(textBoxStok.Text);

            string kodeKategori = comboBox1.Text.Substring(0, 2);
            string namaKategori = comboBox1.Text.Substring(5, comboBox1.Text.Length - 5);

            Kategori katBarang = new Kategori(kodeKategori, namaKategori);

            Barang brg = new Barang(textBoxKodeBarang.Text,textBoxNamaBarang.Text,hrgJual,stk,katBarang);

            DaftarBarang daftar = new DaftarBarang();

            string hasilTambah = daftar.TambahData(brg);
            if(hasilTambah=="sukses")
            {
                MessageBox.Show("Data barang telah disimpan", "Info");

                Owner.Refresh();
                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. pesan kesalahan : " + hasilTambah,  "kesalahan");
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

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
