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
    public partial class FormHapusPegawai : Form
    {
        public FormHapusPegawai()
        {
            InitializeComponent();
        }

        private void FormHapusPegawai_Load(object sender, EventArgs e)
        {
            textBoxKodePegawai.MaxLength = 1;

             DaftarPegawai daftar = new DaftarPegawai();
            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();

                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    comboBoxJabatan.Items.Add(daftar.ListPegawai[i].KategoriJabatan.IdJabatan + " - " + daftar.ListPegawai[i].KategoriJabatan.NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di combobox. pesan kesalahan : " + hasil);
            }
        }

        private void textBoxKodePegawai_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodePegawai.Text.Length == textBoxKodePegawai.MaxLength)
            {
                DaftarPegawai daftar = new DaftarPegawai();
                string hasil = daftar.CariData("KodePegawai", textBoxKodePegawai.Text);


                if (hasil == "sukses")
                {
                    if (daftar.JumlahPegawai > 0)
                    {
                        textBoxNama.Text = daftar.ListPegawai[0].NamaPegawai;
                        dateTimePickerTgl.Text = daftar.ListPegawai[0].TglLahir.ToString();
                        textBoxAlamat.Text = daftar.ListPegawai[0].Alamat;
                        textBoxGaji.Text = daftar.ListPegawai[0].Gaji.ToString();
                        textBoxUser.Text = daftar.ListPegawai[0].Username;
                        textBoxPass.Text = daftar.ListPegawai[0].Password;
                        Jabatan pg = daftar.ListPegawai[0].KategoriJabatan;
                        comboBoxJabatan.SelectedItem = pg.NamaJabatan + " - " + pg.NamaJabatan;
                        textBoxNama.Focus();
                        textBoxKodePegawai.Enabled = false;
                        textBoxUser.Enabled = false;
                        textBoxNama.Enabled = false;
                        textBoxGaji.Enabled = false;
                        textBoxPass.Enabled = false;
                        textBoxUser.Enabled = false;
                        dateTimePickerTgl.Enabled = false;
                        textBoxAlamat.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show(" Kode Barang tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah Sql gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            
            int gaji = int.Parse(textBoxGaji.Text);

            string kodeJabatan = comboBoxJabatan.Text.Substring(0, 2);
            string namaJabatan = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);

            Jabatan jb = new Jabatan(kodeJabatan, namaJabatan);

            Pegawai pg = new Pegawai(textBoxKodePegawai.Text, textBoxNama.Text, dateTimePickerTgl.Value, textBoxAlamat.Text, gaji, textBoxUser.Text, textBoxPass.Text, jb);

            DaftarPegawai daftar = new DaftarPegawai();

            string hapusdata = daftar.HapusData(pg);
            if (hapusdata == "sukses")
            {
                string hapusUser = daftar.HapusUser(textBoxUser.Text, textBoxPass.Text);
                if(hapusUser=="sukses")
                {
                    MessageBox.Show("Data pegawai telah Dihapus", "Info");
                    buttonKosongi_Click(buttonKosongi, e);
                }
                else
                {
                    MessageBox.Show("Gagal menghapus pegawai", "Info");
                }
                


               
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. pesan kesalahan : " + hapusdata, "kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNama.Text = "";
            textBoxGaji.Text = "";
            textBoxPass.Text = "";
            textBoxKodePegawai.Text = "";
            textBoxAlamat.Text = "";

            comboBoxJabatan.SelectedIndex = -1;
            textBoxNama.Focus();
        }
    }
}
