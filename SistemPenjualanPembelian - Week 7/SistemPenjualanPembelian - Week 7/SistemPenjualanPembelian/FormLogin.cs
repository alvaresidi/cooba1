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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = 50 + panelLogin.Height;

            //beri nilai awal server dan database
            textBoxServer.Text = "localhost";
            textBoxDatabase.Text = "si_jual_beli";
        }

        private void linkLabelPengaturan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 50 + panelLogin.Height + panelPengaturan.Height;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxDatabase.Text !="")
            {
                this.Height = 50 + panelLogin.Height;
            }
            else
            {
                MessageBox.Show("Nama server dan nama database tidak boleh dikosongi", "Kesalahan");
            }
        }
       
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (textBoxUsername.Text != "")  
            {
                //create objek bertipe Koneksi dengan memanggil constructor berparameter milik class Koneksi
                Koneksi k = new Koneksi(textBoxServer.Text, textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);  

                string hasilConnect = k.Connect();  //panggil method Connect milik class Koneksi

                if (hasilConnect == "sukses") //jika koneksi ke database berhasil
                {
                    MessageBox.Show("Selamat Datang di Sistem Penjualan Pembelian", "Info"); //tampilkan ucapan selamat datang

                    FormUtama frmUtama = (FormUtama)this.Owner;
                    DaftarPegawai daftar = new DaftarPegawai();
                    string hasil = daftar.CariData("Username", textBoxUsername.Text);
                    if(hasil=="sukses")
                    {
                        frmUtama.Enabled = true;
                        frmUtama.labelKodePegawai.Text = daftar.ListPegawai[0].KodePegawai;
                        frmUtama.labelNamaPegawai.Text = daftar.ListPegawai[0].NamaPegawai;
                        frmUtama.labelJabatan.Text = daftar.ListPegawai[0].KategoriJabatan.NamaJabatan;

                        PengaturanHakAksesMenu(daftar.ListPegawai[0].KategoriJabatan.NamaJabatan);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mencari data pegawai. Pesan = " + hasil, "kesalahan");
                    }
                }
                else  //jika gagal
                {
                    MessageBox.Show("Koneksi gagal. Pesan Kesalahan : " + hasilConnect, "Kesalahan");  //tampilkan pesan kesalahan
                }
            }
            else
            {
                MessageBox.Show("Username tidak boleh dikosongi", "Kesalahan");
            }
        }

        private void PengaturanHakAksesMenu(string jabatan)
        {
            FormUtama frmUtama = (FormUtama)this.Owner;
            if(jabatan=="kasir")
            {
                frmUtama.masterToolStripMenuItem.Visible = false;
                frmUtama.penjualanToolStripMenuItem.Visible = true;
                frmUtama.pembelianToolStripMenuItem.Visible = false;
                frmUtama.laporanmasterToolStripMenuItem.Visible = true;
                frmUtama.laporantransaksiToolStripMenuItem1.Visible = false;
            }
            else if(jabatan=="Pegawai Pembelian")
            {
                frmUtama.masterToolStripMenuItem.Visible = false;
                frmUtama.penjualanToolStripMenuItem.Visible = false;
                frmUtama.pembelianToolStripMenuItem.Visible = false;
                frmUtama.laporanmasterToolStripMenuItem.Visible = false;
                frmUtama.laporantransaksiToolStripMenuItem1.Visible = true;
            }
            else if(jabatan=="Manajer")
            {
                frmUtama.masterToolStripMenuItem.Visible = true;
                frmUtama.penjualanToolStripMenuItem.Visible = true;
                frmUtama.pembelianToolStripMenuItem.Visible = true;
                frmUtama.laporanmasterToolStripMenuItem.Visible = true;
                frmUtama.laporantransaksiToolStripMenuItem1.Visible = true;
            }
        }

    }
}
