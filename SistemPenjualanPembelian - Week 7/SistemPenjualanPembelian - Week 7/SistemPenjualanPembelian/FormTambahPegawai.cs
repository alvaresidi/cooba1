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
    public partial class FormTambahPegawai : Form
    {
        public FormTambahPegawai()
        {
            InitializeComponent();
        }

        private void FormTambahPegawai_Load(object sender, EventArgs e)
        {
            DaftarPegawai daftar = new DaftarPegawai();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKodePegawai.Text = daftar.KodeTerbaru;
                textBoxKodePegawai.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. pesan kesalahan = " + hasil);
            }

            DaftarJabatan daftarJb = new DaftarJabatan();
            hasil = daftarJb.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();
                for (int i = 0; i < daftarJb.JumlahKategoriBarang; i++)
                {
                    comboBoxJabatan.Items.Add(daftarJb.ListJabatan[i].IdJabatan + " - " + daftarJb.ListJabatan[i].NamaJabatan);

                }

            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di combobox. peasan kesalahan = " + hasil);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            int gaji = int.Parse(textBoxGaji.Text);


            string kodeKategori = comboBoxJabatan.Text.Substring(0, 2);
            string namaKategori = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);

            Jabatan jb = new Jabatan(kodeKategori, namaKategori);

            Pegawai pg = new Pegawai(textBoxKodePegawai.Text, textBoxNama.Text,dateTimePickerTgl.Value , textBoxAlamat.Text, gaji, textBoxUser.Text, textBoxPass.Text, jb);
            
            DaftarPegawai daftar = new DaftarPegawai();

            string hasilTambah = daftar.TambahData(pg);
            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data Pegawai telah disimpan", "Info");


                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data Pegawai gagal tersimpan. pesan kesalahan : " + hasilTambah, "kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodePegawai.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxUser.Text = "";
            textBoxUlPass.Text = "";
            textBoxPass.Text = "";
            textBoxGaji.Text = "";
            
        }

        private void dateTimePickerTgl_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
