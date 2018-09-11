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
    public partial class FormUbahPegawai : Form
    {
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void textBoxKodePegawai_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodePegawai.Text.Length == textBoxKodePegawai.MaxLength)
            {
                DaftarPegawai daftar = new DaftarPegawai();
                string hasil = daftar.CariData("KodePegawai", textBoxKodePegawai.Text);
                MessageBox.Show(hasil);
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
                        comboBoxJabatan.SelectedItem = pg.IdJabatan + " - " + pg.NamaJabatan;
                        textBoxNama.Focus();
                        //textBoxKodePegawai.Enabled=false;
                        textBoxUser.Enabled = false;
                        textBoxPass.Enabled = false;


                    }
                    else
                    {
                        MessageBox.Show(" Kode pegawai tidak ditemukan. Proses ubah data tidak bisa dilakukan.");
                    }
                }
                else
                {
                    MessageBox.Show("Perintah Sql gagal dijalankan. Pesan kesalahan = " + hasil);
                }
            }
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            textBoxKodePegawai.MaxLength = 1;

            DaftarPegawai daftar = new DaftarPegawai();
            string hasil = daftar.BacaSemuaData();
            if (hasil == "sukses")
            {
                comboBoxJabatan.Items.Clear();

                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    comboBoxJabatan.Items.Add(daftar.ListPegawai[i].KodePegawai + " - " + daftar.ListPegawai[i].NamaPegawai);
                }
            }
            else
            {
                MessageBox.Show("Kategori gagal ditampilkan di combobox. pesan kesalahan : " + hasil);
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

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            
            FormDaftarPegawai frm = (FormDaftarPegawai)this.Owner;
            frm.FormDaftarPegawai_Load(sender, e);
            frm.Close();
           
           
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            
            int gaji = int.Parse(textBoxGaji.Text);

            string kodeKategori = comboBoxJabatan.Text.Substring(0, 1);
            string namaKategori = comboBoxJabatan.Text.Substring(5, comboBoxJabatan.Text.Length - 5);

            Jabatan jb = new Jabatan(kodeKategori, namaKategori);

            Pegawai pg = new Pegawai(textBoxKodePegawai.Text, textBoxNama.Text, dateTimePickerTgl.Value, textBoxAlamat.Text, gaji, textBoxUser.Text, textBoxPass.Text, jb);

            DaftarPegawai daftar = new DaftarPegawai();

            string hasilTambah = daftar.UbahData(pg);
            if (hasilTambah == "sukses")
            {
                string ubahPassword= daftar.ubahPasswordUser(textBoxUser.Text,textBoxPass.Text);
                if(ubahPassword=="sukses")
                {
                    MessageBox.Show("Data pegawai telah disimpan", "Info");
                    buttonKosongi_Click(buttonSimpan, e);
                }
                else
                {
                    MessageBox.Show("gagal mengubah data pegawai");
                }

                
            }
            else
            {
                MessageBox.Show("Data barang gagal tersimpan. pesan kesalahan : " + hasilTambah, "kesalahan");
            }
        }
    }
}
