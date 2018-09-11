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
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai frm = new FormTambahPegawai();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPegawai frm = new FormUbahPegawai();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPegawai frm = new FormHapusPegawai();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
             comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
            

            DaftarPegawai daftar = new DaftarPegawai();

            string hasil = daftar.BacaSemuaData();
            MessageBox.Show(hasil);
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();
                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    string kodeBrg = daftar.ListPegawai[i].KodePegawai;
                    string namaBrg = daftar.ListPegawai[i].NamaPegawai;
                    DateTime tgl = daftar.ListPegawai[i].TglLahir;
                    string al = daftar.ListPegawai[i].Alamat;
                    int gaji = daftar.ListPegawai[i].Gaji;
                    string user = daftar.ListPegawai[i].Username;
                    string pass = daftar.ListPegawai[i].Password;
                    string namaJabatan = daftar.ListPegawai[i].KategoriJabatan.NamaJabatan;
                    dataGridViewBarang.Rows.Add(kodeBrg, namaBrg, tgl, al, gaji, user,pass,namaJabatan);
                }
                
            }
            else
            {
                MessageBox.Show("Gagal Menampilkan data. Pesan kesalahan = " + hasil, "Kesalahan");
            }
            
 
            

        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            DaftarPegawai daftar = new DaftarPegawai();
            
            string kriteria = "";
            if (comboBoxCari.Text == "Kode Pegawai")
            {
                kriteria = "KodePegawai";
            }
            else if (comboBoxCari.Text == "Nama Pegawai")
            {
                kriteria = "Nama";
            }
            else if (comboBoxCari.Text == "Tanggal Lahir")
            {
                kriteria = "TglLahir";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "Alamat";
            }
            else if (comboBoxCari.Text == "Gaji")
            {
                kriteria = "Gaji";
            }
            else if (comboBoxCari.Text == "Username")
            {
                kriteria = "Username";
            }
            else if (comboBoxCari.Text == "Jabatan")
            {
                kriteria = "IdJabatan";
            }

            string hasil = daftar.CariData(kriteria, textBoxCari.Text);
            if (hasil == "sukses")
            {
                FormatDataGrid();
                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < daftar.JumlahPegawai; i++)
                {
                    string kodeBrg = daftar.ListPegawai[i].KodePegawai;
                    string namaBrg = daftar.ListPegawai[i].NamaPegawai;
                    DateTime tgl = daftar.ListPegawai[i].TglLahir;
                    string al = daftar.ListPegawai[i].Alamat;
                    int gaji = daftar.ListPegawai[i].Gaji;
                    string user = daftar.ListPegawai[i].Username;
                    string pass = daftar.ListPegawai[i].Password;
                    string namaJabatan = daftar.ListPegawai[i].KategoriJabatan.NamaJabatan;
                    dataGridViewBarang.Rows.Add(kodeBrg, namaBrg, tgl, al, gaji, user, pass, namaJabatan);
                }
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewBarang.Columns.Add("Nama", "Nama Pegawai");
            dataGridViewBarang.Columns.Add("TglLahir", "Tanggal Lahir");
            dataGridViewBarang.Columns.Add("Alamat", "Alamat ");
            dataGridViewBarang.Columns.Add("Gaji", "Gaji");
            dataGridViewBarang.Columns.Add("Username", "Username");
            dataGridViewBarang.Columns.Add("Password", "Password");
            dataGridViewBarang.Columns.Add("IdJabatan", "Jabatan");

            dataGridViewBarang.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["IdJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewBarang.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["Gaji"].DefaultCellStyle.Format = "0,###";
        }
    }
}
