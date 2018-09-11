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
    public partial class FormHapusKategori : Form
    {
        public FormHapusKategori()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKategori frm = (FormDaftarKategori)this.Owner;
            frm.FormDaftarKategori_Load(sender, e);

            this.Close();
        }
        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeKategori.Text = "";
            textBoxNamaKategori.Text = "";
            textBoxKodeKategori.Focus();
        }
        private void buttonHapus_Click(object sender, EventArgs e)
        {
            //pastikan dulu kepada user apakah akan menghapus data
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes) //jika user yakin menghapus data
            {
                Kategori kt = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

                DaftarKategori daftar = new DaftarKategori();

                string hasilTambah = daftar.HapusData(kt);

                if (hasilTambah == "sukses")
                {
                    MessageBox.Show("Data kategori telah dihapus", "Info");

                    //kosongi textbox
                    buttonKosongi_Click(buttonHapus, e);
                }
                else
                {
                    MessageBox.Show("Data kategori gagal dihapus. Pesan kesalahan : " + hasilTambah, "Kesalahan");
                }
            }

        }
        private void FormHapusKategori_Load(object sender, EventArgs e)
        {
            //agar kode kategori hanya dapat diisi 2 karakter (sesuai panjang karakter KodeKategori)
            textBoxKodeKategori.MaxLength = 2;
        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            //jika user telah mengetik sesuai panjang karakter KodeKategori
            if (textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                //cari nama kategori sesuai kode kategori yang diinputkan user
                DaftarKategori daftar = new DaftarKategori();
                string hasil = daftar.CariData("KodeKategori", textBoxKodeKategori.Text);
                if (hasil == "sukses")
                {
                    //jika kode kategori ditemukan di database
                    if (daftar.JumlahKategoriBarang > 0)
                    {
                        textBoxNamaKategori.Text = daftar.DaftarKategoriBarang[0].NamaKategori;

                        textBoxNamaKategori.Enabled = false;  //agar textbox nama tidak dapat diganti            
                    }
                    else
                    {
                        MessageBox.Show("Kode kategori tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                        textBoxNamaKategori.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }
    }
}
