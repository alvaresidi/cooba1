using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPenjualanPembelian
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            //ubah form ini (FormUtama) menjadi fullscreen (maximized)
            this.WindowState = FormWindowState.Maximized;

            //ubah FormUtama menjadi MdiParent (MdiContainer)
            this.IsMdiContainer = true;

            //tampilkan FormLogin terlebih dahulu sebelum bisa mengakses sistem
            FormLogin frmLogin = new FormLogin();
            frmLogin.Owner = this;
            frmLogin.Show();
            this.Enabled = false;
        }

        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //buka form daftar kategori
            Form form = Application.OpenForms["FormDaftarKategori"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarKategori frmKategori = new FormDaftarKategori(); //create objek FormDaftarKategori
                frmKategori.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frmKategori.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //buka form daftar pelanggan
            Form form = Application.OpenForms["FormDaftarPelanggan"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarPelanggan frmPelanggan = new FormDaftarPelanggan(); //create objek FormDaftarPelanggan
                frmPelanggan.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frmPelanggan.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }

        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //buka form daftar pelanggan
            Form form = Application.OpenForms["FormDaftarBarang"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarBarang frmBarang = new FormDaftarBarang(); //create objek FormDaftarPelanggan
                frmBarang.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frmBarang.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPegawai"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarPegawai frm = new FormDaftarPegawai(); //create objek FormDaftarPelanggan
                frm.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frm.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }
        }

        private void labelNamaPegawai_Click(object sender, EventArgs e)
        {

        }

        private void labelJabatan_Click(object sender, EventArgs e)
        {

        }

        private void penjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarNotaJual"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarNotaJual frm = new FormDaftarNotaJual(); //create objek FormDaftarPelanggan
                frm.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frm.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }
        }

        private void pembelianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarNotaBeli"];

            if (form == null) //jika form ini belum pernah di-create sebelumnya
            {
                FormDaftarNotaBeli frm = new FormDaftarNotaBeli(); //create objek FormDaftarPelanggan
                frm.MdiParent = this; //set form utama menjadi parent dari objek form yang dibuat
                frm.Show(); //tampilkan form
            }
            else
            {
                form.Show();
                form.BringToFront(); //agar form tampil di paling depan
            }
        }


    }
}
