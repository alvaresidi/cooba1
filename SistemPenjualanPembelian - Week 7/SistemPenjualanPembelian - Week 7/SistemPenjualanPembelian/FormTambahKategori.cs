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
    public partial class FormTambahKategori : Form
    {
        public FormTambahKategori()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            
            FormDaftarKategori frm = (FormDaftarKategori) this.Owner;
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

            string hasilTambah = daftar.TambahData(kt);

            if (hasilTambah == "sukses")
            {
                MessageBox.Show("Data kategori telah tersimpan", "Info");

                //kosongi textbox
                buttonKosongi_Click(buttonSimpan, e);
            }
            else
            {
                MessageBox.Show("Data kategori gagal tersimpan. Pesan kesalahan : " + hasilTambah, "Kesalahan");
            }
        }

        private void FormTambahKategori_Load(object sender, EventArgs e)
        {
            DaftarKategori daftar = new DaftarKategori();
            string hasil = daftar.GenerateKode();
            if (hasil == "sukses")
            {
                textBoxKodeKategori.Text = daftar.KodeTerbaru;
                textBoxKodeKategori.Enabled = false;
            }
            else
            {
                MessageBox.Show("Generate kode gagal dilakukan. Pesan kesalahan = " + hasil);
            }
        }


    }
}
