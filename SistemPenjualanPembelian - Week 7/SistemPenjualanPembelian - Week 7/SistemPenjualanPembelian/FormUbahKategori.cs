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
    public partial class FormUbahKategori : Form
    {
        public FormUbahKategori()
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            Kategori kt = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);

            DaftarKategori daftar = new DaftarKategori();

            string hasilTambah = daftar.UbahData(kt);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data kategori telah diubah", "Info");

                //kosongi textbox
                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data kategori gagal diubah. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void FormUbahKategori_Load(object sender, EventArgs e)
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
                        textBoxNamaKategori.Focus();
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
